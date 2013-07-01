using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public class DataUpdatedEventArgs<T> : DataUpdatedEventArgs where T : struct
    {
        public new IData<T> Data { get; private set; }

        public DataUpdatedEventArgs(IData<T> data) : base(data)
        {
            Data = data;
        }
    }    
    
    public class DataUpdatedEventArgs : EventArgs
    {
        public IData Data { get; private set; }

        public DataUpdatedEventArgs(IData data)
        {
            Data = data;
        }
    }
}
