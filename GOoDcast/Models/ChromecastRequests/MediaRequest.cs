namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    public class MediaRequest : RequestWithId
    {
        public MediaRequest(string requestType, long mediaSessionId, int? requestId = null) : base(requestType, requestId)
        {
            MediaSessionId = mediaSessionId;
        }

        [DataMember(Name = "mediaSessionId")]
        public long MediaSessionId { get; set; }
    }
}
