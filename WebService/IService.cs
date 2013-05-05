using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebService.Entities;

namespace WebService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void UpdateVariableSingle(string name, Single currentValue, DateTime timeStamp);

        [OperationContract]
        void AcknowledgeAlarm(int alarmId);

        [OperationContract]
        List<VariableDto> GetVariables();

        [OperationContract]
        List<TerminalDto> GetTerminal();

        [OperationContract]
        List<HistogramDto> GetHistogram();

        [OperationContract]
        Single GetAverageLastDay(string name);
    }
}