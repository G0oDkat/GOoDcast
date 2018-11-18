namespace SharpCaster.Controllers
{
    using System.Threading.Tasks;
    using GOoDcast.Applications;
    using GOoDcast.Channels;

    public class YouTubeApplication : MediaApplicationBase
    {
        //public event EventHandler<string> ScreenIdChanged;
        public YouTubeApplication(ReceiverChannel receiverChannel, MediaChannel mediaChannel) :
            base("233637DE", receiverChannel, mediaChannel)
        {
            //client.Channels.GetYouTubeChannel().ScreenIdChanged += OnScreenIdChanged;
        }

        //private void OnScreenIdChanged(object sender, string s)
        //{
        //    ScreenIdChanged?.Invoke(this, s);
        //}
    }

    public static class YouTubeControllerExtensions
    {
        public static async Task<YouTubeController> LaunchYouTube(this ChromeCastClient client)
        {
            client.MakeSureChannelExist(new YouTubeChannel(client));
            var controller = new YouTubeController(client);
            await controller.LaunchApplication();
            return controller;
        }
    }
}