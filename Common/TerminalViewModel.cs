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
    public class TerminalViewModel : INotifyPropertyChanged
    {

        #region INotifyProperties

        private bool acknowledged;
        public bool Acknowledged
        {
            get { return acknowledged; }
            set
            {
                acknowledged = value; this.NotifyPropertyChanged("Acknowledged"); SetAlarmStatusColor();
                if (_svc != null)
                {
                    _svc.AcknowledgeAlarmAsync(alarmId);
                }

            }
        }

        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; this.NotifyPropertyChanged("Active"); SetAlarmStatusColor(); }
        }

        private string alarmLevelName;
        public string AlarmLevelName
        {
            get { return alarmLevelName; }
            set { alarmLevelName = value; this.NotifyPropertyChanged("AlarmLevelName"); }
        }

        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; this.NotifyPropertyChanged("MaxValue"); }
        }

        private DateTime setTime;
        public DateTime SetTime
        {
            get { return setTime; }
            set { setTime = value; this.NotifyPropertyChanged("SetTime"); }
        }

        private string variableName;
        public string VariableName
        {
            get { return variableName; }
            private set
            {
                if (value != variableName)
                {
                    variableName = value;
                    this.NotifyPropertyChanged("VariableName");
                }
            }
        }

        private AlarmStatus alarStatusColor;

        public AlarmStatus AlarmStausColor
        {
            get { return alarStatusColor; }
            set { alarStatusColor = value; NotifyPropertyChanged("AlarmStausColor"); }
        }

        private void SetAlarmStatusColor()
        {
            if (Acknowledged)
            {
                if (Active)
                {
                    AlarmStausColor = AlarmStatus.Blue_AcknowledgedActive;
                }
            }
            else
            {
                if (Active)
                {
                    AlarmStausColor = AlarmStatus.Red_UnAcknowledgedActive;
                }
                else
                {
                    AlarmStausColor = AlarmStatus.Green_UnAcknowledgedInActive;
                }
            }
        }

        private int alarmId;

        #endregion

        private ServiceClient _svc;

        #region Constructors
        public TerminalViewModel(TerminalDto terminalDto, ServiceClient _svc)
        {
            Acknowledged = terminalDto.Acknowledged;
            Active = terminalDto.Active;
            AlarmLevelName = terminalDto.AlarmLevelName;
            MaxValue = terminalDto.MaxValue;
            SetTime = terminalDto.SetTime;
            VariableName = terminalDto.VariableName;
            alarmId = terminalDto.AlarmId;
            this._svc = _svc;

        }

        #endregion



        public void Update(TerminalDto terminalDto)
        {
            //Acknowledged = terminalDto.Acknowledged;
            Active = terminalDto.Active;
           // AlarmLevelName = terminalDto.AlarmLevelName;
            MaxValue = terminalDto.MaxValue;
            SetTime = terminalDto.SetTime;
            //VariableName = terminalDto.VariableName;
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

    public enum AlarmStatus
    {
        Red_UnAcknowledgedActive,
        Green_UnAcknowledgedInActive,
        Blue_AcknowledgedActive,
    }

}
