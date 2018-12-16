namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Messages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public abstract class ChromecastChannel : IChromecastChannel
    {
        private readonly ConcurrentDictionary<int, TaskCompletionSource<JObject>> pendingRequests;

        protected ChromecastChannel(IChromecastClient client, string @namespace)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));

            pendingRequests = new ConcurrentDictionary<int, TaskCompletionSource<JObject>>();
        }

        private IChromecastClient Client { get; }

        public string Namespace { get; }

        public virtual Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload)
        {
            JObject message = JObject.Parse(payload);

            if (message.TryGetValue("requestId", out JToken value))
            {
                int requestId = value.Value<int>();

                if (pendingRequests.TryRemove(requestId, out TaskCompletionSource<JObject> taskCompletionSource))
                    taskCompletionSource.TrySetResult(message);

                return Task.CompletedTask;
            }

            return OnPushMessageReceivedAsync(sourceId, destinationId, message);
        }

        protected virtual Task OnPushMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            return Task.CompletedTask;            
        }

        public Task OnMessageReceivedAsync(string sourceId, string destinationId, byte[] payload)
        {
            return Task.CompletedTask;
        }

        protected async Task<TResponse> RequestAsync<TResponse>(string sourceId, string destinationId,
                                                                IMessageWithId message) where TResponse : IMessageWithId
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var completionSource = new TaskCompletionSource<JObject>();

            if (!pendingRequests.TryAdd(message.RequestId, completionSource))
                throw new
                    InvalidOperationException($"There already exists a pending request with this ID {message.RequestId}");

            await SendAsync(sourceId, destinationId, message);

            return (await completionSource.Task).ToObject<TResponse>();
        }

        protected Task SendAsync(string sourceId, string destinationId, IMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string payload = JsonConvert.SerializeObject(message);

            return Client.SendAsync(Namespace, sourceId, destinationId, payload);
        }
    }
}