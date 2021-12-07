using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ViralatApp.Helpers;
using ViralatApp.Models;
using ViralatApp.Services;
using ViralatApp.Views;
using Xamarin.Forms;

namespace ViralatApp.ViewModels
{
    public class PaymentMethodViewModel : BaseViewModel
    {
        private CreditCard _selectedCard;
        public CreditCard SelectedCard
        {
            get
            {
                return _selectedCard;
            }
            set
            {
                _selectedCard = value;
                if (_selectedCard != null)
                {
                    SelectedCardCommand.Execute(_selectedCard);
                }
            }
        }
        public ICommand SelectedCardCommand { get; }
        public DelegateCommand GoToAddNewCardPageCommand { get; set; }
        public DelegateCommand GoToSuccessPaymentCommand { get; set; }
        public ObservableCollection<CreditCard> CreditCards { get; } = new ObservableCollection<CreditCard>()
        {

        };
        public PaymentMethodViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiService apiService) : base(navigationService, dialogService, apiService)
        {
            GoToAddNewCardPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.AddNewCardPage);
            });
            GoToSuccessPaymentCommand = new DelegateCommand(async () => {

                
                await dialogService.DisplayAlertAsync("Exito!", "Su apadrinamiento ha sido exitoso.", "OK");
                
            });

            SelectedCardCommand = new Command(async () => 
            {

                await dialogService.DisplayAlertAsync("Listo!", "La tarjeta ha sido seleccioanda satisfactoriamente.", "OK");
            
            });
        }

       
    }
}
