namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PauseRequest : MediaRequest
    {
        public PauseRequest(long mediaSessionId, int? requestId = null)
            : base("PAUSE", mediaSessionId, requestId)
        {
        }
    }
}