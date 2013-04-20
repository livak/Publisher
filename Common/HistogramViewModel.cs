using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Collections.ObjectModel;

#if SILVERLIGHT && WINDOWS_PHONE
using PanoramaApp1;
using PanoramaApp1.ServiceReference;
#endif


#if  !SILVERLIGHT
using WpfClient.ServiceReference;
#endif



namespace WpfClient
{
    public class HistogramViewModel : INotifyPropertyChanged
    {

        #region INotifyProperties

        private Single singleValue;

        public Single SingleValue
        {
            get { return singleValue; }
            set {

                singleValue = value;
                NotifyPropertyChanged("SingleValue"); }
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; NotifyPropertyChanged("TimeStamp"); }
        }
               
        #endregion

        #region Constructors

        public HistogramViewModel()
        {

        }

        public HistogramViewModel(HistogramDto histogramDto)
        {
            SingleValue = histogramDto.SingleValue;
            TimeStamp = histogramDto.TimeStamp;
        }


        #endregion



        public void Update(HistogramDto histogramDto)
        {
            SingleValue = histogramDto.SingleValue;
            TimeStamp = histogramDto.TimeStamp;
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

}
