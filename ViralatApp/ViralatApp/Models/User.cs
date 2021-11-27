using Newtonsoft.Json;

namespace ViralatApp.Models
{
    public class User
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("isEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public string Password { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}