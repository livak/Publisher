using System;
using System.ComponentModel;
using System.Timers;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    class SimulatedSubscriber<T> : ISubscriber<T> where T : struct
    {
        public event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        public void OnDataUpdated(DataUpdatedEventArgs<T> e)
        {
            EventHandler<DataUpdatedEventArgs<T>> handler = DataUpdated;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;
        public void OnConnectCompleted(AsyncCompletedEventArgs e)
        {
            EventHandler<AsyncCompletedEventArgs> handler = ConnectCompleted;
            if (handler != null) handler(this, e);
        }

        private readonly Random _random;

        public SimulatedSubscriber(Random random)
        {
            _random = random;
            var timer = new Timer(1000);
            timer.Start();
            timer.AutoReset = true;
            timer.Elapsed += TimerElapsed;
        }

        public void ConnectAsync()
        {
            OnConnectCompleted(new AsyncCompletedEventArgs(null, false, new object()));
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnDataUpdated(new DataUpdatedEventArgs<T>(new SimulatedData<T>(_random)));
        }
    }
}
