namespace GOoDcast.Channels
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Messages.YouToube;
    using Newtonsoft.Json.Linq;

    public class YouTubeChannel : ChromecastChannel, IYouTubeChannel
    {
        //public event EventHandler<string> ScreenIdChanged;
        public YouTubeChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.youtube.mdx")
        {
            //MessageReceived += YouTubeChannel_MessageReceived;
        }

        public Task LoadVideo(string sourceId, string destinationId, string videoId)
        {




            if (videoId == null) throw new ArgumentNullException(nameof(videoId));

            return SendAsync(sourceId, destinationId,
                             new LoadVideoMessage
                             {
                                 Type = "flingVideo",
                                 Data = new VideoData { CurrentTime = 0, VideoId = videoId },
                                 //RequestId = 55
                             });
        }

        public Task GetScreenId(string sourceId, string destinationId, string videoId)
        {
            return SendAsync(sourceId, destinationId, new GetScreenIdMessage());
        }

        protected override Task OnPushMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            Debug.WriteLine(payload);
            return Task.CompletedTask;
        }

        //private void YouTubeChannel_MessageReceived(object sender, ChromecastSSLClientDataReceivedArgs e)
        //{
        //    var json = e.Message.PayloadUtf8;
        //    var response = JsonConvert.DeserializeObject<YouTubeSessionStatusResponse>(json);
        //    ScreenIdChanged?.Invoke(this, response.Data.ScreenId);
        //}
    }
}