using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Services;
using ViralatApp.Services;
using ViralatApp.Views.MenuView;

namespace ViralatApp.ViewModels
{
    public class MenuViewModel:BaseViewModel,IInitialize
    {
        private readonly IContainerProvider _containerProvider;
        public HomeViewModel GoHomeViewModel { get; set; }
        public FavoritesView GoFavoritesView{ get; set; }
        
        public MenuViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService,IContainerProvider containerProvider) : base(navigationService, dialogService, apiService)
        {
            _containerProvider = containerProvider;
        }

        void LoadViewModelForViews()
        {
            //Load ViewModel for TabViews
            GoHomeViewModel = _containerProvider.Resolve(typeof(HomeViewModel)) as HomeViewModel;
            GoFavoritesView = _containerProvider.Resolve(typeof(FavoritesView)) as FavoritesView;
        }

        public void Initialize(INavigationParameters parameters)
        {
            LoadViewModelForViews();
        }
    }
}