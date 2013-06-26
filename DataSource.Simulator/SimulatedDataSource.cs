using System;
using System.Collections.ObjectModel;
using System.Globalization;
using PowerMonitoring.DataSource.Common;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    public class SimulatedDataSource : IDataSource
    {
        public event EventHandler<MessageEventArgs> OnMassage;
        public event EventHandler<DataUpdatedEventArgs<float>> SubscriberDataUpdated;

        public SimulatedDataSource(ObservableCollection<ObservableSubscriber<float>> observableSubscribers)
        {
            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                IBrowserItem simulatedBrowserItem = new SimulatedBrowserItem("pero-" + i.ToString(CultureInfo.InvariantCulture), i.ToString(CultureInfo.InvariantCulture));
                ISubscriber<float> simulatedSubscriber = new SimulatedSubscriber<float>(random);

                var observableSubscriber = new ObservableSubscriber<float>(simulatedSubscriber, simulatedBrowserItem);
                observableSubscriber.DataUpdated += SubscriberDataUpdated;

                observableSubscribers.Add(observableSubscriber);
            }
        }

        public void Dispose()
        {
        }
    }
}
