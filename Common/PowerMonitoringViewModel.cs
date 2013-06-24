using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;

#if  WINDOWS_PHONE
using PanoramaApp1.ServiceReference;
#endif

#if  !SILVERLIGHT
using WpfClient.ServiceReference;
#endif

namespace WpfClient
{
    public class PowerMonitoringViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NetVariableViewModel> Items { get; private set; }
        public ObservableCollection<TerminalViewModel> TerminalAlarms { get; private set; }
        public ObservableCollection<HistogramViewModel> Histogram { get; private set; }

        private readonly ServiceClient _svc;
        private readonly System.Windows.Threading.DispatcherTimer _timer;
        private DateTime _lastUpdate = DateTime.Now;
        private int _minuteTimer;

        private int _refreshRate;
        public int RefreshRate
        {
            get { return _refreshRate; }
            set
            {
                if (value != _refreshRate)
                {
                    _refreshRate = value;
                    OnPropertyChanged("RefreshRate");
                }
            }
        }

        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            set
            {
                _errorText = value;
                OnPropertyChanged("ErrorText");
            }
        }

        private double _average;
        public double Average
        {
            get { return _average; }
            set
            {
                _average = value;
                OnPropertyChanged("Average");
            }
        }

        private double _histogramInterval;
        public double HistogramInterval
        {
            get { return _histogramInterval; }
            set
            {
                _histogramInterval = value;
                OnPropertyChanged("HistogramInterval");
            }
        }

        public PowerMonitoringViewModel()
        {
            Items = new ObservableCollection<NetVariableViewModel>();
            TerminalAlarms = new ObservableCollection<TerminalViewModel>();
            Histogram = new ObservableCollection<HistogramViewModel>();
            HistogramInterval = 1;

            var sad = DateTime.UtcNow;
            DateTime sadBezMiliSec = (sad.AddSeconds(-sad.Second)).AddMilliseconds(-sad.Millisecond);

            for (int i = 0; i < 24; i++)
            {
                Histogram.Add(new HistogramViewModel {SingleValue = 0, TimeStamp = sadBezMiliSec.AddMinutes(-(24 - i))});
            }

            _svc = new ServiceClient();
            _svc.GetVariablesCompleted += SvcGetVariablesCompleted;
            _svc.GetTerminalCompleted += SvcGetTerminalCompleted;
            _svc.GetAverageLastDayCompleted += SvcGetAverageLastDayCompleted;
            _svc.GetHistogramCompleted += SvcGetHistogramCompleted;
            //Maknit !!!!
            _svc.GetHistogramAsync();

            _timer = new System.Windows.Threading.DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};
            _timer.Start();
            _timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            RefreshRate = (int) (DateTime.Now - _lastUpdate).TotalMilliseconds;

            _svc.GetVariablesAsync();
            _svc.GetTerminalAsync();

            _minuteTimer++;
            if (_minuteTimer >= 60)
            {
                _minuteTimer = 0;
                _svc.GetHistogramAsync();
            }
        }

        private void SvcGetVariablesCompleted(object sender, GetVariablesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorText = "";
                foreach (var variableDto in e.Result)
                {
                    bool variableExsist = false;
                    foreach (var item in Items)
                    {
                        if (item.Name == variableDto.VariableName)
                        {
                            item.UpdateCurrentValue(variableDto.CurrentValue);
                            variableExsist = true;
                        }
                    }
                    if (variableExsist == false)
                    {
                        Items.Add(new NetVariableViewModel(variableDto));
                    }
                }
                _lastUpdate = DateTime.Now;
            }
            else
            {
                ErrorText = "Failed to get Variables from service \r\n" + e.Error.Message;
            }
        }

        private void SvcGetTerminalCompleted(object sender, GetTerminalCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorText = "";

                var itemsToRemove = new List<TerminalViewModel>();
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
                         where
                             t.VariableName == itemToUpdate.VariableName &&
                             t.AlarmLevelName == itemToUpdate.AlarmLevelName
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

        private void SvcGetHistogramCompleted(object sender, GetHistogramCompletedEventArgs e)
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

        private void SvcGetAverageLastDayCompleted(object sender, GetAverageLastDayCompletedEventArgs e)
        {
            Average = e.Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
