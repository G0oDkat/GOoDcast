namespace GOoDcast
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Channels;
    using global::ProtoBuf;
    using Nito.AsyncEx;
    using ProtoBuf;

    internal class ChromecastClient : IChromecastClient
    {
        private const int Port = 8009;
        private const int Timeout = 30000;

        private readonly Dictionary<string, IChannel> channels;
        private readonly AsyncLock mutex;

        private TcpClient client;

        private Task messageReceiverTask;

        private CancellationTokenSource receiverCancellationTokenSource;
        private SslStream stream;

        public ChromecastClient()
        {
            mutex = new AsyncLock();
            channels = new Dictionary<string, IChannel>();
        }

        public bool IsConnected { get; private set; }

        public void Dispose()
        {
            stream?.Dispose();
            client?.Dispose();
            receiverCancellationTokenSource?.Dispose();
        }

        public void BindChannel(IChannel channel)
        {
            if (channel == null) throw new ArgumentNullException(nameof(channel));

            channels.Add(channel.Namespace, channel);
        }

        public Task SendAsync(string @namespace, string sourceId, string destinationId, string payload)
        {
            ThrowWhenDisconnected();
            return SendAsync(new ChromecastMessage(@namespace, sourceId, destinationId, payload));
        }

        public Task SendAsync(string @namespace, string sourceId, string destinationId, byte[] payload)
        {
            ThrowWhenDisconnected();
            return SendAsync(new ChromecastMessage(@namespace, sourceId, destinationId, payload));
        }

        public async Task ConnectAsync(string address)
        {
            ThrowWhenConnected();

            client = new TcpClient();
            await client.ConnectAsync(address, Port);
            stream = new SslStream(client.GetStream(), false, ValidateServerCertificate, null);
            stream.AuthenticateAsClient(address);

            Task _ = RunMessageReceiver();

            IsConnected = true;
        }

        public async Task DisconnectAsync()
        {
            ThrowWhenDisconnected();

            receiverCancellationTokenSource.Cancel();

            try
            {
                await messageReceiverTask;
            }
            catch (OperationCanceledException)
            {
            }

            client.Close();
            client = null;
            IsConnected = false;
        }

        private void ThrowWhenDisconnected()
        {
            if (!IsConnected) throw new InvalidOperationException("ChromecastClient is not connected.");
        }

        private void ThrowWhenConnected()
        {
            if (IsConnected) throw new InvalidOperationException("ChromecastClient is already connected.");
        }

        private async Task SendAsync(ChromecastMessage message,
                                     CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine("S {0}", message);

            using (await mutex.LockAsync())
            {
                await ProtoBufSerializer.SerializeWithLengthPrefixAsync(stream, message, PrefixStyle.Fixed32BigEndian,
                                                                        cancellationToken);
            }
        }

        private async Task<ChromecastMessage> ReciveAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {

            

            return await ProtoBufSerializer.DeserializeWithLengthPrefixAsync<ChromecastMessage>(stream,
                                                                                                PrefixStyle
                                                                                                    .Fixed32BigEndian,
                                                                                                cancellationToken);
        }

        private async Task RunMessageReceiver()
        {
            using (receiverCancellationTokenSource = new CancellationTokenSource())
            {
                try
                {
                    messageReceiverTask = Task.Run(ReceiveMessages);
                    await messageReceiverTask;
                }
                catch (Exception exception)
                {
                    if (exception is OperationCanceledException) throw;

                    Debug.WriteLine(exception);

                    await DisconnectAsync();
                }
            }

            receiverCancellationTokenSource = null;
        }

        private async Task ReceiveMessages()
        {
            CancellationToken cancellationToken = receiverCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested)
                await HandleMessage(await ReciveAsync(cancellationToken));

            throw new OperationCanceledException();
        }

        private Task HandleMessage(ChromecastMessage castMessage)
        {
            Debug.WriteLine("R {0}", castMessage);

            if (channels.TryGetValue(castMessage.Namespace, out IChannel channel))
                switch (castMessage.PayloadType)
                {
                    case PayloadType.String:
                        return channel.OnMessageReceivedAsync(castMessage.SourceId, castMessage.DestinationId,
                                                              castMessage.PayloadUtf8);
                    case PayloadType.Binary:
                        return channel.OnMessageReceivedAsync(castMessage.SourceId, castMessage.DestinationId,
                                                              castMessage.PayloadBinary);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return Task.CompletedTask;
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
                                                      SslPolicyErrors sslPolicyErrors)
        {
            return !sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateNotAvailable);
        }
    }
}