using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ViralatApp.ViewModels
{
    public class WelcomePageViewModel : BaseViewModel
    {
        public DelegateCommand GoToLoginPageCommand { get; set; }
        public DelegateCommand GoToSignupPageCommand { get; set; }
        public WelcomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            GoToLoginPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.LoginPage);

            });

            GoToSignupPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.SignUpPage);

            });
        }
    }
}
