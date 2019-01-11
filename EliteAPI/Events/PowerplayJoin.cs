namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayJoinInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }
    }

    public partial class PowerplayJoinInfo
    {
        public static PowerplayJoinInfo Process(string json) => EventHandler.InvokePowerplayJoinEvent(JsonConvert.DeserializeObject<PowerplayJoinInfo>(json, EliteAPI.Events.PowerplayJoinConverter.Settings));
    }

    public static class PowerplayJoinSerializer
    {
        public static string ToJson(this PowerplayJoinInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayJoinConverter.Settings);
    }

    internal static class PowerplayJoinConverter
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
