using System;
using System.Globalization;
using ViralatApp.Extesion;
using Xamarin.Forms;

namespace ViralatApp.Converters
{
    public class AgeToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int age)
            {
                var textKey = age > 3 ? "Adult" : "Puppy";
                return LocalizationResourceManager.Instance[textKey];
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}