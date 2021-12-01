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
    public class PaymentMethodViewModel : BaseViewModel
    {
        public DelegateCommand GoToAddNewCardPageCommand { get; set; }
        public PaymentMethodViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            GoToAddNewCardPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.AddNewCardPage);
            });
        }
    }
}
