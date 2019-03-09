namespace GOoDcast.Messages.DashCast
{
    using Json;
    using Json.NamingStrategies;
    using Newtonsoft.Json;

    [JsonObject(NamingStrategyType = typeof(UnderscoreLowerInvariantNamingStrategy))]
    internal class DashCastMessage
    {
        public string Url { get; set; }

        public bool Force { get; set; }

        public bool Reload { get; set; }

        public int ReloadTime { get; set; }
    }
}