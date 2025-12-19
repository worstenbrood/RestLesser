using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class Datasource
    {
        [JsonProperty(PropertyName = "connectionDetails")]
        public DatasourceConnectionDetails? ConnectionDetails { get; set; }

        [JsonProperty(PropertyName = "datasourceId")]
        public string? DatasourceId { get; set; }

        [JsonProperty(PropertyName = "datasourceType")]
        public string? DatasourceType { get; set; }

        [JsonProperty(PropertyName = "gatewayId")]
        public string? GatewayId { get; set; }
    }

    public class Datasources
    {
        [JsonProperty(PropertyName = "value")]
        public Datasource[]? Value { get; set; }
    }
}
