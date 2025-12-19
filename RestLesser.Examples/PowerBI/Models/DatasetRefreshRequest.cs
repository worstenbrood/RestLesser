using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotifyOption
    {
        MailOnCompletion,
        MailOnFailure,
        NoNotification
    }

    public class DatasetRefreshRequest
    {
        [JsonProperty(PropertyName = "notifyOption")]
        public NotifyOption NotifyOption { get; set; }
    }
}
