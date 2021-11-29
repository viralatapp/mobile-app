using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ViralatApp.Annotations;

namespace ViralatApp.Models
{
    public class User:INotifyPropertyChanged
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
        public string Phone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        [JsonIgnore]
        public List<string> AdoptionHistory { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}