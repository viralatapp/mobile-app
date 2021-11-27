using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class SponsorPageViewModel : BaseViewModel
    {
        public SponsorPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {

        }
    }
}
