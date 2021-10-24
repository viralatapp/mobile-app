using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using ViralatApp.Models;

namespace ViralatApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            Categories.Add(new Category { Name = "Perros", Image = "dogCategory" });
            Categories.Add(new Category { Name = "Gatos", Image = "catCategory" });
            Categories.Add(new Category { Name = "Aves", Image = "birdCategory" });
            Categories.Add(new Category { Name = "Conejos", Image = "rabbitCategory" });
        }
    }
}
