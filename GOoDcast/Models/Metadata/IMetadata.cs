namespace GOoDcast.Models.Metadata
{
    using System.Collections.Generic;
    using Enums;
    using JsonConverters;
    using MediaStatus;
    using Newtonsoft.Json;

    public interface IMetadata
    {
        List<ChromecastImage> images { get; set; }
        [JsonConverter(typeof(MetadataTypeEnumConverter))]
        MetadataTypeEnum metadataType { get; set; }
        string title { get; set; }
    }
}
