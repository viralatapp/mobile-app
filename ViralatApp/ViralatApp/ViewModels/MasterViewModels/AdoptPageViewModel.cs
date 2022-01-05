using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class AdoptPageViewModel : BaseViewModel,IInitialize
    {
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SubmitPageCommand { get; set; }
        public Pet Pet { get; set; }
        public User CurrentUser { get; set; }
        public User PetOwner { get; set; }
        public UserValidator User { get; set; }
        public Refuge Refuge { get; set; }
        public ObservableCollection<Questionnaire> Questions { get; set; }
        public DelegateCommand SummitCommand { get; set; }
        public AdoptPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            User = new UserValidator();
            CancelCommand = new DelegateCommand( async ()=>await Cancel());
            SubmitPageCommand = new DelegateCommand(async () => await Summit());
        }

        void LoadData()
        {

            Questions = new ObservableCollection<Questionnaire>()
            {
                new Questionnaire()
                {
                    Question = "¿Dónde viviría la mascota?",
                },
                new Questionnaire()
                {
                    Question = "¿Se compromete a darle el cuidado requerido?",
                },
            };
        }

       async Task Summit()
        {
            if (User.IsValid)
            {
                var adoption = await ApiService.CreateAdoptions(new RequestAdoption()
                {
                    Active = true,
                    User = Settings.UserId,
                    Pet = Pet.Id
                });
                await ApiService.CreateApplication(new ApplicationAdopt()
                {
                    Adoption = adoption.Id,
                    User = Settings.UserId,
                    Questions = Questions.ToList()
                });
                await dialogService.DisplayAlertAsync("Exito!", "Solicitud de adopción enviada satisfactoriamente.", "OK");
                await navigationService.GoBackAsync();
            }
        }
       
        async Task Cancel()
        {
          await navigationService.GoBackAsync();
        }

        public async void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(nameof(Pet)))
            {
                Pet = parameters[nameof(Pet)] as Pet;
            }
            CurrentUser = await ApiService.GetUserById(Settings.UserId);
            PetOwner = CurrentUser;
            //PetOwner real data disabled because of unknown error.
            //PetOwner = await ApiService.GetUserById(Pet.User);

            LoadData();
        }
    }
}
