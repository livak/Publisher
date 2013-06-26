using System;
using System.ComponentModel;
using System.Timers;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    class SimulatedSubscriber<T> : ISubscriber<T>
    {
        public event EventHandler<DataUpdatedEventArgs<T>> DataUpdated;
        public event EventHandler<AsyncCompletedEventArgs> ConnectCompleted;

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
            ConnectCompleted(this, new AsyncCompletedEventArgs(null, false, new object()));
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            DataUpdated(this, new DataUpdatedEventArgs<T>(new SimulatedData<T>(_random)));
        }
    }
}
