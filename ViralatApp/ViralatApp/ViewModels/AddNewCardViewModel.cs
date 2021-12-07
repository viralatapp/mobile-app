using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ViralatApp.Models;
using ViralatApp.Services;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class AddNewCardViewModel : BaseViewModel, IInitialize
    {

        private string _cardNumber;
        private string _expiration;
        private string _cvc;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
            }
        }

        public string Expiration
        {
            get => _expiration;
            set { _expiration = value; }
        }

        public string CVC
        {
            get => _cvc;
            set { _cvc = value; }
        }
        public DelegateCommand AddNewCardCommand { get; set; }
        public AddNewCardViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            //_creditCards = creditCards;
            AddNewCardCommand = new DelegateCommand(async () =>
            {
                if (!String.IsNullOrEmpty(CardNumber) && !String.IsNullOrEmpty(Expiration) && !String.IsNullOrEmpty(CVC))
                {
                    _creditCards.Add(new CreditCard(CardNumber, Expiration, CVC));
                    await navigationService.GoBackAsync();
                }
                else
                {
                    await dialogService.DisplayAlertAsync("Error", "Todos los campos son obligatorios", "ok");
                }
                
            });

        }

        private ObservableCollection<CreditCard> _creditCards;

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("CreditCards", out ObservableCollection<CreditCard> creditCards))
            {
                _creditCards = creditCards;
            }
        }
    } 
}
    
