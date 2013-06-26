using System;
using System.ComponentModel;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    class NationalInstrumentsSubscriber<T> : ISubscriber<T>
    {
        public event EventHandler<PowerMonitoring.DataSource.Common.Intefaces.DataUpdatedEventArgs<T>> DataUpdated;
        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
            
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

        private void NetworkVariableSubscriberDataUpdated(object sender, global::NationalInstruments.NetworkVariable.DataUpdatedEventArgs<T> e)
        {
            var eventArgs = new PowerMonitoring.DataSource.Common.Intefaces.DataUpdatedEventArgs<T>(new NationalInstrumentsData<T>(e.Data));
            DataUpdated(this, eventArgs);
        }

        private void SubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ConnectCompleted(this, e);
        }
    }
}
