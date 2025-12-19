using Newtonsoft.Json;

namespace RestLesser.Examples.PowerBI.Models
{
    public class EmbedToken
    {
        [JsonProperty(PropertyName = "expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }

        [JsonProperty(PropertyName = "tokenId")]
        public string? TokenId { get; set; }
    }
}
