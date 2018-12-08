namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public class YouTubeApplication : MediaApplicationBase
    {
        private const string YouTubeApplicationId = "233637DE";
        
        public YouTubeApplication(IReceiverChannel receiverChannel, IMediaChannel mediaChannel) :
            base(YouTubeApplicationId, receiverChannel, mediaChannel)
        {
            //client.Channels.GetYouTubeChannel().ScreenIdChanged += OnScreenIdChanged;
        }

        public Task LoadAsync(string mediaUrl)
        {
            var mediaInformation = new MediaInformation()
            {
                ContentId = mediaUrl,
                ContentType = "video",
                StreamType = StreamType.Buffered,    
                Duration = 0,
                Tracks = null                
            };
            return base.LoadAsync(mediaInformation);
        }
        //public event EventHandler<string> ScreenIdChanged;

        //private void OnScreenIdChanged(object sender, string s)
        //{
        //    ScreenIdChanged?.Invoke(this, s);
        //}
    }
}