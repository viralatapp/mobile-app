using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get;  }
        public ObservableCollection<Pet> Pets { get; set; } = new ObservableCollection<Pet>();
        public DelegateCommand GoToUserDetailsPageCommand { get; set; }
        public DelegateCommand GoToDetailPageCommand { get; set; }
        public DelegateCommand GoToListOfPetsPageCommand { get; set; }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                if (_category!=null)
                {
                    
                }
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                if (Categories!=null&&Categories.Any())
                {
                    Category = Categories[_selectedIndex];
                }
            }
        }

        public DelegateCommand LoadDataCommand { get; set; }
        public DelegateCommand<Category> LoadPetCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService,IApiService apiService) : base(navigationService, dialogService,apiService)
        {
            Categories = new ObservableCollection<Category>();
            
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
            LoadDataCommand = new DelegateCommand(async ()=> await RunSave( LoadData()));
            LoadPetCommand = new DelegateCommand<Category>(async (param) => await RunSave(LoadPets(param)));
        }

        private List<Pet> _pets = new List<Pet>();
        private int _selectedIndex;
        private Category _category;

        async Task LoadPets(Category category)
        {
            if(category==null)
                return;
            Pets = new ObservableCollection<Pet>(_pets.Where(e => e.Name == category.Name));
        }
        async Task LoadData()
      {
          var pets = await ApiService.GetPets();
          if (!pets.Any())
          {
              var categories = pets.GroupBy(e => e.Race).Select(e => e.Key).Select(e=> new Category(e,string.Empty));
              Categories.AddRange(categories);
          }
          _pets = pets;
          LoadPetCommand.Execute(Categories.FirstOrDefault());
            // // Categories.Add(new Category { Name = "Perros", Image = "dogCategory" });
            // // Categories.Add(new Category { Name = "Gatos", Image = "catCategory" });
            // // Categories.Add(new Category { Name = "Aves", Image = "birdCategory" });
            // // Categories.Add(new Category { Name = "Conejos", Image = "rabbitCategory" });
            //
            // Pets.Add(new Pet { Name = "Linda", Image = "firstPet" , Race= "Mestizo", IsAdult = true, Gender = EGender.Femenino});
            // Pets.Add(new Pet { Name = "Kiko", Image = "secondPet", Race = "Mestizo", IsAdult = false, Gender = EGender.Masculino });
            // Pets.Add(new Pet { Name = "Coco", Image = "thridPet", Race = "Mestizo", IsAdult = true, Gender = EGender.Masculino });
            // Pets.Add(new Pet { Name = "Shira", Image = "fourthPet", Race = "Mestizo", IsAdult = false, Gender = EGender.Femenino });
        }
    }
}
