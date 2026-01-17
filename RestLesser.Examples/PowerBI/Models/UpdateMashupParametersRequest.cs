using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class UpdateMashupParametersRequest
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "newValue")]
        public string? NewValue { get; set; }
    }

    public class UpdateMashupParameterDetails
    {
        [JsonProperty(PropertyName = "updateDetails")]
        public UpdateMashupParametersRequest[]? UpdateDetails { get; set; }
    }
}
