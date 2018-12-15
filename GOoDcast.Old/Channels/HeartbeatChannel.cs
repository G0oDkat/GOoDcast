namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Messages.Hearbeat;
    using Miscellaneous;
    using Newtonsoft.Json.Linq;

    public class HeartbeatChannel : ChromecastChannel
    {
        public HeartbeatChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.tp.heartbeat")
        {
        }

        public override async Task OnPushMessageReceivedAsync(JObject rawMessage)
        {
            var message = rawMessage.ToObject<PingMessage>();

            if (message != null) await SendAsync(new PongMessage(), DefaultIdentifiers.DestinationId);
        }
    }
}