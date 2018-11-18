namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MediaStatusRequest : RequestWithId

    {
        public MediaStatusRequest(int? requestId = null) : base("GET_STATUS", requestId)
        {
        }
    }
}
