using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class TermAndConditionPage:BaseViewModel
    {
        public string Text { get; set; }
        public DelegateCommand<bool> CloseCommand { get; set; }
        public TermAndConditionPage(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            CloseCommand = new DelegateCommand<bool>(CloseQuestion);
        }

        private void CloseQuestion(bool obj)
        {
            if (obj)
            {
                
            }
        }
    }
}