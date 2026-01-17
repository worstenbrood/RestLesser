using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class Dataset
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
    }
    public class Datasets
    {
        [JsonProperty(PropertyName = "value")]
        public Dataset[]? Value { get; set; }
    }
}
