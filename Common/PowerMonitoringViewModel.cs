using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Collections.ObjectModel;

using System.Windows.Input;

#if  WINDOWS_PHONE
using PanoramaApp1;
using PanoramaApp1.ServiceReference;
#endif

#if  !SILVERLIGHT
using WpfClient.ServiceReference;
#endif




namespace WpfClient
{
    public class PowerMonitoringViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<NetVariableViewModel> Items { get; private set; }

        public ObservableCollection<TerminalViewModel> TerminalAlarms { get; private set; }

        public ObservableCollection<HistogramViewModel> Histogram { get; private set; }

        ServiceClient _svc;
        System.Windows.Threading.DispatcherTimer timer;

        DateTime LastUpdate = DateTime.Now;

        #region INotifyProperties
        private int refreshRate;
        public int RefreshRate
        {
            get
            { 
                return refreshRate; 
            }
            set 
            {
                if (value != refreshRate)
                {
                    refreshRate = value;
                    NotifyPropertyChanged("RefreshRate");
                }
            }
        }

        private string errorText;
        public string ErrorText
        {
            get { return errorText; }
            set { errorText = value; NotifyPropertyChanged("ErrorText"); }
        }

        private double average;
        public double Average
        {
            get { return average; }
            set { average = value; NotifyPropertyChanged("Average"); }
        }

        private double histogramInterval;

        public double HistogramInterval
        {
            get { return histogramInterval; }
            set { histogramInterval = value; NotifyPropertyChanged("HistogramInterval"); }
        }
        
        
        
        #endregion



        #region Constructors
        public PowerMonitoringViewModel()
        {
            this.Items = new ObservableCollection<NetVariableViewModel>();
            this.TerminalAlarms = new ObservableCollection<TerminalViewModel>();
            this.Histogram = new ObservableCollection<HistogramViewModel>();
            HistogramInterval = 1;

            DateTime Sad = DateTime.UtcNow;
            DateTime SadBezMiliSec = (Sad.AddSeconds(-Sad.Second)).AddMilliseconds(-Sad.Millisecond);


            for (int i = 0; i < 24; i++)
            {
                Histogram.Add(new HistogramViewModel { SingleValue = 0, TimeStamp = SadBezMiliSec.AddMinutes(-(24 - i)) });
            }

            _svc = new ServiceClient();
            _svc.GetVariablesCompleted += new EventHandler<GetVariablesCompletedEventArgs>(_svc_GetVariablesCompleted);
            _svc.GetTerminalCompleted += new EventHandler<GetTerminalCompletedEventArgs>(_svc_GetTerminalCompleted);
            _svc.GetAverageLastDayCompleted += new EventHandler<GetAverageLastDayCompletedEventArgs>(_svc_GetAverageLastDayCompleted);
            _svc.GetHistogramCompleted += new EventHandler<GetHistogramCompletedEventArgs>(_svc_GetHistogramCompleted);

            //Maknit !!!!
            _svc.GetHistogramAsync();

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            timer.Tick += new EventHandler(timer_Tick);

        }


        #endregion

        int minuteTimer=0;
        void timer_Tick(object sender, EventArgs e)
        {
            RefreshRate = (int)(DateTime.Now - LastUpdate).TotalMilliseconds;

            _svc.GetVariablesAsync();
            _svc.GetTerminalAsync();

            minuteTimer++;
            if (minuteTimer >= 60)
            {
                minuteTimer = 0;
                _svc.GetHistogramAsync();
            }
        }

        



