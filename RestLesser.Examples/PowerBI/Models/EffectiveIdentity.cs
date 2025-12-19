using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class IdentityBlob
    {
        [JsonProperty(PropertyName = "value")]
        public string? Value { get; set; }
    }

    public class EffectiveIdentity
    {
        [JsonProperty(PropertyName = "customData")]
        public string? CustomData { get; set; }

        [JsonProperty(PropertyName = "datasets")]
        public string[]? Datasets { get; set; }

        [JsonProperty(PropertyName = "identityBlob")]
        public IdentityBlob? IdentityBlob { get; set; }

        [JsonProperty(PropertyName = "reports")]
        public string[]? Reports { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public string[]? Roles { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string? Username { get; set; }
    }
}
