using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IDataSource : IDisposable
    {
        event EventHandler<MessageEventArgs> OnMassage;
        event EventHandler<DataUpdatedEventArgs<float>> SubscriberDataUpdated;
    }
}