        void _svc_GetVariablesCompleted(object sender, GetVariablesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorText = "";
                foreach (var variableDto in e.Result)
                {
                    bool VariableExsist = false;
                    foreach (var item in Items.Where(s => s.Name == variableDto.VariableName))
                    {
                        item.UpdateCurrentValue(variableDto.CurrentValue);
                        VariableExsist = true;
                    }
                    if (VariableExsist == false)
                    {
                        Items.Add(new NetVariableViewModel(variableDto));
                    }
                }
                LastUpdate = DateTime.Now;
            }
            else
            {
                ErrorText = "Failed to get Variables from service \r\n" + e.Error.Message;
            }
        }

        void _svc_GetTerminalCompleted(object sender, GetTerminalCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorText = "";


                List<TerminalViewModel> itemsToRemove = new List<TerminalViewModel>();
                foreach (var item in TerminalAlarms)
                {
                    try
                    {
                        (from t in e.Result
                         where t.VariableName == item.VariableName && t.AlarmLevelName == item.AlarmLevelName
                         select t).First();
                    }
                    catch (Exception)
                    {
                        itemsToRemove.Add(item);
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    TerminalAlarms.Remove(item);
                }


                foreach (var itemToUpdate in e.Result)
                {

                    try
                    {
                        (from t in TerminalAlarms
                         where t.VariableName == itemToUpdate.VariableName && t.AlarmLevelName == itemToUpdate.AlarmLevelName
                         select t).First().Update(itemToUpdate);
                    }
                    catch (Exception)
                    {
                        TerminalAlarms.Add(new TerminalViewModel(itemToUpdate, _svc));
                    }
                }
            }
            else
            {
                ErrorText = "Failed to get Terminal from service \r\n" + e.Error.Message;
            }
        }

        void _svc_GetHistogramCompleted(object sender, GetHistogramCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorText = "";

                

                var itemsToAdd = (from h in e.Result
                                  orderby h.TimeStamp
                                  select new HistogramViewModel
                                  {
                                      SingleValue = h.SingleValue/1000,
                                      TimeStamp = h.TimeStamp,
                                  }).ToList();
                foreach (var item in itemsToAdd)
                {

                    try
                    {
                        Histogram.First(s => s.TimeStamp == item.TimeStamp).SingleValue = item.SingleValue;
                    }
                    catch (Exception)
                    {
                        Histogram.RemoveAt(0);
                        Histogram.Add(item);
                    }
                }
                


            }
            else
            {
                ErrorText = "Failed to get Histogram from service \r\n" + e.Error.Message;
            }
        }



         public void GetAverageLastDay(string varName)
        {
            _svc.GetAverageLastDayAsync(varName);
        }

         public void AcnowladgeAlarm(int alarmId)
         {
             _svc.AcknowledgeAlarmAsync(alarmId);
         }

         void _svc_GetAverageLastDayCompleted(object sender, GetAverageLastDayCompletedEventArgs e)
         {
             Average = e.Result;
         }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }


#if  !SILVERLIGHT

    public class AlarmColorConverter : System.Windows.Data.IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

#endif

#if  SILVERLIGHT

    public class AlarmColorConverterRadial : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlarmStatus alarmStatus = (AlarmStatus)value;
            Resource res = new Resource();
            switch (alarmStatus)
            {
                case AlarmStatus.Red_UnAcknowledgedActive:
                    return res.Resources["Red"];
                case AlarmStatus.Green_UnAcknowledgedInActive:
                    return res.Resources["Green"];
                case AlarmStatus.Blue_AcknowledgedActive:
                    return res.Resources["Blue"];
                default:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);

                //case AlarmStatus.Red_UnAcknowledgedActive:
                //    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red); 
                //case AlarmStatus.Green_UnAcknowledgedInActive:
                //    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                //case AlarmStatus.Blue_AcknowledgedActive:
                //    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                //default:
                //    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);

            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AlarmColorConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlarmStatus alarmStatus = (AlarmStatus)value;
            Resource res = new Resource();
            switch (alarmStatus)
            {
                case AlarmStatus.Red_UnAcknowledgedActive:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                case AlarmStatus.Green_UnAcknowledgedInActive:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                case AlarmStatus.Blue_AcknowledgedActive:
                    var blue = new System.Windows.Media.Color { R = 65, G = 105, B = 225, A=255 };
                    return new System.Windows.Media.SolidColorBrush(blue);

                default:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);

            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


#endif






}
