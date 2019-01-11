namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WingAddInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class WingAddInfo
    {
        public static WingAddInfo Process(string json) => EventHandler.InvokeWingAddEvent(JsonConvert.DeserializeObject<WingAddInfo>(json, EliteAPI.Events.WingAddConverter.Settings));
    }

    public static class WingAddSerializer
    {
        public static string ToJson(this WingAddInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.WingAddConverter.Settings);
    }

    internal static class WingAddConverter
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
