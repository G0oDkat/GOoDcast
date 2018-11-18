namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StopApplicationRequest : RequestWithId
    {
        public StopApplicationRequest(string sessionId, int? requestId = null)
            : base("STOP", requestId)
        {
            SessionId = sessionId;
        }

        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }
}