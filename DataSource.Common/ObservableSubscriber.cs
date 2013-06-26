using System;
using System.ComponentModel;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Common
{
    public class ObservableSubscriber<T> : IObservableSubscriber<T>, INotifyPropertyChanged
    {
        public IBrowserItem BrowserItem { get; private set; }
        private readonly ISubscriber<T> _subscriber;

        private T _currentValue;
        private string _currentValueString;
        private DateTime _timeStamp;
        private string _quality;
        private int _refreshRate;

        public T CurrentValue
        {
            get { return _currentValue; }
            set { _currentValue = value; OnPropertyChanged("CurrentValue"); }
        }

        public string CurrentValueString
        {
            get { return _currentValueString; }
            set { _currentValueString = value; OnPropertyChanged("CurrentValueString"); }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; OnPropertyChanged("TimeStamp"); }
        }

        public string Quality
        {
            get { return _quality; }
            set { _quality = value; OnPropertyChanged("Quality"); }
        }

        public int RefreshRate
        {
            get { return _refreshRate; }
            set { _refreshRate = value; OnPropertyChanged("RefreshRate"); }
        }

        public event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        public void ConnectAsync()
        {
            _subscriber.ConnectAsync();
        }

        public ObservableSubscriber(ISubscriber<T> subscriber, IBrowserItem browserItem)
        {
            BrowserItem = browserItem;
            _subscriber = subscriber;
            _subscriber.DataUpdated += SubscriberDataUpdated;
            _subscriber.ConnectCompleted += SubscriberConnectCompleted;
        }

        void SubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ConnectCompleted(this, e);
        }

        void SubscriberDataUpdated(object sender, DataUpdatedEventArgs<T> e)
        {
            if (DataUpdated != null)
            {
                DataUpdated(this, e);
            }
            CurrentValue = e.Data.GetValue();
            CurrentValueString = CurrentValue.ToString();
            RefreshRate = (int) (e.Data.TimeStamp - TimeStamp).TotalMilliseconds;
            TimeStamp = e.Data.TimeStamp;
            Quality = e.Data.Quality.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
