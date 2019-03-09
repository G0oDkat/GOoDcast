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

        public static async Task<DashCastApplication> LaunchDashCast(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var dashCastChannel = chromecast.GetChannel<IDashCastChannel>();
            var application = new DashCastApplication(connectionChannel, receiverChannel, dashCastChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<DefaultMediaApplication> LaunchDefaultMediaApplication(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var application = new DefaultMediaApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<YouTubeApplication> LaunchYouTube(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var youTubeChannel = chromecast.GetChannel<IYouTubeChannel>();
            var application = new YouTubeApplication(connectionChannel, receiverChannel, mediaChannel, youTubeChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<TwitchApplication> LaunchTwitch(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var application = new TwitchApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<PlexApplication> LaunchPlex(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var application = new PlexApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }

        public static async Task<RedBullTvApplication> LaunchRedBullTV(this IChromecast chromecast)
        {
            var connectionChannel = chromecast.GetChannel<IConnectionChannel>();
            var receiverChannel = chromecast.GetChannel<IReceiverChannel>();
            var mediaChannel = chromecast.GetChannel<IMediaChannel>();
            var application = new RedBullTvApplication(connectionChannel, receiverChannel, mediaChannel);
            await application.LaunchApplicationAsync();
            return application;
        }
    }
}