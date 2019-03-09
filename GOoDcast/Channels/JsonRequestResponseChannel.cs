namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using Messages;
    using Newtonsoft.Json.Linq;

    public abstract class JsonRequestResponseChannel : JsonPayloadChannel
    {
        private readonly ConcurrentDictionary<int, TaskCompletionSource<JObject>> pendingRequests;

        protected JsonRequestResponseChannel(IChromecastClient client, string @namespace) : base(client, @namespace)
        {
            pendingRequests = new ConcurrentDictionary<int, TaskCompletionSource<JObject>>();
        }

        protected abstract Task OnPushMessageReceivedAsync(string sourceId, string destinationId, JObject payload);

        protected override Task OnMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        { 
            if (payload.TryGetValue(nameof(IMessageWithId.RequestId), StringComparison.InvariantCultureIgnoreCase, out JToken value))
            {
                int requestId = value.Value<int>();

                if (pendingRequests.TryRemove(requestId, out TaskCompletionSource<JObject> taskCompletionSource))
                    taskCompletionSource.TrySetResult(payload);

                return Task.CompletedTask;
            }

            return OnPushMessageReceivedAsync(sourceId, destinationId, payload);
        }


        protected async Task<TResponse> RequestAsync<TResponse>(string sourceId,
                                                                string destinationId,
                                                                IMessageWithId message,
                                                                CancellationToken cancellationToken = default(CancellationToken)) where TResponse : IMessageWithId
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var completionSource = new TaskCompletionSource<JObject>();


            using (var timeoutTokenSource = new CancellationTokenSource(5000))
            using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutTokenSource.Token, cancellationToken))        
            using (linkedTokenSource.Token.Register(() => completionSource.TrySetCanceled()))
            {
                if (!pendingRequests.TryAdd(message.RequestId, completionSource))
                    throw new
                        InvalidOperationException($"There already exists a pending request with this ID {message.RequestId}");

                await SendAsync(sourceId, destinationId, message);

                try
                {
                    JObject jObject = await completionSource.Task;
                    return jObject.ToObject<TResponse>();
                }
                catch (OperationCanceledException)
                {
                    pendingRequests.TryRemove(message.RequestId, out _);
                    throw;
                }
            }
        }

        //protected Task SendAsync(string sourceId, string destinationId, object message)
        //{
        //    if (message == null) throw new ArgumentNullException(nameof(message));

        //    var settings = new JsonSerializerSettings
        //    {
        //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        Converters = {new StringEnumConverter(new UnderscoreUpperInvariantNamingStrategy())}
        //    };

        //    string payload = JsonConvert.SerializeObject(message, settings);

        //    return Client.SendAsync(Namespace, sourceId, destinationId, payload);
        //}
    }
}