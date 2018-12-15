namespace GOoDcast
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Channels;
    using global::ProtoBuf;
    using Messages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ProtoBuf;

    public class ChromecastClient : IChromecastClient
    {
        private const int Port = 8009;
        private const int Timeout = 30000;

        private readonly Dictionary<string, IChromecastChannel> channels;

        private readonly TcpClient client;
        private SslStream stream;
        private readonly SemaphoreSlim mutex;

        private readonly ConcurrentDictionary<int, TaskCompletionSource<JObject>> pendingRequests;
        private Task MessageReceiverTask;

        private CancellationTokenSource receiverCancellationTokenSource;

        public ChromecastClient()
        {
            client = new TcpClient();
            mutex = new SemaphoreSlim(1, 1);

            channels = new Dictionary<string, IChromecastChannel>();
            pendingRequests = new ConcurrentDictionary<int, TaskCompletionSource<JObject>>();
        }

        public void Dispose()
        {
            stream?.Dispose();
            client?.Dispose();
            receiverCancellationTokenSource?.Dispose();
        }

        public void BindChannel(IChromecastChannel channel)
        {
            if (channel == null) throw new ArgumentNullException(nameof(channel));

            channels.Add(channel.Namespace, channel);
        }

        public async Task ConnectAsync(string address)
        {
            await client.ConnectAsync(address, Port);
            stream = new SslStream(client.GetStream(), false, ValidateServerCertificate, null);
            stream.AuthenticateAsClient(address);
            
            MessageReceiverTask = RunMessageReceiver();
        }

        public async Task DisconnectAsync()
        {
            receiverCancellationTokenSource.Cancel();

            try
            {
                await MessageReceiverTask;
            }
            catch (OperationCanceledException)
            {
            }

            receiverCancellationTokenSource.Dispose();
            receiverCancellationTokenSource = null;

            client.Close();
        }

        public async Task<TResponse> RequestAsync<TResponse>(string @namespace, IMessageWithId request,
                                                             string destinationId) where TResponse : IMessageWithId
        {
            if (@namespace == null) throw new ArgumentNullException(nameof(@namespace));
            if (destinationId == null) throw new ArgumentNullException(nameof(destinationId));
            if (request == null) throw new ArgumentNullException(nameof(request));

            string payload =
                JsonConvert.SerializeObject(request,
                                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            var message = new ChromecastMessage(@namespace, payload, destinationId);

            var completionSource = new TaskCompletionSource<JObject>();

            if (!pendingRequests.TryAdd(request.RequestId, completionSource))
                throw new
                    InvalidOperationException($"There already exists a pending request with this ID {request.RequestId}");

            await SendAsyncInternal(message);

            return (await completionSource.Task).ToObject<TResponse>();
        }

        public async Task SendAsync(string @namespace, IMessage request, string destinationId)
        {
            if (@namespace == null) throw new ArgumentNullException(nameof(@namespace));
            if (destinationId == null) throw new ArgumentNullException(nameof(destinationId));
            if (request == null) throw new ArgumentNullException(nameof(request));

            string payload =
                JsonConvert.SerializeObject(request,
                                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            var message = new ChromecastMessage(@namespace, payload, destinationId);

            await SendAsyncInternal(message);
        }

        private async Task SendAsyncInternal(ChromecastMessage request)
        {
            Debug.WriteLine("S {0}", request);

            await mutex.WaitAsync();
            try
            {
                using (var cancellationTokenSource = new CancellationTokenSource(Timeout))
                {
                    await ProtoBufSerializer.SerializeWithLengthPrefixAsync(stream, request,
                                                                            PrefixStyle.Fixed32BigEndian,
                                                                            cancellationTokenSource.Token);
                }
            }
            finally
            {
                mutex.Release();
            }
        }

        private async Task<ChromecastMessage> ReciveAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var timeoutTokenSource = new CancellationTokenSource(Timeout))
            using (CancellationTokenSource linkedTokenSource =
                CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutTokenSource.Token))
            {
                return await ProtoBufSerializer.DeserializeWithLengthPrefixAsync<ChromecastMessage>(stream,
                                                                                                    PrefixStyle
                                                                                                        .Fixed32BigEndian,
                                                                                                    linkedTokenSource
                                                                                                        .Token);
            }
        }

        private Task RunMessageReceiver()
        {
            receiverCancellationTokenSource = new CancellationTokenSource();

            return Task.Run(ReceiveMessages);
        }

        private async Task ReceiveMessages()
        {
            CancellationToken cancellationToken = receiverCancellationTokenSource.Token;

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                    await ProcessMessage(await ReciveAsync(cancellationToken));

                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException) throw;

                Debug.WriteLine(exception);

                await DisconnectAsync();
            }
        }

        private async Task ProcessMessage(ChromecastMessage castMessage)
        {
            string payload = castMessage.GetPayloadByType();

            Debug.WriteLine("R {0}", castMessage);

            if (channels.TryGetValue(castMessage.Namespace, out IChromecastChannel channel))
            {
                JObject message = JObject.Parse(payload);

                if (message.TryGetValue("requestId", out JToken value))
                {
                    int requestId = value.Value<int>();

                    if (pendingRequests.TryRemove(requestId, out TaskCompletionSource<JObject> taskCompletionSource))
                        taskCompletionSource.TrySetResult(message);
                }
                else
                {
                    await channel.OnPushMessageReceivedAsync(message);
                }
            }
        }


        private static bool ValidateServerCertificate(object sender, X509Certificate certificate,
                                                     X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return !sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateNotAvailable);
        }
    }
}