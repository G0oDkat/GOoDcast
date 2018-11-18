namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LaunchRequest : RequestWithId
    {
        public LaunchRequest(string appId, int? requestId = null)
            : base("LAUNCH", requestId)
        {
            ApplicationId = appId;
        }

        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }
    }
}