using Newtonsoft.Json;

namespace ViralatApp.Models
{
    public class AuthenticationResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("tokens")]
        public Tokens Tokens { get; set; }
    }
    public class RequestLogin
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}