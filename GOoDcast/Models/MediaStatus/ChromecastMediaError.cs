﻿namespace GOoDcast.Models.MediaStatus
{
    using Enums;
    using JsonConverters;
    using Newtonsoft.Json;

    //
    // https://developers.google.com/cast/docs/reference/messages#LoadFailed
    // https://developers.google.com/cast/docs/reference/messages#LoadCancelled
    // https://developers.google.com/cast/docs/reference/messages#InvalidRequest
    //
    public class ChromecastMediaError
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(MediaErrorTypeEnumConverter))]
        public MediaErrorTypeEnum MediaErrorType { get; set; }
        [JsonProperty("reason")]
        [JsonConverter(typeof(MediaErrorReasonEnumConverter))]
        public MediaErrorReasonEnum? Reason { get; set; }
        [JsonProperty("customData")]
        public object CustomData { get; set; }
    }


}
