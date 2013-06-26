using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IObservableSubscriber<T> : ISubscriber<T>
    {
        T CurrentValue { get; }
        string CurrentValueString { get; }
        DateTime TimeStamp { get; }
        string Quality { get; }
        int RefreshRate { get; }
        IBrowserItem BrowserItem { get; }
    }
}
