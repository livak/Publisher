using System;
using System.ComponentModel;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    class NationalInstrumentsSubscriber<T> : ISubscriber<T> where T : struct
    {
        public event EventHandler<Common.Intefaces.DataUpdatedEventArgs<T>> DataUpdated;
        public void OnDataUpdated(Common.Intefaces.DataUpdatedEventArgs<T> e)
        {
            EventHandler<Common.Intefaces.DataUpdatedEventArgs<T>> handler = DataUpdated;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        public void OnConnectCompleted(AsyncCompletedEventArgs e)
        {
            EventHandler<AsyncCompletedEventArgs> handler = ConnectCompleted;
            if (handler != null) handler(this, e);
        }

        private readonly NetworkVariableSubscriber<T> _networkVariableSubscriber;

        public NationalInstrumentsSubscriber(string location)
        {
            _networkVariableSubscriber = new NetworkVariableSubscriber<T>(location);
            _networkVariableSubscriber.DataUpdated += NetworkVariableSubscriberDataUpdated;
            _networkVariableSubscriber.ConnectCompleted += SubscriberConnectCompleted;
        }

        public void ConnectAsync()
        {
            _networkVariableSubscriber.ConnectAsync();
        }

        private void NetworkVariableSubscriberDataUpdated(object sender, NationalInstruments.NetworkVariable.DataUpdatedEventArgs<T> e)
        {
            var eventArgs = new Common.Intefaces.DataUpdatedEventArgs<T>(new NationalInstrumentsData<T>(e.Data));
            OnDataUpdated(eventArgs);
        }

        private void SubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            OnConnectCompleted(e);
        }
    }
}
