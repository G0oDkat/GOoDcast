namespace GOoDcast.Messages.YouToube
{
    using Newtonsoft.Json;

    internal class GetScreenIdMessage
    {
        public GetScreenIdMessage()
        {
            Type = "TYPE_GET_SCREEN_ID";
        }

        [JsonProperty(PropertyName= "MESSAGE_TYPE")]
        public string Type { get; set; }
    }
}