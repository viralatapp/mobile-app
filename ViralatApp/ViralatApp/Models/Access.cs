using System;
using Newtonsoft.Json;

namespace ViralatApp.Models
{
    public class Access
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
}