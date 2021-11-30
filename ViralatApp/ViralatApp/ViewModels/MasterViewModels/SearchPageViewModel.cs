using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class SearchPageViewModel : BaseViewModel,IInitializeAsync
    {
        public DelegateCommand<string> SearchPetCommand { get; set; }
        private string _search;

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                SearchPetCommand.Execute(_search);
            }
        }
        public DelegateCommand<Pet> GoToDetailPageCommand { get; set; }
        public ObservableCollection<Pet> Pets { get; set; }

        public SearchPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            SearchPetCommand = new DelegateCommand<string>(async (param)=> await SearchPet(param));
            GoToDetailPageCommand = new DelegateCommand<Pet>(async (param)=>await  NavigateToDetailPet(param));

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
       async Task SearchPet(string search)
       {
           var pets = await ApiService.GetPets();
           Pets = !string.IsNullOrEmpty(search) ? 
               new ObservableCollection<Pet>(pets.Where(e=>e.Name.ToLower().Contains(search.ToLower())||e.Breed.ToLower().Contains(search.ToLower()))) 
               : new ObservableCollection<Pet>(pets);
       }

       public async Task InitializeAsync(INavigationParameters parameters)
       {
           if (parameters.ContainsKey(NavigationConstants.SearchPage))
           {
               Search = parameters[NavigationConstants.SearchPage].ToString();
           }
          
       }
    }
}