using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class MashupParameter
    {
        [JsonProperty(PropertyName = "currentValue")]
        public string? CurrentValue { get; set; }

        [JsonProperty(PropertyName = "isRequired")]
        public bool IsRequired { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "suggestedValues")]
        public string[]? SuggestedValues { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }
    }

    public class MashupParameters
    {
        [JsonProperty(PropertyName = "value")]
        public MashupParameter[]? Value { get; set; }
    }
}
