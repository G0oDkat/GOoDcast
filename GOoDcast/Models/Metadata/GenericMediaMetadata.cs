namespace GOoDcast.Models.Metadata
{
    using System.Collections.Generic;
    using Enums;
    using JsonConverters;
    using MediaStatus;
    using Newtonsoft.Json;

    //Fields: https://developers.google.com/cast/docs/reference/chrome/chrome.cast.media.GenericMediaMetadata
    public class GenericMediaMetadata : IMetadata
    {
        public List<ChromecastImage> images { get; set; }
        [JsonConverter(typeof(MetadataTypeEnumConverter))]
        public MetadataTypeEnum metadataType { get; set; }
        public string releaseDate { get; set; }
        public string subtitle { get; set; }
        public string title { get; set; }
    }
}