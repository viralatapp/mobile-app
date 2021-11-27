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
    public class UserDetailPageViewModel : BaseViewModel
    {
        public User User { get; set; }
        public ICommand ChangePhotoProfileCommand { get; set; }
        public ICommand LoadDetailCommand { get; set; }
        public UserDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            LoadDetailCommand = new Command(async () => await RunSave(LoadDetails()));
            ChangePhotoProfileCommand = new Command(async () => await ChangePhoto());
        }

        async Task ChangePhoto()
        {
            
        }

        async Task LoadDetails()
        {
            User = await ApiService.GetUserById(Settings.User);
        }
    }
}
