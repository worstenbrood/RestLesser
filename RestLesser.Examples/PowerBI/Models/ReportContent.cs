using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class SourceReport
    {
        [JsonProperty(PropertyName = "sourceReportId")]
        public string? SourceReportId { get; set; }

        [JsonProperty(PropertyName = "sourceWorkspaceId")]
        public string? SourceWorkspaceId { get; set; }
    }

    public class ReportContent
    {
        [JsonProperty(PropertyName = "sourceReport")]
        public SourceReport? SourceReport { get; set; }

        [JsonProperty(PropertyName = "sourceType")]
        public string? SourceType { get; set; }
    }
}
