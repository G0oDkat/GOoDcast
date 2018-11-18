namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CloseRequest : Request
    {
        public CloseRequest()
            : base("CLOSE")
        {
        }
    }
}