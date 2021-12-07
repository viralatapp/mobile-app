using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViralatApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewCardPage : BasePage
    {
        public AddNewCardPage(ObservableCollection<CreditCard> creditCards)
        {
            InitializeComponent();
        }
    }
}