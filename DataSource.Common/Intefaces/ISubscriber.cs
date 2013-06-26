using System;
using System.ComponentModel;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface ISubscriber<T>
    {
        event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        void ConnectAsync();
    }
}
