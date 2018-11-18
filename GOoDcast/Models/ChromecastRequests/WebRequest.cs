namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class WebRequest : RequestWithId 
    {
        public WebRequest(string appId, string strUrl, string type) : base(type)
        {
            ApplicationId = appId;
            Url = strUrl;
        }

        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
