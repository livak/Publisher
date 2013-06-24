using System;
using WpfClient;

namespace PanoramaApp1.ViewModels
{
    public class AlarmColorConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var alarmStatus = (AlarmStatus) value;
            switch (alarmStatus)
            {
                case AlarmStatus.RedUnAcknowledgedActive:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                case AlarmStatus.GreenUnAcknowledgedInActive:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                case AlarmStatus.BlueAcknowledgedActive:
                    var blue = new System.Windows.Media.Color {R = 65, G = 105, B = 225, A = 255};
                    return new System.Windows.Media.SolidColorBrush(blue);
                default:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}