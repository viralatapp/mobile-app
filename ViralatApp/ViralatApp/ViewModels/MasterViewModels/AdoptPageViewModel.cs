using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class AdoptPageViewModel : BaseViewModel
    {
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SubmitPageCommand { get; set; }

        public AdoptPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {

            SubmitPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
            CancelCommand = new DelegateCommand( async ()=>await Cancel());
            SubmitPageCommand = new DelegateCommand(async () => await Cancel());
        }

       async Task Cancel()
        {
          await  navigationService.GoBackAsync();
        }
    }
}
