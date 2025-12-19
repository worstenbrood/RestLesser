using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScheduleNotifyOption
    {
        MailOnFailure,
        NoNotification
    }

    public class RefreshScheduleRequest
    {
        [JsonProperty(PropertyName = "value")]
        public RefreshSchedule? Value { get; set; }
    }

    public class RefreshSchedule
    {
        [JsonProperty(PropertyName = "NotifyOption")]
        public NotifyOption NotifyOption { get; set; }

        [JsonProperty(PropertyName = "days")]
        public string[]? Days { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "localTimeZoneId")]
        public string? LocalTimeZoneId { get; set; }

        [JsonProperty(PropertyName = "times")]
        public string[]? Times { get; set; }
    }
}
