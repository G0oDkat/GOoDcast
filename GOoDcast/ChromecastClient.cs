namespace GOoDcast
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using global::ProtoBuf;
    using Models;
    using Models.ChromecastRequests;
    using ProtoBuf;
    using Sockets.Plugin;
    using Sockets.Plugin.Abstractions;

    public class ChromecastClient : IChromecastClient
    {
        private const int Port = 8009;
        private const int timeout = 30000;
        private readonly ITcpSocketClient client;
        private readonly SemaphoreSlim mutex;

        public ChromecastClient()
        {
            client = new TcpSocketClient();
            mutex = new  SemaphoreSlim(1,1);
        }

        public void Dispose()
        {
            client?.Dispose();
        }

        public async Task ConnectAsync(string address)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                await client.ConnectAsync(address, Port, true, cancellationTokenSource.Token);
            }
        }

        public Task DisconnectAsync()
        {
            return client.DisconnectAsync();
        }

        public async Task<ChromecastMessage> RequestAsync(ChromecastMessage request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await mutex.WaitAsync();

            try
            {
                await SendAsyncInternal(request);

                ChromecastMessage response;
                bool isHearbeat;
                do
                {
                    response = await ReciveAsyncInternal();

                    Debug.WriteLine($"recived: {response}");

                    isHearbeat = response.Namespace == "urn:x-cast:com.google.cast.tp.heartbeat"
                                 && response.PayloadUtf8.Contains("PING");
                    //if (isHearbeat) await SendAsync(new PongRequest());
                } while (isHearbeat);

                return response;
            }
            finally
            {
                mutex.Release();
            }            
        }

        public async Task SendAsync(ChromecastMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            await mutex.WaitAsync();
            try
            {
                await SendAsyncInternal(message);
            }
            finally
            {
                mutex.Release();
            }               
        }

        private async Task SendAsyncInternal(ChromecastMessage request)
        {
            Debug.WriteLine($"send: {request}");

            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                await ProtoBufSerializer.SerializeWithLengthPrefixAsync(client.WriteStream, request, PrefixStyle.Fixed32BigEndian,cancellationTokenSource.Token);
            }
        }

        private async Task<ChromecastMessage> ReciveAsyncInternal()
        {
            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                return await ProtoBufSerializer.DeserializeWithLengthPrefixAsync<ChromecastMessage>(client.ReadStream, PrefixStyle.Fixed32BigEndian, cancellationTokenSource.Token);
            }
        }
    }
}