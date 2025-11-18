using Newtonsoft.Json;

namespace RestLesser.Examples.TvMaze.Models
{
    // https://www.tvmaze.com/api#show-main-information

    public class Show
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }
    }
}
