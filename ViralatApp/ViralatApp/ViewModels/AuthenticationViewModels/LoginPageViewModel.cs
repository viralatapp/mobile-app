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
    public class LoginPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToSignUpPageCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public LoginPageViewModel (INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
          
            GoToSignUpPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.SignUpPage);
            });


            LoginCommand = new Command(async ()=>await Login());
        }

        async Task Login()
        {

            var token = await ApiService.Login(new RequestLogin()
            {
                Email = Email,
                Password = Password
            });
            if (token != null && token.Tokens.Refresh != null)
            {
                Settings.Email = Email;
                Settings.Password = Password;
                Settings.User = token.User.Name;
                Settings.UserId = token.User.Id;
                await navigationService.NavigateAsync(NavigationConstants.MenuPage);
            }
        }

        async Task RecoveryPassword()
        {
          await  navigationService.NavigateAsync(NavigationConstants.RecoveryPassword);
        }
    }
}
