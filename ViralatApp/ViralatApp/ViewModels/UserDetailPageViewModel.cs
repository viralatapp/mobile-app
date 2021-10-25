using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViralatApp.ViewModels
{
    public class UserDetailPageViewModel : BaseViewModel
    {
        public UserDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {

        }
    }
}
