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
    public class TerminalViewModel : INotifyPropertyChanged
    {
        private readonly int _alarmId;
        private readonly ServiceClient _svc;

        private bool _acknowledged;
        public bool Acknowledged
        {
            get { return _acknowledged; }
            set
            {
                _acknowledged = value; OnPropertyChanged("Acknowledged"); SetAlarmStatusColor();
                if (_svc != null)
                {
                    _svc.AcknowledgeAlarmAsync(_alarmId);
                }

            }
        }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set { _active = value; OnPropertyChanged("Active"); SetAlarmStatusColor(); }
        }

        private string _alarmLevelName;
        public string AlarmLevelName
        {
            get { return _alarmLevelName; }
            set { _alarmLevelName = value; OnPropertyChanged("AlarmLevelName"); }
        }

        private double _maxValue;
        public double MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; OnPropertyChanged("MaxValue"); }
        }

        private DateTime _setTime;
        public DateTime SetTime
        {
            get { return _setTime; }
            set { _setTime = value; OnPropertyChanged("SetTime"); }
        }

        private string _variableName;
        public string VariableName
        {
            get { return _variableName; }
            private set
            {
                if (value != _variableName)
                {
                    _variableName = value;
                    OnPropertyChanged("VariableName");
                }
            }
        }

        private AlarmStatus _alarStatusColor;
        public AlarmStatus AlarmStausColor
        {
            get { return _alarStatusColor; }
            set { _alarStatusColor = value; OnPropertyChanged("AlarmStausColor"); }
        }

        private void SetAlarmStatusColor()
        {
            if (Acknowledged)
            {
                if (Active)
                {
                    AlarmStausColor = AlarmStatus.BlueAcknowledgedActive;
                }
            }
            else
            {
                AlarmStausColor = Active ? AlarmStatus.RedUnAcknowledgedActive : AlarmStatus.GreenUnAcknowledgedInActive;
            }
        }

        public TerminalViewModel(TerminalDto terminalDto, ServiceClient svc)
        {
            Acknowledged = terminalDto.Acknowledged;
            Active = terminalDto.Active;
            AlarmLevelName = terminalDto.AlarmLevelName;
            MaxValue = terminalDto.MaxValue;
            SetTime = terminalDto.SetTime;
            VariableName = terminalDto.VariableName;
            _alarmId = terminalDto.AlarmId;
            _svc = svc;
        }

        public void Update(TerminalDto terminalDto)
        {
            //Acknowledged = terminalDto.Acknowledged;
            Active = terminalDto.Active;
            // AlarmLevelName = terminalDto.AlarmLevelName;
            MaxValue = terminalDto.MaxValue;
            SetTime = terminalDto.SetTime;
            //VariableName = terminalDto.VariableName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
