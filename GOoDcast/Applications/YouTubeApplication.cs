namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;
    using Models.Media;

    public class YouTubeApplication : MediaApplicationBase
    {
        private const string YouTubeApplicationId = "233637DE";

        private readonly IYouTubeChannel youTubeChannel;

        public YouTubeApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                                  IMediaChannel mediaChannel, IYouTubeChannel youTubeChannel) :
            base(YouTubeApplicationId, connectionChannel, receiverChannel, mediaChannel)
        {
            this.youTubeChannel = youTubeChannel;
            //client.Channels.GetYouTubeChannel().ScreenIdChanged += OnScreenIdChanged;
        }


        public Task LoadVideoAsync(string videoId)
        {
           return youTubeChannel.LoadVideo(DefaultIdentifiers.SourceId, TransportId, videoId);
        }

        //public Task LoadAsync(string mediaUrl)
        //{
        //    var mediaInformation = new MediaInformation
        //    {
        //        ContentId = mediaUrl,
        //        ContentType = "x-youtube/video",
        //        StreamType = StreamType.Buffered
        //    };
        //    return base.LoadAsync(mediaInformation);
        //}
        //public event EventHandler<string> ScreenIdChanged;

        //private void OnScreenIdChanged(object sender, string s)
        //{
        //    ScreenIdChanged?.Invoke(this, s);
        //}
    }
}