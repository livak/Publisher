using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IData<out T> : IData where T : struct
    {
        new T GetValue();
    }

    public interface IData
    {
        object GetValue();
        bool HasQuality { get; }
        bool HasServerError { get; }
        bool HasTimeStamp { get; }
        bool HasValue { get; }
        bool IsQualityGood { get; }
        DataQualities Quality { get; }
        DateTime TimeStamp { get; }
    }

    public enum DataQualities : long
    {
        Good,
        Forced,
        InAlarm,
        InvalidUrl,
        ServerFailure,
        SensorFailure,
        NonExistent,
        Connectig,
        Disconected
    }
}
