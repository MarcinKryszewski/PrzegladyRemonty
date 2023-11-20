using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PrzegladyRemonty.Converters
{
    public class MaintenanceDateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateOnly daysSinceMaintenance = DateOnly.Parse(value.ToString());
            int days = DateOnly.FromDateTime(DateTime.Now).DayNumber - daysSinceMaintenance.DayNumber;

            if (days > 120)
            {
                return Brushes.Red;
            }
            if (days > 60)
            {
                return Brushes.Yellow;
            }
            return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
