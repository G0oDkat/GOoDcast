namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PongRequest : Request
    {
        public PongRequest()
            : base("PONG")
        {
        }
    }
}