namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Json;
    using Json.NamingStrategies;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    public abstract class Channel : IChannel
    {
        private readonly IChromecastClient client;

        protected Channel(IChromecastClient client, string @namespace)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
        }

        public string Namespace { get; }

        public abstract Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload);

        public abstract Task OnMessageReceivedAsync(string sourceId, string destinationId, byte[] payload);

        protected Task SendAsync(string sourceId, string destinationId, string payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            return client.SendAsync(Namespace, sourceId, destinationId, payload);
        }

        protected Task SendAsync(string sourceId, string destinationId, byte[] payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            return client.SendAsync(Namespace, sourceId, destinationId, payload);
        }
    }
}