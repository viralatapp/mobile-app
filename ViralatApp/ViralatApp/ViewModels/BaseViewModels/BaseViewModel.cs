using System;
using Prism.Navigation;
using Prism.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IApiService ApiService { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavigationService navigationService;
        protected IPageDialogService dialogService;
        public bool IsBusy { get; set; }
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService)
        {
            ApiService = apiService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
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
