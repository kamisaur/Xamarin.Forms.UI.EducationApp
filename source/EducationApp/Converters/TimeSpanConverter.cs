using System;
using System.Globalization;
using Xamarin.Forms;

namespace EducationApp.Converters
{
    public class TimeSpanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan)value;
            var output = "";

            if(time.Hours != 0)
            {
                output = $"{time.Hours} h";
            }

            if(time.Minutes != 0)
            {
                output = $"{output} {time.Minutes} min";
            }


            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
