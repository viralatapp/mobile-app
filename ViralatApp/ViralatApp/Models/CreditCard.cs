using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViralatApp.Models
{
    public class CreditCard : INotifyPropertyChanged
    {
        public CreditCard(string cardNumber, string expiration, string cvc)
        {
            CardNumber = cardNumber;
            Expiration = expiration;
            CVC = cvc;
        }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVC { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
