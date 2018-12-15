//namespace GOoDcast.JsonConverters
//{
//    using System;
//    using Models.ChromecastRequests;
//    using Newtonsoft.Json;

//    public class StreamTypeConverter : JsonConverter
//    {
//        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//        {
//            var streamType = (StreamType) value;
//            switch (streamType)
//            {
//                case StreamType.BUFFERED:
//                    writer.WriteValue("BUFFERED");
//                    break;
//                case StreamType.LIVE:
//                    writer.WriteValue("LIVE");
//                    break;
//                case StreamType.NONE:
//                    writer.WriteValue("NONE");
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException();
//            }
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
//                                        JsonSerializer serializer)
//        {
//            string enumString = (string) reader.Value;

//            Enum.TryParse(enumString, out StreamType streamType);

//            return streamType;
//        }

//        public override bool CanConvert(Type objectType)
//        {
//            return objectType == typeof(string);
//        }
//    }
//}