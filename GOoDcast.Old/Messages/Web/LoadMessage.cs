namespace GOoDcast.Messages.Web
{
    using System.Runtime.Serialization;

    internal class IframeMessage : MessageWithId
    {
        public IframeMessage(string applicationId, string url)
        {
            ApplicationId = applicationId;
            Url = url;
        }

        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}