using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViralatApp.ViewModels
{
    public class AdoptPageViewModel : BaseViewModel
    {
        public DelegateCommand SubmitPageCommand { get; set; }

        public AdoptPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {

            SubmitPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }
    }
}
