namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FSDTargetInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }
    }

    public partial class FSDTargetInfo
    {
        public static FSDTargetInfo Process(string json) => EventHandler.InvokeFSDTargetEvent(JsonConvert.DeserializeObject<FSDTargetInfo>(json, EliteAPI.Events.FSDTargetConverter.Settings));
    }

    public static class FSDTargetSerializer
    {
        public static string ToJson(this FSDTargetInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSDTargetConverter.Settings);
    }

    internal static class FSDTargetConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
