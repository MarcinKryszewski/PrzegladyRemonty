using System;
using System.Globalization;
using System.Windows.Data;

namespace PrzegladyRemonty.Converters
{
    public class ReverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*if (value.GetType() == typeof(bool))
            {
                return !(bool)value;
            }*/
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
