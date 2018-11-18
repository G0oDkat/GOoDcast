namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    public class SeekRequest : MediaRequest
    {
        public SeekRequest(long mediaSessionId, double seconds, int? requestId = null) 
            : base("SEEK", mediaSessionId,requestId)
        {
            CurrentTime = seconds;
        }

        [DataMember(Name = "currentTime")] public double CurrentTime { get; set; }
    }
}