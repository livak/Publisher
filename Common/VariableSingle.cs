using System;
using System.ComponentModel;

namespace WpfClient
{
    public class VariableSingle : INotifyPropertyChanged
    {
        private Single _currentValue;
        public Single CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (Math.Abs(value - _currentValue) > 0.001)
                {
                    _currentValue = value;
                    OnPropertyChanged("CurrentValue");
                }

                TimeStamp = DateTime.Now;
            }
        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (value != _timeStamp)
                {
                    _timeStamp = value;
                    OnPropertyChanged("TimeStamp");
                }
            }
        }

        public VariableSingle(Single value)
        {
            CurrentValue = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}