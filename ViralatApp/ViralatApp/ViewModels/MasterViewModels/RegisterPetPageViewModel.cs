using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class RegisterPetPageViewModel:BaseViewModel 
    {
        public PetValidator PetValidator { get; set; }
        public DelegateCommand AddPhotoCommand { get; set; }
        public DelegateCommand SummitCommand { get; set; }
        public ObservableCollection<byte[]> Images { get; set; }
        public RegisterPetPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            PetValidator = new PetValidator();
            SummitCommand = new DelegateCommand(async () => await Summit());
            AddPhotoCommand = new DelegateCommand(async () => await AddPhoto());
        }

        async Task AddPhoto()
        {
            
        }
        async Task Summit()
        {
            if (PetValidator.IsValid)
            {
              await  ApiService.CreatePet(PetValidator.CreatePet());
            }
        }
    }
}