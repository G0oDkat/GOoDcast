namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;

    public class DashCastApplication : ApplicationBase
    {
        private readonly IDashCastChannel dashCastChannel;
        private const string DashCastApplicationId = "5C3F0A3C";

        public DashCastApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel, IDashCastChannel dashCastChannel) : base(DashCastApplicationId, connectionChannel, receiverChannel)
        {
            this.dashCastChannel = dashCastChannel ?? throw new ArgumentNullException(nameof(dashCastChannel));
        }

        public Task LoadUrlAsync(string url)
        {
            return dashCastChannel.LoadUrl(DefaultIdentifiers.SourceId, TransportId, url);
        }

        public Task LoadYouTubeViedeoAsync(string videoId)
        {
            return LoadUrlAsync($"https://www.youtube.com/embed/{videoId}?rel=0&amp;autoplay=1;fs=0;autohide=0;hd=0;");
        }

        public Task LoadTwitchChannelAsync(string channel)
        {
            return LoadUrlAsync($"https://player.twitch.tv/?channel={channel}");
        }

        public Task LoadTwitchVideoAsync(string video)
        {
            return LoadUrlAsync($"https://player.twitch.tv/?video={video}");
        }

        public Task LoadTwitchCollectionAsync(string collection)
        {
            return LoadUrlAsync($"https://player.twitch.tv/?collection={collection}");
        }


    }
}