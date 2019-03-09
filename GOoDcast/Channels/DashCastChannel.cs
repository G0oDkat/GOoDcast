namespace GOoDcast.Channels
{
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Messages.DashCast;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    public class DashCastChannel : JsonPayloadChannel, IDashCastChannel
    {
        public DashCastChannel(IChromecastClient client) : base(client, "urn:x-cast:es.offd.dashcast")
        {            
        }

        public Task LoadUrl(string sourceId, string destinationId, string url)
        {

            return base.SendAsync(sourceId, destinationId,
                                  new DashCastMessage
                                  {
                                      Url = url,
                                      Force = false,
                                      Reload = false,
                                      ReloadTime = 0
                                  });

        }

        protected override Task OnMessageReceivedAsync(string sourceId, string destinationId, JObject payload)
        {
            return Task.CompletedTask;
        }
    }
}