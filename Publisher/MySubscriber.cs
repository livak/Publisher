using System;
using System.ComponentModel;
using System.Globalization;
using NationalInstruments.NetworkVariable;

namespace Publisher
{
    public class MySingleSubscriber : NetworkVariableSubscriber<Single>,INotifyPropertyChanged
    {
        public BrowserItem BrowserItem { get; private set; }

        private Single _currentValueSingle;
        public Single CurrentValueSingle
        {
            get { return _currentValueSingle; }
            private set
            {
                _currentValueSingle = value;
                OnPropChanged("CurrentValueSingle");
                CurrentValueString = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private string _currentValueString;
        public string CurrentValueString 
        { 
            get { return _currentValueString; } 
            set { _currentValueString = value; OnPropChanged("CurrentValueString"); } 
        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; } 
            private set { _timeStamp = value; OnPropChanged("TimeStamp"); 
            }
        }

        private string _quality;
        public string Quality {
            get { return _quality; } 
            private set { _quality = value; OnPropChanged("Quality"); } 
        }

        private int _refreshRate;
        public int RefreshRate
        {
            get { return _refreshRate; }  
            set { _refreshRate = value; OnPropChanged("RefreshRate"); }
        }

        public MySingleSubscriber(BrowserItem browserItem): base(browserItem.Path)
        {
            BrowserItem = browserItem;
            base.DataUpdated += MySubscriberDataUpdated;
        }

        void MySubscriberDataUpdated(object sender, DataUpdatedEventArgs<float> e)
        {
            CurrentValueSingle = e.Data.GetValue();

            RefreshRate = (int)(e.Data.TimeStamp - TimeStamp).TotalMilliseconds;

            TimeStamp = e.Data.TimeStamp;
            Quality = e.Data.Quality.ToString();
        }

        //new zbog toga što u baznoj klasi vać postoji
        new public event PropertyChangedEventHandler PropertyChanged;
        void OnPropChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
