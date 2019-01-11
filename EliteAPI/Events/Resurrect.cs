namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ResurrectInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Option")]
        public string Option { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; set; }
    }

    public partial class ResurrectInfo
    {
        public static ResurrectInfo Process(string json) => EventHandler.InvokeResurrectEvent(JsonConvert.DeserializeObject<ResurrectInfo>(json, EliteAPI.Events.ResurrectConverter.Settings));
    }

    public static class ResurrectSerializer
    {
        public static string ToJson(this ResurrectInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ResurrectConverter.Settings);
    }

    internal static class ResurrectConverter
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
