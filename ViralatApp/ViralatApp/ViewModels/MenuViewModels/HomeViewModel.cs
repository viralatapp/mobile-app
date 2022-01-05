using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IUtilityService _utilityService;
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Pet> Pets { get; set; } = new ObservableCollection<Pet>();
        public DelegateCommand GoToUserDetailsPageCommand { get; set; }
        public DelegateCommand<Pet> GoToDetailPageCommand { get; set; }
        
        public DelegateCommand NavigateToSearchPageCommand { get; set; }

        public DelegateCommand<Pet> MarkFavoriteCommand { get; set; }
        public DelegateCommand LoadDataCommand { get; set; }
        public DelegateCommand<Category> LoadPetCommand { get; set; }
        public Placemark PlaceMark { get; set; }

        public string Search { get; set; }
        private Category _category;

        public HomeViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService,IUtilityService utilityService) : base(navigationService, dialogService,apiService)
        {
            _utilityService = utilityService;
            
            GoToUserDetailsPageCommand = new DelegateCommand(async () => await ShowActionSheet());

            GoToDetailPageCommand = new DelegateCommand<Pet>(async (param) => await NavigateToDetailPet(param));

            LoadDataCommand = new DelegateCommand(async ()=> await RunSave( LoadData()));
            LoadPetCommand = new DelegateCommand<Category>(async (param) => await RunSave(LoadPets(param)));
            MarkFavoriteCommand = new DelegateCommand<Pet>(async (param)=>await MarkFavorite(param));
            NavigateToSearchPageCommand = new DelegateCommand(async () =>await  NavigateToSearchPet());
            LoadDataCommand.Execute();
        }

       async Task ShowActionSheet()
        {
            var options = new string[]
            {
                "Ir al perfil",
                "Crear mascota",
                "Cerrar sesion"
            
            };
           var option = await dialogService.DisplayActionSheetAsync("Seleccionar una accion","Cancel",null,options);
           switch (option)
           {
               case "Ir al perfil":
                   await navigationService.NavigateAsync(NavigationConstants.UserDetailPage);
                   break;
               case "Crear mascota":
                   await navigationService.NavigateAsync(NavigationConstants.NewPetPage);
                   break;
               case "Cerrar sesion":
                   Settings.User = string.Empty;
                   Settings.Email = string.Empty;
                   Settings.Password = string.Empty;
                   await navigationService.NavigateAsync(NavigationConstants.LoginPage);
                   break;
           }
        }
        async  Task NavigateToSearchPet()
        {
            if(string.IsNullOrEmpty(Search)||string.IsNullOrWhiteSpace(Search))
                return;
            await navigationService.NavigateAsync(NavigationConstants.SearchPage,new NavigationParameters()
            {
                {NavigationConstants.SearchPage,Search}
            });
        }
        async  Task NavigateToDetailPet(Pet pet)
        {
            if(pet==null)
                return;
            await navigationService.NavigateAsync(NavigationConstants.PetDetailPage,new NavigationParameters()
            {
                {nameof(Pet.Id),pet.Id}
            });
        }
        async Task MarkFavorite(Pet pet)
        {
            if (pet==null)
                return;
 
            pet.IsFavorite = !pet.IsFavorite ;
        }
        async Task LoadPets(Category category)
        {
            if(category==null)
                return;
            if (_category != null)
                _category.IsSelected = false;
            var pet =  await ApiService.GetPets();
            if(pet!=null&&pet.Any())
             Pets = new ObservableCollection<Pet>(pet.Where(e => e.Type == category.Name));
            category.IsSelected = true;
            _category = category;

        }
        async Task LoadData()   
        {
            PlaceMark = await _utilityService.GetCurrentPlaceLocation();
          var categories = await ApiService.GetCategories();
            if (categories.Any())
          {
              Categories = new ObservableCollection<Category>(categories);
          }
          LoadPetCommand.Execute(Categories.FirstOrDefault());
        }

    }
}
