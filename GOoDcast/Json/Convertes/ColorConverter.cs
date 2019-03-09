namespace GOoDcast.Json.Convertes
{
    using System;
    using System.Drawing;
    using Miscellaneous;
    using Newtonsoft.Json;

    internal class NullableColorConverter : JsonConverter<Color?>
    {
        public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToHexString());
        }

        public override Color? ReadJson(JsonReader reader, Type objectType, Color? existingValue, bool hasExistingValue,
                                       JsonSerializer serializer)
        {
            return ColorHelper.FromNullableHexString(reader.Value as string);
        }
    }
}