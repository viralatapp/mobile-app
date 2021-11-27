using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;


namespace ViralatApp.ViewModels
{
   public class DetailPageViewModel : BaseViewModel,IInitializeAsync
    {
        public DelegateCommand GoToSponsorPageCommand { get; set; }
        public DelegateCommand GoToAdoptPageCommand { get; set; }
        public Pet Pet { get; set; }
        public DetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            GoToAdoptPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.AdoptPage);
            });

            GoToSponsorPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.SponsorPage);
            });
        }

        async  Task LoadDetailPet(string id)
        {
            Pet = await ApiService.GetPetById(id);
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(nameof(Pet.Id)))
            {
                await  RunSave(LoadDetailPet(parameters[nameof(Pet.Id)].ToString()));
            }
   
        }
    }
}
