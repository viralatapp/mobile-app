using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ViralatApp.Services;

namespace ViralatApp.ViewModels
{
    public class AddNewCardViewModel : BaseViewModel
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
            set { _expiration = value;  }
        }

        public string CVC
        {
            get => _cvc;
            set { _cvc = value;  }
        }
        public AddNewCardViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
        }
    } 
}
    
