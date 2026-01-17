using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class CloneReport
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "targetModelId")]
        public string? TargetModelId { get; set; }

        [JsonProperty(PropertyName = "targetWorkspaceId")]
        public string? TargetWorkspaceId { get; set; }
    }
}
