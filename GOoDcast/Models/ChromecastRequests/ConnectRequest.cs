namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ConnectRequest : Request
    {
        public ConnectRequest()
            : base("CONNECT")
        {
        }
    }
}