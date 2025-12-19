using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class DatasourceSelector
    {
        [JsonProperty(PropertyName = "connectionDetails")]
        public DatasourceConnectionDetails? Datasources { get; set; }

        [JsonProperty(PropertyName = "datasourceType")]
        public string? DatasourceType { get; set; }
    }

    public class DatasourceIdentity
    {
        [JsonProperty(PropertyName = "datasources")]
        public DatasourceSelector[]? Datasources { get; set; }

        [JsonProperty(PropertyName = "identityBlob")]
        public string? IdentityBlob { get; set; }
    }

    public class DatasourceConnectionDetails
    {
        [JsonProperty(PropertyName = "account")]
        public string? Account { get; set; }

        [JsonProperty(PropertyName = "classInfo")]
        public string? ClassInfo { get; set; }

        [JsonProperty(PropertyName = "database")]
        public string? Database { get; set; }

        [JsonProperty(PropertyName = "domain")]
        public string? Domain { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string? EmailAddress { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string? Kind { get; set; }

        [JsonProperty(PropertyName = "loginServer")]
        public string? LoginServer { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string? Path { get; set; }

        [JsonProperty(PropertyName = "server")]
        public string? Server { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string? Url { get; set; }
    }
}
