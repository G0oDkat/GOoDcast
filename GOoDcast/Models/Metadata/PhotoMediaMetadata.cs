namespace GOoDcast.Models.Metadata
{
    using System.Collections.Generic;
    using Enums;
    using JsonConverters;
    using MediaStatus;
    using Newtonsoft.Json;

    //Fields: https://developers.google.com/cast/docs/reference/chrome/chrome.cast.media.PhotoMediaMetadata
    public class PhotoMediaMetadata : IMetadata
    {
        public PhotoMediaMetadata()
        {
            metadataType = MetadataTypeEnum.PHOTO;
        }
        public string artist { get; set; }
        public string creationDateTime { get; set; }
        public int height { get; set; }
        public List<ChromecastImage> images { get; set; }
        public int latitude { get; set; }
        public string location { get; set; }
        public int longitude { get; set; }
        [JsonConverter(typeof(MetadataTypeEnumConverter))]
        public MetadataTypeEnum metadataType { get; set; }
        public string title { get; set; }
        public int width { get; set; }
    }
}