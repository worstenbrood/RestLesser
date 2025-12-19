using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XmlaPermissions
    {
        Off,
        Readonly
    }

    public class GenerateTokenRequestV2Dataset
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "xmlaPermissions")]
        public XmlaPermissions XmlaPermissions { get; set; }
    }

    public class GenerateTokenRequestV2Report
    {
        [JsonProperty(PropertyName = "allowEdit")]
        public bool AllowEdit { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
    }

    public class GenerateTokenRequestV2TargetWorkspace
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
    }

    public class GenerateTokenRequestV2
    {
        [JsonProperty(PropertyName = "datasets")]
        public GenerateTokenRequestV2Dataset[]? Datasets { get; set; }

        [JsonProperty(PropertyName = "datasourceIdentities")]
        public DatasourceIdentity[]? DatasourceIdentities { get; set; }

        [JsonProperty(PropertyName = "identities")]
        public EffectiveIdentity[]? Identities { get; set; }

        [JsonProperty(PropertyName = "lifetimeInMinutes")]
        public int LifetimeInMinutes { get; set; }

        [JsonProperty(PropertyName = "reports")]
        public GenerateTokenRequestV2Report[]? Reports { get; set; }

        [JsonProperty(PropertyName = "workspaces")]
        public GenerateTokenRequestV2TargetWorkspace[]? Workspaces { get; set; }
    }
}
