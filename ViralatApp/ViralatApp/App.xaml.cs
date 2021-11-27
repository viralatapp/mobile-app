using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using ViralatApp.Helpers;
using ViralatApp.Services;
using ViralatApp.ViewModels;
using ViralatApp.Views;
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
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
            containerRegistry.RegisterForNavigation<StartUpPage, StartUpPageViewModel>();
            containerRegistry.RegisterForNavigation<AdoptPage, AdoptPageViewModel>();
            containerRegistry.RegisterForNavigation<SponsorPage, SponsorPageViewModel>();
            containerRegistry.RegisterForNavigation<UserDetailPage, UserDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RefugeDetailPage, RefugeDetailPageViewModel>();
            containerRegistry.RegisterInstance<IApiClient<IViralataApi>>(new ApiClient<IViralataApi>(Config.ApiUrl));
            containerRegistry.RegisterSingleton<IApiService, ApiService>();
            
        }
    }
}
