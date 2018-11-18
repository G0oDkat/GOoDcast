namespace GOoDcast.Models.MediaStatus
{
    using System.Collections.Generic;

    public class MediaStatusResponse
    {
        public string type { get; set; }
        public List<MediaStatus> status { get; set; }
        public int requestId { get; set; }
    }
}