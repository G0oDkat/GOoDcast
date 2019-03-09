namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Messages.Connection;
    using Newtonsoft.Json.Linq;

    public class ConnectionChannel : JsonPayloadChannel, IConnectionChannel
    {
        public ConnectionChannel(IChromecastClient client) :
            base(client, "urn:x-cast:com.google.cast.tp.connection")
        {
        }

        public Task ConnectAsync(string sourceId, string destinationId)
        {
            return SendAsync(sourceId, destinationId, new ConnectMessage());
        }

        protected override Task OnMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            //TODO: handle close message

            return Task.CompletedTask;
        }
    }
}
