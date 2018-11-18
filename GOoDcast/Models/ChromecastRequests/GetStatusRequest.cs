namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GetStatusRequest : RequestWithId
    {
        public GetStatusRequest(int? requestId = null)
            : base("GET_STATUS", requestId)
        {
        }
    }
}