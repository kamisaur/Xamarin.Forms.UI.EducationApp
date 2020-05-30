using System;
using System.Globalization;
using Xamarin.Forms;

namespace EducationApp.Converters
{
    public class ProgressToBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var progress = (float)value;

            if (progress == 1)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
