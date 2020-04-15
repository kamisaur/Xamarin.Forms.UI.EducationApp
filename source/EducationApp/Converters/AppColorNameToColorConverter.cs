using System;
using System.Globalization;
using Xamarin.Forms;

namespace EducationApp.Converters
{
    public class AppColorNameToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorName = (string)value;
            var colorCode = SharedState.GetColor(colorName);
            return colorCode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
