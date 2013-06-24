using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

#if SILVERLIGHT && WINDOWS_PHONE
using PanoramaApp1.ServiceReference;
#endif

#if  !SILVERLIGHT
using WpfClient.ServiceReference;
#endif

namespace WpfClient
{
    public class NetVariableViewModel:INotifyPropertyChanged
    {
        private const int BufferSize = 20;
        public ObservableCollection<VariableSingle> SingleBuffer { get; private set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _currentValue;
        public string CurrentValue
        {
            get { return _currentValue; }
            private set
            {
                if (value != _currentValue)
                {
                    _currentValue = value;
                    OnPropertyChanged("CurrentValue");
                }

                if (SingleBuffer.Count >= BufferSize)
                {
                    SingleBuffer.RemoveAt(0);
                }
                var number = Single.Parse(value,new System.Globalization.CultureInfo("hr-HR").NumberFormat);
                SingleBuffer.Add(new VariableSingle(number));
            }
        }

        public NetVariableViewModel(VariableDto variableDto)
        {
            SingleBuffer = new ObservableCollection<VariableSingle>();
            Name = variableDto.VariableName;
            CurrentValue = variableDto.CurrentValue;
        }
        
        public void UpdateCurrentValue(string currentValue)
        {
            CurrentValue = currentValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
