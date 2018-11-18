namespace GOoDcast.Models.CustomTypes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class YouTubeSessionStatusResponse
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "data")]
        public YouTubeSessionStatusDataResponse Data { get; set; }

    }
    [DataContract]
    public class YouTubeSessionStatusDataResponse
    {
        [DataMember(Name = "screenId")]
        public string ScreenId { get; set; }
    }
}
