namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [DataContract]
    public abstract class Request
    {
        protected Request(string requestType)
        {
            RequestType = requestType;

        }

        [DataMember(Name = "type")]
        public string RequestType { get; set; }
    }
}