namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PreviousRequest : MediaRequest
    {
        public PreviousRequest(long mediaSessionId, int? requestId = null)
            : base("PREVIOUS", mediaSessionId, requestId)
        {
        }
    }
}