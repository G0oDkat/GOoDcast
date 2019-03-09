namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;

    public class YouTubeApplication : MediaApplicationBase
    {
        private const string YouTubeApplicationId = "233637DE";

        private readonly IYouTubeChannel youTubeChannel;

        public YouTubeApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                                  IMediaChannel mediaChannel, IYouTubeChannel youTubeChannel) :
            base(YouTubeApplicationId, connectionChannel, receiverChannel, mediaChannel)
        {
            this.youTubeChannel = youTubeChannel ?? throw new ArgumentNullException(nameof(youTubeChannel));            
        }

        public event EventHandler<string> ScreenIdChanged
        {
            add => youTubeChannel.ScreenIdChanged += value;
            remove => youTubeChannel.ScreenIdChanged -= value;
        }

        public Task GetScreenId()
        {
            return youTubeChannel.GetScreenId(DefaultIdentifiers.SourceId, TransportId);
        }
    }
}