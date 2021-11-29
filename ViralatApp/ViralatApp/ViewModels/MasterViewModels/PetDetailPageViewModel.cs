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
   public class PetDetailPageViewModel : BaseViewModel,IInitializeAsync
    {
        private readonly IUtilityService _utilityService;
        public DelegateCommand GoToSponsorPageCommand { get; set; }
        public DelegateCommand GoToAdoptPageCommand { get; set; }
        public DelegateCommand CallContactCommand { get; set; }
        public Pet Pet { get; set; }
        public PetDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService,IUtilityService utilityService) : base(navigationService, dialogService,apiService)
        {
            _utilityService = utilityService;
            GoToAdoptPageCommand = new DelegateCommand(async () => await AdoptPet());

            GoToSponsorPageCommand = new DelegateCommand(async () =>await SponsorForm());
            CallContactCommand = new DelegateCommand(Call);
        }

           void Call()
        {
            //TODO need Refuse phone
            _utilityService.PlacePhoneCall("");
        }
        async Task SponsorForm()
        {

            await navigationService.NavigateAsync(NavigationConstants.SponsorPage,new NavigationParameters()
            {
                {nameof(Pet),Pet}
            });
            

        }

        async  Task AdoptPet()
        {
            await navigationService.NavigateAsync(NavigationConstants.AdoptPage,new NavigationParameters()
            {
                {nameof(Pet),Pet}
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
