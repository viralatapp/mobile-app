using Prism.Commands;
using Prism.Navigation;
using Prism.Services;


namespace ViralatApp.ViewModels
{
    class DetailPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToAdoptPageCommand { get; set; }
        public DetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            GoToAdoptPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.AdoptPage);
            });
        }
    }
}
