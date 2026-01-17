using Newtonsoft.Json;

namespace RestLesser.Examples.ExactOnline.Models
{
    public class ErrorMessage
    {
        [JsonProperty("lang")]
        public string? Language { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("message")]
        public ErrorMessage? Message { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("error")]
        public Error? Error { get; set; }
    }
}
