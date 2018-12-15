namespace GOoDcast.Extensions
{
    using System.Threading.Tasks;
    using Applications;
    using Channels;

    public static class ChromecastExtensions
    {
        public static async Task<WebApplication> LaunchWeb(this IChromecast chromecast)
        {
            IConnectionChannel connectionChannel = chromecast.GetOrCreateChannel(c => new ConnectionChannel(c));
            IReceiverChannel receiverChannel = chromecast.GetOrCreateChannel(c => new ReceiverChannel(c));
            IWebChannel webChannel = chromecast.GetOrCreateChannel(c => new WebChannel(c));
            var application = new WebApplication(connectionChannel, receiverChannel, webChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<YouTubeApplication> LaunchYouTube(this IChromecast chromecast)
        {
            IConnectionChannel connectionChannel = chromecast.GetOrCreateChannel(c => new ConnectionChannel(c));
            IReceiverChannel receiverChannel = chromecast.GetOrCreateChannel(c => new ReceiverChannel(c));
            IMediaChannel mediaChannel = chromecast.GetOrCreateChannel(c => new MediaChannel(c));
            var application = new YouTubeApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }


        public static async Task<TwitchApplication> LaunchTwitch(this IChromecast chromecast)
        {
            IConnectionChannel connectionChannel = chromecast.GetOrCreateChannel(c => new ConnectionChannel(c));
            IReceiverChannel receiverChannel = chromecast.GetOrCreateChannel(c => new ReceiverChannel(c));
            var application = new TwitchApplication(connectionChannel, receiverChannel);
            await application.LaunchApplicationAsync();
            return application;
        }
    }
}