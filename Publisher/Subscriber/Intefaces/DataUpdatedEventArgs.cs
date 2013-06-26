using System;

namespace Publisher.Subscriber.Intefaces
{
    internal class DataUpdatedEventArgs<T> : EventArgs
    {
        public IData<T> Data { get; private set; }

        public DataUpdatedEventArgs(IData<T> data)
        {
            Data = data;
        }
    }
}
