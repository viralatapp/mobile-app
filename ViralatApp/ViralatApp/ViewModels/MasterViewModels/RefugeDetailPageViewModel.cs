using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class RefugeDetailPageViewModel : BaseViewModel,IInitializeAsync
    {
        public Refuge Refuge { get; set; }
        public RefugeDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {

        }

        async Task LoadRefuge()
        {
        }
        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(nameof(Refuge)))
            {
                await RunSave(LoadRefuge());
            }
        }
    }
}
