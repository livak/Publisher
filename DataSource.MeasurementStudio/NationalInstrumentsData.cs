using System;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    class NationalInstrumentsData<T> : IData<T>
    {
        public bool HasQuality { get { return _data.HasQuality; } }
        public bool HasServerError { get { return _data.HasServerError; } }
        public bool HasTimeStamp { get { return _data.HasTimeStamp; } }
        public bool HasValue { get { return _data.HasValue; } }
        public bool IsQualityGood { get { return _data.IsQualityGood; } }
        public DataQualities Quality { get { return (DataQualities)_data.Quality; } }
        public DateTime TimeStamp { get { return _data.TimeStamp; } }

        private readonly NetworkVariableData<T> _data;

        public NationalInstrumentsData(NetworkVariableData<T> data)
        {
            _data = data;
        }

        public T GetValue()
        {
            return _data.GetValue();
        }
    }
}
