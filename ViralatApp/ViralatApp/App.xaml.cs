using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using ViralatApp.Helpers;
using ViralatApp.Services;
using ViralatApp.ViewModels;
using ViralatApp.Views;
using ViralatApp.Views.MasterPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ViralatApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            
            NavigationService.NavigateAsync(NavigationConstants.StartUpPage);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApiService, ApiService>();
            containerRegistry.RegisterSingleton<IUtilityService, UtilityService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterForNavigation<PetDetailPage, PetDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<StartUpPage, StartUpPageViewModel>();
            containerRegistry.RegisterForNavigation<AdoptPage, AdoptPageViewModel>();
            containerRegistry.RegisterForNavigation<SponsorPage, SponsorPageViewModel>();
            containerRegistry.RegisterForNavigation<AddNewCardPage, AddNewCardViewModel>();
            containerRegistry.RegisterForNavigation<PaymentMethodPage, PaymentMethodViewModel>();
            containerRegistry.RegisterForNavigation<UserDetailPage, UserDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RefugeDetailPage, RefugeDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<NewPetPage, NewPetViewModel>();
            containerRegistry.RegisterInstance<IApiClient<IViralataApi>>(new ApiClient<IViralataApi>(Config.ApiUrl));
            containerRegistry.RegisterForNavigation<RegisterPetPage, RegisterPetPageViewModel>();
            #region Register ViewModel For TabView
            containerRegistry.Register(typeof(HomeViewModel));
            containerRegistry.Register(typeof(FavoriteViewModel));
            #endregion

            
        }
    }
}
