using System;
using WpfClient;

namespace PanoramaApp1.ViewModels
{
    public class AlarmColorConverterRadial : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var alarmStatus = (AlarmStatus)value;
            var res = new Resource();
            switch (alarmStatus)
            {
                case AlarmStatus.RedUnAcknowledgedActive:
                    return res.Resources["Red"];
                case AlarmStatus.GreenUnAcknowledgedInActive:
                    return res.Resources["Green"];
                case AlarmStatus.BlueAcknowledgedActive:
                    return res.Resources["Blue"];
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