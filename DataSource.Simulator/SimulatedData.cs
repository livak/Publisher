using System;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    class SimulatedData<T> : IData<T>
    {
        public bool HasQuality { get; private set; }
        public bool HasServerError { get; private set; }
        public bool HasTimeStamp { get; private set; }
        public bool HasValue { get; private set; }
        public bool IsQualityGood { get; private set; }
        public DataQualities Quality { get; private set; }
        public DateTime TimeStamp { get; private set; }

        private readonly float _randomNumber;

        public SimulatedData(Random random)
        {
            Quality = DataQualities.Good;
            TimeStamp = DateTime.Now;
            _randomNumber = 100*(float) random.NextDouble();
        }

        public T GetValue()
        {
            return (T) (object) _randomNumber;
        }
    }
}
