using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class Group
    {
        [JsonProperty(PropertyName = "capacityId")]
        public string? CapacityId { get; set; }

        [JsonProperty(PropertyName = "dataflowStorageId")]
        public string? DataflowStorageId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "isOnDedicatedCapacity")]
        public bool IsOnDedicatedCapacity { get; set; }

        [JsonProperty(PropertyName = "IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
    }

    public class Groups
    {
        [JsonProperty(PropertyName = "value")]
        public Group[]? Value { get; set; }
    }
}
