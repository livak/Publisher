using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IDataSource<T> : IDataSourceBase where T : struct
    {
         event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
    }

    public interface IDataSource : IDataSourceBase 
    {
        event EventHandler<DataUpdatedEventArgs> DataUpdated;
    }

    public interface IDataSourceBase : IDisposable
    {
        event EventHandler<MessageEventArgs> Massage;
    }
}