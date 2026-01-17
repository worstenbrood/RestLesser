using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class Report
    {
        [JsonProperty(PropertyName = "datasetId")]
        public string? DatasetId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "webUrl")]
        public string? WebUrl { get; set; }

        [JsonProperty(PropertyName = "embedUrl")]
        public string? EmbedUrl { get; set; }
    }

    public class Reports
    {
        [JsonProperty(PropertyName = "value")]
        public Report[]? Value { get; set; }
    }
}
