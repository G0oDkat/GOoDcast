namespace GOoDcast.Messages.YouToube
{
    using System.Runtime.Serialization;

    [DataContract]
    internal class LoadVideoMessage
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }


        [DataMember(Name = "data")]
        public VideoData Data { get; set; }

        //[DataMember(Name = "requestId")]
        //public int RequestId { get; set; }
    }

    [DataContract]
    internal class VideoData
    {
        [DataMember(Name = "currentTime")]
        public int CurrentTime { get; set; }

        [DataMember(Name = "videoId")]
        public string VideoId { get; set; }
    }
}