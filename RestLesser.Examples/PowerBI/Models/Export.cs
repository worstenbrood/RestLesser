using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExportState
    {
        Failed,
        NotStarted,
        Running,
        Succeeded,
        Undefined
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileFormat
    {
        ACCESSIBLEPDF,
        CSV,
        DOCX,
        IMAGE,
        MHTML,
        PDF,
        PNG,
        PPTX,
        XLSX,
        XML
    }

    public class Export
    {
        [JsonProperty(PropertyName = "ResourceFileExtension")]
        public string? ResourceFileExtension { get; set; }

        [JsonProperty(PropertyName = "createdDateTime")]
        public string? CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "expirationTime")]
        public string? ExpirationTime { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "lastActionDateTime")]
        public string? LastActionDateTime { get; set; }

        [JsonProperty(PropertyName = "percentComplete")]
        public int PercentComplete { get; set; }

        [JsonProperty(PropertyName = "reportId")]
        public string? ReportId { get; set; }

        [JsonProperty(PropertyName = "reportName")]
        public string? ReportName { get; set; }

        [JsonProperty(PropertyName = "resourceLocation")]
        public string? ResourceLocation { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ExportState Status { get; set; }
    }

    public class ExportRequest
    {
        [JsonProperty(PropertyName = "fileFormat")]
        public FileFormat FileFormat { get; set; }
    }
}
