using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using ViralatApp.Models;

namespace ViralatApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<Pet> Pets { get; set; } = new ObservableCollection<Pet>();
        public DelegateCommand GoToUserDetailsPageCommand { get; set; }
        public DelegateCommand GoToDetailPageCommand { get; set; }
        public DelegateCommand GoToListOfPetsPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            Categories.Add(new Category { Name = "Perros", Image = "dogCategory" });
            Categories.Add(new Category { Name = "Gatos", Image = "catCategory" });
            Categories.Add(new Category { Name = "Aves", Image = "birdCategory" });
            Categories.Add(new Category { Name = "Conejos", Image = "rabbitCategory" });

            Pets.Add(new Pet { Name = "Linda", Image = "firstPet" , Race= "Mestizo", IsAdult = true, Sexo = Sexo.Femenino});
            Pets.Add(new Pet { Name = "Kiko", Image = "secondPet", Race = "Mestizo", IsAdult = false, Sexo = Sexo.Masculino });
            Pets.Add(new Pet { Name = "Coco", Image = "thridPet", Race = "Mestizo", IsAdult = true, Sexo = Sexo.Masculino });
            Pets.Add(new Pet { Name = "Shira", Image = "fourthPet", Race = "Mestizo", IsAdult = false, Sexo = Sexo.Femenino });

            GoToUserDetailsPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.UserDetailPage);
            });

            GoToDetailPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.DetailPage);
            });

            GoToListOfPetsPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.DetailPage);
            });
        }
    }
}
