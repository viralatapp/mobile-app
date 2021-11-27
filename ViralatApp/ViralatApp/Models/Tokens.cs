using Newtonsoft.Json;

namespace ViralatApp.Models
{
    public class Tokens
    {
        [JsonProperty("access")]
        public Access Access { get; set; }

        [JsonProperty("refresh")]
        public Refresh Refresh { get; set; }
    }
}