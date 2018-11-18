namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PingRequest : Request
    {
        public PingRequest()
            : base("PING")
        {
        }
    }
}