namespace GOoDcast.Extensions
{
    using System.Threading.Tasks;
    using Applications;
    using Channels;

    public static class ChromecastExtensions
    {
        public static async Task<YouTubeApplication> LaunchYouTube(this IChromecast chromecast)
        {
            ReceiverChannel receiverChannel = chromecast.GetOrCreateChannel(c => new ReceiverChannel(c));
            MediaChannel mediaChannel = chromecast.GetOrCreateChannel(c => new MediaChannel(c));
            var application = new YouTubeApplication(receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }
    }
}