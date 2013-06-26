using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public class DataUpdatedEventArgs<T> : EventArgs
    {
        public IData<T> Data { get; private set; }

        public DataUpdatedEventArgs(IData<T> data)
        {
            Data = data;
        }
    }
}
