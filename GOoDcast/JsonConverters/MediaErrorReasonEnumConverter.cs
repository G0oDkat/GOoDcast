namespace GOoDcast.JsonConverters
{
    using System;
    using Models.Enums;
    using Newtonsoft.Json;

    public class MediaErrorReasonEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var metadataType = (MediaErrorReasonEnum) value;
            writer.WriteValue(metadataType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            string enumString = (string) reader.Value;

            Enum.TryParse(enumString, out MediaErrorReasonEnum metadataType);

            return metadataType;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}