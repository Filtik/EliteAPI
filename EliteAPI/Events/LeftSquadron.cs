﻿namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LeftSquadronInfo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }

    public partial class LeftSquadronInfo
    {
        public static LeftSquadronInfo FromJson(string json) => JsonConvert.DeserializeObject<LeftSquadronInfo>(json, EliteAPI.Events.LeftSquadronConverter.Settings);
    }

    public static class LeftSquadronSerializer
    {
        public static string ToJson(this LeftSquadronInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LeftSquadronConverter.Settings);
    }

    internal static class LeftSquadronConverter
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
