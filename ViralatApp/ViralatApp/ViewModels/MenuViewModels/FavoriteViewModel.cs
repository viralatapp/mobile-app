using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Models;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class FavoriteViewModel:BaseViewModel
    {
        public ObservableCollection<Pet> Favorites { get; set; }
        public FavoriteViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
        }

       async Task LoadFavorite()
        {
            Favorites = await Task.FromResult(new ObservableCollection<Pet>());

        }
    }
}