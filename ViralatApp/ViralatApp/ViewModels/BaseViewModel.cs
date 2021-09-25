using Prism.Navigation;
using Prism.Services;
using System.ComponentModel;

namespace ViralatApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavigationService navigationService;
        protected IPageDialogService dialogService;
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
        }
    }
}
