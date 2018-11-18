namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PlayRequest : MediaRequest
    {
        public PlayRequest(long mediaSessionId, int? requestId = null)
            : base("PLAY", mediaSessionId, requestId)
        {
        }
    }
}