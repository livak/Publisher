using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using NationalInstruments.NetworkVariable;

namespace Publisher
{



    public class MySingleSubscriber : NetworkVariableSubscriber<Single>,INotifyPropertyChanged
    {

        public BrowserItem BrowserItem { get; private set; }

        #region INotifyProperties

        private Single _currentValueSingle;
        public Single CurrentValueSingle
        {
            get { return _currentValueSingle; }
            private set
            {
                _currentValueSingle = value;
                this.OnPropChanged("CurrentValueSingle");
                CurrentValueString = value.ToString();
            }
        }

        private string currentValueString;
        public string CurrentValueString
        {
            get { return currentValueString; }
            set
            {
                currentValueString = value;
                this.OnPropChanged("CurrentValueString");
            }
        }

        private DateTime timeStamp;
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            private set
            {
                timeStamp = value;
                this.OnPropChanged("TimeStamp");
            }
        }

        private string _quality;
        public string Quality
        {
            get { return _quality; }
            private set
            {
                _quality = value;
                this.OnPropChanged("Quality");
            }
        }

        private int refreshRate;

        public int RefreshRate
        {
            get { return refreshRate; }
            set { refreshRate = value; OnPropChanged("RefreshRate"); }
        }

        

        #endregion

        #region Constructors

        public MySingleSubscriber(BrowserItem browserItem):base(browserItem.Path)
        {
            BrowserItem = browserItem;
            base.DataUpdated += new EventHandler<DataUpdatedEventArgs<float>>(MySubscriber_DataUpdated);
        }

        #endregion

        void MySubscriber_DataUpdated(object sender, DataUpdatedEventArgs<float> e)
        {
            CurrentValueSingle = e.Data.GetValue();

            if (TimeStamp != null)
            {
                RefreshRate = (int)(e.Data.TimeStamp - TimeStamp).TotalMilliseconds;
            }

            TimeStamp = e.Data.TimeStamp;
            Quality = e.Data.Quality.ToString();
        }


        #region INotifyPropertyChange

        //new zbog toga što u baznoj klasi vać postoji
        new public event PropertyChangedEventHandler PropertyChanged;

        void OnPropChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

    }  
    
    #region Junk
    //public class SingleSubscriber : INotifyPropertyChanged
    //{

    //    private NetworkVariableSubscriber<Single> Variable { get; set; }
    //    public BrowserItem BrowserItem { get; private set; }


    //    public event EventHandler<MyEventArgs> CurrentValueUpdated;

    //    #region INotifyProperties

    //    private Single _currentValueSingle;
    //    public Single CurrentValueSingle
    //    {
    //        get { return _currentValueSingle; }
    //        private set
    //        {
    //            _currentValueSingle = value;
    //            this.OnPropertyChanged("CurrentValue");
    //            CurrentValueString = value.ToString();
    //            CurrentValueUpdated(this, new MyEventArgs(this.BrowserItem.Name, value));
    //        }
    //    }

    //    private string currentValueString;
    //    public string CurrentValueString
    //    {
    //        get { return currentValueString; }
    //        set 
    //        { 
    //            currentValueString = value;
    //            this.OnPropertyChanged("CurrentValueString");
    //        }
    //    }



    //    private DateTime dataUpdateTime;
    //    public DateTime DataUpdateTime
    //    {
    //        get { return dataUpdateTime; }
    //        private set
    //        {
    //            dataUpdateTime = value;
    //            this.OnPropertyChanged("LastUpdateTime");
    //        }
    //    }

    //    private string _quality;
    //    public string Quality
    //    {
    //        get { return _quality; }
    //        private set
    //        {
    //            _quality = value;
    //            this.OnPropertyChanged("Quality");
    //        }
    //    }

    //    #endregion

    //    #region Constructors

    //    public SingleSubscriber(BrowserItem browserItem)
    //    {
    //        BrowserItem = browserItem;
    //        var type = BrowserItem.GetVariableType();

    //        if (type == typeof(Single))
    //        {
    //            subscribeSingle(BrowserItem.Path);
    //        }
    //        else
    //        {
    //            CurrentValueString = BrowserItem.GetVariableType().FullName;
    //        }
    //    }

    //    #endregion



    //    void subscribeSingle(string location)
    //    {
    //        Variable = new NetworkVariableSubscriber<float>(location);
    //        Variable.Connect();
    //        Variable.DataUpdated += new EventHandler<DataUpdatedEventArgs<float>>(variable_DataUpdated);
    //    }
    //    void variable_DataUpdated(object sender, DataUpdatedEventArgs<float> e)
    //    {
    //        CurrentValueSingle = e.Data.GetValue();

    //        DataUpdateTime = e.Data.TimeStamp;
    //        Quality = e.Data.Quality.ToString();
    //    }

    //    #region INotifyPropertyChange

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    void OnPropertyChanged(string propName)
    //    {
    //        if (this.PropertyChanged != null)
    //        {
    //            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
    //        }
    //    }

    //    #endregion

    //}

    //public class MyEventArgs : EventArgs
    //{
    //    public Single CurrentValue { get; private set; }
    //    public string Name { get; private set; }
    //    public MyEventArgs(string name,Single currentValue)
    //    {
    //        CurrentValue = currentValue;
    //        Name = name;
    //    }
    //}

    //public class MyEventArgs : EventArgs
    //{
    //    public Single CurrentValue { get; private set; }
    //    public string Name { get; private set; }
    //    public MyEventArgs(string name,Single currentValue)
    //    {
    //        CurrentValue = currentValue;
    //        Name = name;
    //    }
    //}
    
    #endregion

}
