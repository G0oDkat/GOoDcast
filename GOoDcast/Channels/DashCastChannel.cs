namespace GOoDcast.Channels
{
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Miscellaneous;

    public class DashCastChannel : ChromecastChannel, IDashCastChannel
    {
        public DashCastChannel(IChromecastClient client) : base(client, "urn:x-cast:es.offd.dashcast")
        {            
        }

        public Task LoadUrl(string sourceId, string destinationId, string url)
        {

            return base.SendAsync(sourceId, destinationId,
                                  new DashCastMessage()
                                  {
                                      Url = url,
                                      Force = false,
                                      Reload = false,
                                      ReloadTime = 0
                                  });

        }

        [DataContract]
        class DashCastMessage
        {
            [DataMember(Name = "url")]
            public string Url { get; set; }

            [DataMember(Name = "force")]
            public bool Force { get; set; }

            [DataMember(Name = "reload")]
            public bool Reload { get; set; }

            [DataMember(Name = "reload_time")]
            public int ReloadTime { get; set; }
        }
    }
}