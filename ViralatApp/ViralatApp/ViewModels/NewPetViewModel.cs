using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class NewPetViewModel : BaseViewModel
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public string Address { get; set; }
        public DelegateCommand CreatePetCommand { get; set; }
        public NewPetViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            CreatePetCommand = new DelegateCommand(async () => await RunSave(CreatePet()));
        }

       async Task CreatePet()
       {
         await  ApiService.CreatePet(new Pet()
           {
               Age = Age,
               Weight = Weight,
               Name = Name,
               Address = Address,
               Breed = Breed,
               Description = Description,
               Type = Type,
               Sex = IsFemale?"Female":"Male"
           });
         
         await navigationService.GoBackAsync();
       }
    }
}
