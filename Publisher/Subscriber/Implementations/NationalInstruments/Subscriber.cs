using System;
using System.ComponentModel;
using NationalInstruments.NetworkVariable;
using Publisher.Subscriber.Intefaces;

namespace Publisher.Subscriber.Implementations.NationalInstruments
{
    internal class Subscriber<T> : ISubscriber<T>
    {
        public event EventHandler<Intefaces.DataUpdatedEventArgs<T>> DataUpdated;
        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;

        private readonly NetworkVariableSubscriber<T> _networkVariableSubscriber;

        public Subscriber(string location)
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
            var eventArgs = new Intefaces.DataUpdatedEventArgs<T>(new Data<T>(e.Data));
            DataUpdated(this, eventArgs);
        }

        private void SubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ConnectCompleted(this, e);
        }
    }
}
