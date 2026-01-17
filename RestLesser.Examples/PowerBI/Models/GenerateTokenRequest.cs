using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TokenAccessLevel
    {
        Create,
        Edit,
        View
    }

    public class GenerateTokenRequest
    {
        [JsonProperty(PropertyName = "accessLevel")]
        public TokenAccessLevel AccessLevel { get; set; }

        [JsonProperty(PropertyName = "allowSaveAs")]
        public bool AllowSaveAs { get; set; }

        [JsonProperty(PropertyName = "datasetId")]
        public string? DatasetId { get; set; }

        [JsonProperty(PropertyName = "identities")]
        public EffectiveIdentity[]? Identities { get; set; }

        [JsonProperty(PropertyName = "lifetimeInMinutes")]
        public int LifetimeInMinutes { get; set; }
    }
}
