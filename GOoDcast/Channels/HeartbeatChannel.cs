namespace GOoDcast.Channels
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Models.ChromecastRequests;
    using ProtoBuf;

    public class HeartbeatChannel : ChromecastChannel
    {
        public HeartbeatChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.tp.heartbeat")
        {
        }

        //private async void HeartbeatChannel_MessageReceived(object sender, ChromecastSSLClientDataReceivedArgs e)
        //{
        //    Debug.WriteLine(e.Message.GetJsonType());
        //    if (Client.Connected || e.Message.GetJsonType() != "PONG") return;
        //    //Wait 100 milliseconds before sending GET_STATUS because chromecast was sending CLOSE back without a wait
        //    await Task.Delay(100);
        //    Client.ReceiverChannel.GetChromecastStatus();
        //    //Wait 100 milliseconds to make sure that the status of Chromecast device is received before notifying we have connected to it
        //    await Task.Delay(100);
        //    Client.Connected = true;
        //}

        public async Task StartHeartbeat()
        {
            TimeSpan delay = TimeSpan.FromSeconds(5);

            while (true)
            {
                try
                {
                    PongRequest message = await RequestAsync<PingRequest, PongRequest>(new PingRequest());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                await Task.Delay(delay);
            }

        }
    }
}