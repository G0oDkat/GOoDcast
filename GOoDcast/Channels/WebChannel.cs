namespace GOoDcast.Channels
{
    using System.Threading.Tasks;
    using Messages.Web;

    public class WebChannel : ChromecastChannel, IWebChannel
    {
        public WebChannel(IChromecastClient client) : base(client, "urn:x-cast:com.url.cast")
        {
        }

        public Task LoadUrl(string sourceId, string destinationId, string applicationId, string url)
        {
            var message = new IframeMessage(applicationId, url);

            return SendAsync(sourceId, destinationId, message);
        }

        public override Task OnMessageReceivedAsync(string sourceId, string destinationId, string payload)
        {
            return Task.CompletedTask;
        }
    }
}