namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Messages.Hearbeat;
    using Miscellaneous;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class HeartbeatChannel : JsonPayloadChannel, IHeartbeatChannel
    {
        public HeartbeatChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.tp.heartbeat")
        {
        }

        protected override Task OnMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            return Task.CompletedTask;
        }

        public override async Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload)
        {
            var message = JsonConvert.DeserializeObject<PingMessage>(payload);

            if (message != null) await SendAsync(DefaultIdentifiers.SourceId, sourceId, new PongMessage());
        }
    }
}