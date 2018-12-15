namespace GOoDcast.Extensions
{
    using System.Threading.Tasks;
    using Applications;
    using Channels;

    public static class ChromecastExtensions
    {
        public static async Task<WebApplication> LaunchWeb(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var webChannel = chromecast.GetChannel<IWebChannel>();
            var application = new WebApplication(connectionChannel, receiverChannel, webChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<YouTubeApplication> LaunchYouTube(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var application = new YouTubeApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<TwitchApplication> LaunchTwitch(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var application = new TwitchApplication(connectionChannel, receiverChannel);
            await application.LaunchApplicationAsync();
            return application;
        }
    }
}