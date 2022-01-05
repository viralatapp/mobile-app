using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ViralatApp.Helpers
{
    public static class Settings
    {
        public static string LanguageConfigured = "ES";

        public static Task<string> Token 
        {
            get=>SecureStorage.GetAsync(nameof(Token));
            set=>SecureStorage.SetAsync(nameof(Token),$"bearer {value.Result}" );
        }
        public static string User 
        {
            get=> Preferences.Get(nameof(User),string.Empty);
            set=>Preferences.Set(nameof(User),value);
        }
        public static string Password 
        {
            get=> Preferences.Get(nameof(Password),string.Empty);
            set=>Preferences.Set(nameof(Password),value);
        }
        public static string Phone 
        {
            get=> Preferences.Get(nameof(Phone),string.Empty);
            set=>Preferences.Set(nameof(Phone),value);
        }
        public static string Email 
        {
            get=> Preferences.Get(nameof(Email),string.Empty);
            set=>Preferences.Set(nameof(Email),value);
        }
        public static bool ShowGettingStarted 
        {
            get=> Preferences.Get(nameof(ShowGettingStarted),true);
            set=>Preferences.Set(nameof(ShowGettingStarted),value);
        }
        public static string UserId
        {
            get => Preferences.Get(nameof(UserId), string.Empty);
            set => Preferences.Set(nameof(UserId), value);
        }
        public static string Address
        {
            get => Preferences.Get(nameof(Address), string.Empty);
            set => Preferences.Set(nameof(Address), value);
        }
        public static string City
        {
            get => Preferences.Get(nameof(City), string.Empty);
            set => Preferences.Set(nameof(City), value);
        }
        public static string Country
        {
            get => Preferences.Get(nameof(Country), string.Empty);
            set => Preferences.Set(nameof(Country), value);
        }
        public static DateTime BirthDate
        {
            get => Preferences.Get(nameof(BirthDate), DateTime.Today.AddYears(-3).AddDays(-25));
            set => Preferences.Set(nameof(BirthDate), value);
        }
    }
}