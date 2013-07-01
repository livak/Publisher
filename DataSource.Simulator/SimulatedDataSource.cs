using System;
using System.Collections.ObjectModel;
using System.Globalization;
using PowerMonitoring.DataSource.Common;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    public class SimulatedDataSource<T> : IDataSource<T> where T : struct
    {
        private readonly ObservableCollection<IObservableSubscriberBase> _observableSubscribers;
        public event EventHandler<MessageEventArgs> Massage;

        public void OnMassage(MessageEventArgs e)
        {
            EventHandler<MessageEventArgs> handler = Massage;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        public void OnSubscriberDataUpdated(object sender, DataUpdatedEventArgs<T> e)
        {
            EventHandler<DataUpdatedEventArgs<T>> handler = DataUpdated;
            if (handler != null) handler(sender, e);
        }

        public SimulatedDataSource(ObservableCollection<IObservableSubscriberBase> observableSubscribers)
        {
            _observableSubscribers = observableSubscribers;
        }

        public void Subscribe(int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                IBrowserItem simulatedBrowserItem = new SimulatedBrowserItem("pero-" + i.ToString(CultureInfo.InvariantCulture), i.ToString(CultureInfo.InvariantCulture), typeof(T));
                ISubscriber<T> simulatedSubscriber = new SimulatedSubscriber<T>(random);

                var observableSubscriber = new ObservableSubscriber<T>(simulatedSubscriber, simulatedBrowserItem);
                observableSubscriber.DataUpdated += ObservableSubscriberDataUpdated;

                _observableSubscribers.Add(observableSubscriber);
            }
        }

        void ObservableSubscriberDataUpdated(object sender, DataUpdatedEventArgs<T> e)
        {
            OnSubscriberDataUpdated(sender, e);
        }

        public void Dispose()
        {
        }
    }
}
