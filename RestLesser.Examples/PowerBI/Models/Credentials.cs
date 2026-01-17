using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class NameValue(string name, string value)
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = name;

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = value;
    }

    public class Credentials
    {
        [JsonProperty(PropertyName = "credentialData")]
        public NameValue[]? CredentialData { get; set; }
    }
}
