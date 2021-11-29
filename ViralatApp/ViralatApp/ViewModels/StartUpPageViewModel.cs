using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class StartUpPageViewModel:BaseViewModel
    {
        public ICommand StartUpCommand { get; set; }
        public StartUpPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            StartUpCommand = new Command(async () => await RunSave(StartUp()));
            StartUpCommand.Execute(null);
        }

        async Task StartUp()
       {
           await  Task.Delay(200);
            if (Settings.ShowGettingStarted)
            {
              await  navigationService.NavigateAsync(NavigationConstants.WelcomePage);
            }
            else
            {
                if (string.IsNullOrEmpty(Settings.User)||string.IsNullOrEmpty(Settings.Email)||string.IsNullOrEmpty(Settings.Password))
                {
                    await   navigationService.NavigateAsync(NavigationConstants.LoginPage);
                }
                else
                {
                   await ApiService.Login(new RequestLogin()
                    {
                        Email = Settings.Email,
                        Password = Settings.Password
                        
                    });
                    await    navigationService.NavigateAsync(NavigationConstants.MenuPage);
                }
            }
        }
    }
}