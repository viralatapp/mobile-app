using System;
using Prism.Navigation;
using Prism.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IApiService ApiService { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavigationService navigationService;
        protected IPageDialogService dialogService;
        public bool IsBusy { get; set; }
        public DelegateCommand<NavigationParameters> GoBackCommand { get; set; }
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService)
        {
            ApiService = apiService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            GoBackCommand = new DelegateCommand<NavigationParameters>(async (param) => await GoBackAsync(param));
        }

       protected virtual async Task GoBackAsync(NavigationParameters navigationParameters)
       {
           await navigationService.GoBackAsync(navigationParameters);
       }
        protected async Task RunSave(Task t, string errorTitle=null, string message = null)
        {
            try
            {
                IsBusy = true;
                await t;
            }
            catch(Exception exception)
            {
                errorTitle ??= "Error";
                message ??= $"{exception.Message}";
               await  dialogService.DisplayAlertAsync(errorTitle, message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
