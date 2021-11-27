using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Helpers;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class WelcomePageViewModel : BaseViewModel
    {
        public DelegateCommand GoToLoginPageCommand { get; set; }
        public DelegateCommand GoToSignupPageCommand { get; set; }

        public WelcomePageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            GoToLoginPageCommand = new DelegateCommand(async () =>
            {
                Settings.ShowGettingStarted = false;
                await navigationService.NavigateAsync(NavigationConstants.LoginPage);
        
            });

            GoToSignupPageCommand = new DelegateCommand(async () =>
            {
                Settings.ShowGettingStarted = false;
                await navigationService.NavigateAsync(NavigationConstants.SignUpPage);
              

            });
        }
    }
}
