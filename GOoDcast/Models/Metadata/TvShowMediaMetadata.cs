namespace GOoDcast.Models.Metadata
{
    using System.Collections.Generic;
    using Enums;
    using JsonConverters;
    using MediaStatus;
    using Newtonsoft.Json;

    //Fields: https://developers.google.com/cast/docs/reference/chrome/chrome.cast.media.TvShowMediaMetadata
    public class TvShowMediaMetadata : IMetadata
    {
        public TvShowMediaMetadata()
        {
            metadataType = MetadataTypeEnum.TV_SHOW;
        }
        public int episode { get; set; }
        public List<ChromecastImage> images { get; set; }
        [JsonConverter(typeof(MetadataTypeEnumConverter))]
        public MetadataTypeEnum metadataType { get; set; }
        public string originalAirdate { get; set; }
        public int season { get; set; }
        public string seriesTitle { get; set; }
        public string title { get; set; }
    }
}
