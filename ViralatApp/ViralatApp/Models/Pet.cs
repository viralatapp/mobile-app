using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViralatApp.Models
{
    public class Pet
    {
        public string Id { get; set; }   
        public string Name { get; set; }
        public string Race { get; set; }
        public EGender Gender { get; set; }
        public string Image { get; set; }
        public bool IsAdult { get; set; }
    }

    public class Adoption
    {

    }

    public class RequestAdoption
    {
        public User User { get; set; }
        public Pet Pet { get; set; }
    }

    public class ApplicationAdopt
    {
        [JsonProperty("user")] public User User { get; set; }

        [JsonProperty("adoption")] public Adoption Adoption { get; set; }

        [JsonProperty("questions")] public List<Questionnaire> Questions { get; set; }
    }

    public class Questionnaire
    {
        [JsonProperty("question")] public string Question { get; set; }

        [JsonProperty("answer")] public string Answer { get; set; }
    }

}
