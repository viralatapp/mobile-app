using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class UserDetailPageViewModel : BaseViewModel,IInitializeAsync
    {
        private readonly IUtilityService _utilityService;
        public User User { get; set; }
        public DelegateCommand CallContactCommand { get; set; }
        public ICommand ChangePhotoProfileCommand { get; set; }
        public ICommand LoadDetailCommand { get; set; }
        public UserDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService,IUtilityService utilityService) : base(navigationService, dialogService,apiService)
        {
            _utilityService = utilityService;
            LoadDetailCommand = new Command(async () => await RunSave(LoadDetails()));
            ChangePhotoProfileCommand = new Command(async () => await ChangePhoto());
            CallContactCommand = new DelegateCommand(Call);
        }
        void Call()
        {
            //TODO need Refuse phone
            _utilityService.PlacePhoneCall(User.Phone);
        }
        async Task ChangePhoto()
        {
            
        }

        async Task LoadDetails()
        {
            User = await ApiService.GetUserById(Settings.User);
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            await LoadDetails();
        }
    }
}
