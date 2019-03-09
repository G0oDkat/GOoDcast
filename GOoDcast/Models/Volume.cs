namespace GOoDcast.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Volume
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// Gets or sets the volume level
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the audio is muted
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Muted { get; set; }

        /// <summary>
        /// Gets or sets the step interval
        /// </summary>
        public float StepInterval { get; set; }
    }
}