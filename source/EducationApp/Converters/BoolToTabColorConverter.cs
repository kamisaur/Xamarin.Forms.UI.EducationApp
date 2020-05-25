using System;
using System.Globalization;
using Xamarin.Forms;

namespace EducationApp.Converters
{
    public class BoolToTabColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isSelected = (bool)value;
            if (isSelected)
            {
                return (Color)Application.Current.Resources["PrimaryText"];
            }
            else
            {
                return (Color)Application.Current.Resources["TabUnselected"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
