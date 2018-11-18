namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Models.ChromecastRequests;

    public class ConnectionChannel : ChromecastChannel
    {
        public ConnectionChannel(IChromecastClient client) :
            base(client, "urn:x-cast:com.google.cast.tp.connection")
        {
        }

        public async Task OpenConnection()
        {
            await SendAsync(new ConnectRequest());
        }

        public async Task ConnectWithDestination()
        {
            throw new NotImplementedException();
            //await RequestAsync(MessageFactory.ConnectWithDestination(Client.CurrentApplicationTransportId));
        }
    }
}
