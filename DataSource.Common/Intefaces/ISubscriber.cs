using System;
using System.ComponentModel;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface ISubscriber<T> : ISubscriberBase where T : struct
    {
        event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
    }

    public interface ISubscriberBase
    {
        event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        void ConnectAsync();
    }
}
