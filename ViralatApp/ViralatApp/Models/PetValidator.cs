using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ViralatApp.Annotations;
using ViralatApp.Helpers;
using ViralatApp.Helpers.ValidationRules;

namespace ViralatApp.Models
{
    public class PetValidator:INotifyPropertyChanged
    {

        public ValidatableObject<string> Type { get; set; }


        public ValidatableObject<string> Breed { get; set; }


        public List<string> Images { get; set; }

        public ValidatableObject<string> User { get; set; }

        public ValidatableObject<string>  Name { get; set; }

        public ValidatableObject<int>  Age { get; set; }

        public ValidatableObject<int>  Weight { get; set; }

        public ValidatableObject<string>  Description { get; set; }

        public ValidatableObject<string>  Sex { get; set; }

        public ValidatableObject<string>  Address { get; set; }

        public PetValidator()
        {
            Name = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            User = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Sex = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Description = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Breed = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Type = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
        }
        public bool IsValid { get=>Type.IsValid&&User.IsValid&&Name.IsValid&&Age.IsValid&&Weight.IsValid&&Description.IsValid&&Sex.IsValid&&Address.IsValid&&Breed.IsValid;  }

        public event PropertyChangedEventHandler PropertyChanged;
        public  Pet CreatePet()
        {
            return new Pet()
            {
                Images = Images,
                User = User.Value,
                Age = Age.Value,
                Weight = Weight.Value,
                Description = Description.Value,
                Sex = Sex.Value,
                Address = Address.Value,
                Type = Type.Value,
                Breed = Breed.Value
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}