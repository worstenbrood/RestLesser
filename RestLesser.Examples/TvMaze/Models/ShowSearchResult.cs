using Newtonsoft.Json;

namespace RestLesser.Examples.TvMaze.Models
{
    public class ShowSearchResult
    {
        [JsonProperty("score")]
        public decimal? Score { get; set; }

        [JsonProperty("show")]
        public Show? Show { get; set; }
    }
}
