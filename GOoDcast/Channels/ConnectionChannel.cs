namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Messages.Connection;
    using Messages.Hearbeat;
    using Models;
    using Newtonsoft.Json.Linq;

    public class ConnectionChannel : ChromecastChannel, IConnectionChannel
    {
        public ConnectionChannel(IChromecastClient client) :
            base(client, "urn:x-cast:com.google.cast.tp.connection")
        {
        }

        public Task ConnectAsync(string sourceId, string destinationId)
        {
            return SendAsync(sourceId, destinationId, new ConnectMessage());
        }

        public override Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload)
        {

            //TODO: handle close message

            return Task.CompletedTask;
        }
    }
}
