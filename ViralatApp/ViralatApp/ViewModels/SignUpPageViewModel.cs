using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ViralatApp.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToLoginPageCommand { get; set; }
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            GoToLoginPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.LoginPage);

            });
        }
    }
}
