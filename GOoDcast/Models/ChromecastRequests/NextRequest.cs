namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class NextRequest : MediaRequest
    {
        public NextRequest(long mediaSessionId, int? requestId = null)
            : base("NEXT", mediaSessionId, requestId)
        {
        }
    }
}