using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PrzegladyRemonty.Converters
{
    public class ButtonStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string buttonName = value as string;
            string targetButtonName = parameter as string;

            return buttonName == targetButtonName ? Application.Current.FindResource("NavButtonActive") : Application.Current.FindResource("NavButton");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}