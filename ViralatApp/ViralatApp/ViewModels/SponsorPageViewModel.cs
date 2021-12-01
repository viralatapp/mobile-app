using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ViralatApp.Helpers;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class SponsorPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToPaymentMethodPageCommand { get; set; }
        public SponsorPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            GoToPaymentMethodPageCommand = new DelegateCommand(async () => {

                await navigationService.NavigateAsync(NavigationConstants.PaymentMethodPage);

            });               
             

        }
    }
}
