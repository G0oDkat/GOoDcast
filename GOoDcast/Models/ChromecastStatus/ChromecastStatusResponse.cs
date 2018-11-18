namespace GOoDcast.Models.ChromecastStatus
{
    using Newtonsoft.Json;

    public class ChromecastStatusResponse
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("status")]
        public ChromecastStatus ChromecastStatus { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}