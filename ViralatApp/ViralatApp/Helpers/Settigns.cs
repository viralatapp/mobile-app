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
            set=>SecureStorage.SetAsync(nameof(Token),value.Result);
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
    }
}