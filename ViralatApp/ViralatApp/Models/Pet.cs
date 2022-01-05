using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ViralatApp.Annotations;

namespace ViralatApp.Models
{
    public class Pet:INotifyPropertyChanged
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("breed")]
        public string Breed { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public string Image => Images?.FirstOrDefault();
        [JsonIgnore]
        public bool IsFavorite { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class PetResponse
    {
        [JsonProperty("results")]
        public List<Pet> Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
    }
    public class Adoption
    {
        public string Id { get; set; }
    }

    public class RequestAdoption
    {
        public bool Active { get; set; } 
        public string User { get; set; }
        public string Pet { get; set; }
    }

    public class ApplicationAdopt
    {
        [JsonProperty("user")] public string User { get; set; }

        [JsonProperty("adoption")] public string Adoption { get; set; }

        [JsonProperty("questions")] public List<Questionnaire> Questions { get; set; }
    }

    public class Questionnaire:INotifyPropertyChanged
    {
        [JsonProperty("question")] public string Question { get; set; }

        [JsonProperty("answer")] public string Answer { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
