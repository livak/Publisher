using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IObservableSubscriber<T> : ISubscriber<T>, IObservableSubscriberBase where T : struct
    {
         T CurrentValue { get; }
    }

    public interface IObservableSubscriberBase
    {
        string CurrentValueString { get; }
        DateTime TimeStamp { get; }
        string Quality { get; }
        int RefreshRate { get; }
        IBrowserItem BrowserItem { get; }
    }
}
