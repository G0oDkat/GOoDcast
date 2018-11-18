namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GetAppAvailabilityRequest : RequestWithId
    {
        public GetAppAvailabilityRequest(string[] appIds)
            : base("GET_APP_AVAILABILITY")
        {
            ApplicationId = appIds;
        }

        [DataMember(Name = "appId")]
        public string[] ApplicationId { get; set; }
    }
}