using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportState
    {
        Failed,
        Publishing,
        Succeeded,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportConflictHandlerMode
    {
        Abort,
        CreateOrOverwrite,
        GenerateUniqueName,
        Ignore,
        Overwrite
    }

    public class Import
    {
        [JsonProperty(PropertyName = "createdDateTime")]
        public string? CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "datasets")]
        public Dataset[]? Datasets { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "importState")]
        public ImportState ImportState { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "reports")]
        public Report[]? Reports { get; set; }

        [JsonProperty(PropertyName = "updatedDateTime")]
        public string? UpdatedDateTime { get; set; }
    }
}
