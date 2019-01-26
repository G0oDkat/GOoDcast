namespace GOoDcast.Applications
{
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;

    public class WebApplication : ApplicationBase
    {
        private const string WebApplicationId = "5CB45E5A";

        private readonly IWebChannel webChannel;

        public WebApplication(IConnectionChannel connectionChannel, IReceiverChannel receiverChannel,
                              IWebChannel webChannel) : base(WebApplicationId, connectionChannel, receiverChannel)
        {
            this.webChannel = webChannel;
        }

        public Task LoadUrl(string url)
        {
            return webChannel.LoadUrl(DefaultIdentifiers.SourceId, TransportId, WebApplicationId, url);
        }
    }
}