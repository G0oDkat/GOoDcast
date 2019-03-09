namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public abstract class JsonPayloadChannel : Channel
    {
        protected JsonPayloadChannel(IChromecastClient client, string @namespace) : base(client, @namespace)
        {
        }

        protected abstract Task OnMessageReceivedAsync(string sourceId, string destinationId, JObject payload);

        public override Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload)
        {
            JObject jObject = JObject.Parse(payload);

            return OnMessageReceivedAsync(sourceId, destinationId, jObject);
        }

        public override Task OnMessageReceivedAsync(string sourceId, string destinationId, byte[] payload)
        {
            throw new NotSupportedException();
        }

        protected Task SendAsync(string sourceId, string destinationId, object message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string payload = JsonConvert.SerializeObject(message);

            return base.SendAsync(sourceId, destinationId, payload);
        }
    }
}