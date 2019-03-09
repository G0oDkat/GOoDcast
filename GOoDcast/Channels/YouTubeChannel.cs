namespace GOoDcast.Channels
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Messages.YouToube;
    using Newtonsoft.Json.Linq;

    public class YouTubeChannel : JsonRequestResponseChannel, IYouTubeChannel
    {
        public event EventHandler<string> ScreenIdChanged;

        public YouTubeChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.youtube.mdx")
        {
            //MessageReceived += YouTubeChannel_MessageReceived;
        }

        public Task GetScreenId(string sourceId, string destinationId)
        {
            return SendAsync(sourceId, destinationId, new GetScreenIdMessage());
        }

        protected override Task OnPushMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            payload.ToObject<YouTubeSessionStatusResponse>();

            OnScreenIdChanged(response.Data.ScreenId);

            return Task.CompletedTask;
        }

        protected virtual void OnScreenIdChanged(string screenId)
        {
            ScreenIdChanged?.Invoke(this, screenId);
        }

        //private void YouTubeChannel_MessageReceived(object sender, ChromecastSSLClientDataReceivedArgs e)
        //{
        //    var json = e.Message.PayloadUtf8;
        //    var response = JsonConvert.DeserializeObject<YouTubeSessionStatusResponse>(json);
        //    ScreenIdChanged?.Invoke(this, response.Data.ScreenId);
        //}
    }
}