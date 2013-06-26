using System;
using System.ComponentModel;

namespace Publisher.Subscriber.Intefaces
{
    internal interface ISubscriber<T>
    {
        event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        void ConnectAsync();
    }
}
