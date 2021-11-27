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
    public class SignUpPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToLoginPageCommand { get; set; }
        public User User { get; set; }
        public ICommand RegisterCommand { get; set; }
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            GoToLoginPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.LoginPage);

            });
            RegisterCommand = new Command(async () =>await RunSave( CreateUser()));
        }

        public async Task CreateUser()
        {
           await ApiService.Register(User);
        }
    }
}
