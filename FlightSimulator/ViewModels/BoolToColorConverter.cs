using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace FlightSimulator.ViewModels
{
    class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorName = (string)value;
            if (string.Equals(colorName, "Red"))
                return Brushes.PaleVioletRed;
            return Brushes.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

