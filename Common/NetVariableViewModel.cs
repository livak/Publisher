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
    public class NetVariableViewModel:INotifyPropertyChanged
    {
        private const int bufferSize = 20;
        public ObservableCollection<VariableSingle> SingleBuffer { get; private set; }

        #region INotifyProperties
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (value != name)
                {
                    name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private string currentValue;
        public string CurrentValue
        {
            get { return currentValue; }
            private set
            {
                if (value != currentValue)
                {
                    currentValue = value;
                    this.NotifyPropertyChanged("CurrentValue");
                }

                if (SingleBuffer.Count >= bufferSize)
                {
                    SingleBuffer.RemoveAt(0);
                }
                Single s = Single.Parse(value,new System.Globalization.CultureInfo("hr-HR").NumberFormat);
                SingleBuffer.Add(new VariableSingle(s));
            }
        }


        #endregion

        #region Constructors
        public NetVariableViewModel(VariableDto variableDto)
        {
            SingleBuffer = new ObservableCollection<VariableSingle>();
            Name = variableDto.VariableName;
            CurrentValue = variableDto.CurrentValue;
        }
        
        #endregion


        public void UpdateCurrentValue(string currentValue)
        {
            CurrentValue = currentValue;
        }

        public class VariableSingle:INotifyPropertyChanged
        {

            private Single currentValue;
            public Single CurrentValue
            {
                get { return currentValue; }
                set 
                {
                    if (value != currentValue)
                    {
                        currentValue = value;
                        NotifyPropertyChanged("CurrentValue");
                    }

                    TimeStamp = DateTime.Now;
                }
            }

            private DateTime timeStamp;
            public DateTime TimeStamp
            {
                get { return timeStamp; }
                set
                {
                    if (value != timeStamp)
                    {
                        timeStamp = value;
                        NotifyPropertyChanged("TimeStamp");
                    }
                }
            }

            public VariableSingle(Single value)
            {
                CurrentValue = value;
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
