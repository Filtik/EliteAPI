namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WingLeaveInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class WingLeaveInfo
    {
        public static WingLeaveInfo Process(string json) => EventHandler.InvokeWingLeaveEvent(JsonConvert.DeserializeObject<WingLeaveInfo>(json, EliteAPI.Events.WingLeaveConverter.Settings));
    }

    public static class WingLeaveSerializer
    {
        public static string ToJson(this WingLeaveInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.WingLeaveConverter.Settings);
    }

    internal static class WingLeaveConverter
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
