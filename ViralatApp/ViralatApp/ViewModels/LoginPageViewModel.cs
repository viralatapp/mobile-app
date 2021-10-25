using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ViralatApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToSignUpPageCommand { get; set; }
        public DelegateCommand GoToHomePageCommand { get; set; }
        public LoginPageViewModel (INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            GoToSignUpPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.SignUpPage);
            });

            GoToHomePageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.HomePage);
            });
        }
    }
}
