namespace GOoDcast.Channels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Messages.Web;
    using Models;
    using Newtonsoft.Json.Linq;

    public class WebChannel : ChromecastChannel, IWebChannel
    {
        public WebChannel(IChromecastClient client) : base(client, "urn:x-cast:com.url.cast")
        {
        }

        public Task LoadUrl(string applicationId, string destinationId, string url)
        {
            var message = new IframeMessage(applicationId, url);
           
            return SendAsync(message,destinationId);
        }

        public override Task OnPushMessageReceivedAsync(JObject rawMessage)
        {
            return Task.CompletedTask;
        }
    }
}
