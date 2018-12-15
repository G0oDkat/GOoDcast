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

        public async Task ConnectAsync(string destinationId)
        {
            await SendAsync(new ConnectMessage(), destinationId);
        }

        public override Task OnPushMessageReceivedAsync(JObject rawMessage)
        {
            //TODO: handle close message

            return Task.CompletedTask;
        }
    }
}
