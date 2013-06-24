using System;
using System.ComponentModel;

#if SILVERLIGHT && WINDOWS_PHONE
using PanoramaApp1.ServiceReference;
#endif

#if  !SILVERLIGHT
using WpfClient.ServiceReference;
#endif

namespace WpfClient
{
    public class HistogramViewModel : INotifyPropertyChanged
    {
        private Single _singleValue;
        public Single SingleValue
        {
            get { return _singleValue; }
            set { _singleValue = value; OnPropertyChanged("SingleValue"); }
        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; OnPropertyChanged("TimeStamp"); }
        }
               
        public HistogramViewModel()
        {
        }

        public HistogramViewModel(HistogramDto histogramDto)
        {
            SingleValue = histogramDto.SingleValue;
            TimeStamp = histogramDto.TimeStamp;
        }

        public void Update(HistogramDto histogramDto)
        {
            SingleValue = histogramDto.SingleValue;
            TimeStamp = histogramDto.TimeStamp;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}