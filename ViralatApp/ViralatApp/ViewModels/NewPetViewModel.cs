using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class NewPetViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

        public ICommand CreatePetCommand { get; }

        public NewPetViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            CreatePetCommand = new Command(async () => await RunSave(CreatePet()));
        }

        public async Task CreatePet()
        {
            PetForm newPet = new PetForm();
            /*
            newPet.User = Settings.UserId;
            newPet.Name = Name;
            newPet.Age = Age;
            newPet.Weight = Weight;
            newPet.Description = Description;
            newPet.Type = Type;
            newPet.Breed = Breed;
            newPet.Sex = Sex;
            newPet.Address = Address;
            */

            newPet.User = Settings.UserId;//"619c4486e22783001e88548a";
            newPet.Name = "Fido Dido";
            newPet.Age = 3;
            newPet.Weight = 80;
            newPet.Description = "Perrito jugueton";
            newPet.Type = "dog";
            newPet.Breed = "salchicha";
            newPet.Sex = "male";
            newPet.Address = "Calle 17";
            await ApiService.CreatePet(newPet);
        }
    }
}
