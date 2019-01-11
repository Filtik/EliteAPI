namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ReputationInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Empire")]
        public double Empire { get; set; }

        [JsonProperty("Federation")]
        public double Federation { get; set; }

        [JsonProperty("Independent")]
        public double Independent { get; set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; set; }
    }

    public partial class ReputationInfo
    {
        public static ReputationInfo Process(string json) => EventHandler.InvokeReputationEvent(JsonConvert.DeserializeObject<ReputationInfo>(json, EliteAPI.Events.ReputationConverter.Settings));
    }

    public static class ReputationSerializer
    {
        public static string ToJson(this ReputationInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ReputationConverter.Settings);
    }

    internal static class ReputationConverter
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
