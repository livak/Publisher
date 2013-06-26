using System;

namespace Publisher.Subscriber.Intefaces
{
    internal interface IData<out T>
    {
        T GetValue();
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
