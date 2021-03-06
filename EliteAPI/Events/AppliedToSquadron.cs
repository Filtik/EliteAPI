namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AppliedToSquadronInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }

    public partial class AppliedToSquadronInfo
    {
        public static AppliedToSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAppliedToSquadronEvent(JsonConvert.DeserializeObject<AppliedToSquadronInfo>(json, EliteAPI.Events.AppliedToSquadronConverter.Settings));
    }

    public static class AppliedToSquadronSerializer
    {
        public static string ToJson(this AppliedToSquadronInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.AppliedToSquadronConverter.Settings);
    }

    internal static class AppliedToSquadronConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
