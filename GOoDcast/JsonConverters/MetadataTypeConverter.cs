namespace GOoDcast.JsonConverters
{
    using System;
    using Models.Enums;
    using Models.Metadata;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class MetadataTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            string value = jObject.GetValue("metadataType").ToString();

            Enum.TryParse(value, out MetadataTypeEnum metadataType);
            switch (metadataType)
            {
                case MetadataTypeEnum.GENERIC:
                    return jObject.ToObject<GenericMediaMetadata>();
                case MetadataTypeEnum.MOVIE:
                    return jObject.ToObject<MovieMediaMetadata>();
                case MetadataTypeEnum.TV_SHOW:
                    return jObject.ToObject<TvShowMediaMetadata>();
                case MetadataTypeEnum.MUSIC_TRACK:
                    return jObject.ToObject<MusicTrackMediaMetadata>();
                case MetadataTypeEnum.PHOTO:
                    return jObject.ToObject<PhotoMediaMetadata>();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}