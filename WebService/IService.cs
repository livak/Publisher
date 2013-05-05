using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebService.Entities;

namespace WebService
{
    [ServiceContract]
    public interface IService
    {
        //[OperationContract]
        //void UpdateVariable(string name,string currentValue);

        //[OperationContract]
        //VariableDto GetVariable(string Name);

        [OperationContract]
        void UpdateVariableSingle(string name, Single currentValue, DateTime timeStamp);

        [OperationContract]
        void AcknowledgeAlarm(int AlarmID);

        [OperationContract]
        List<VariableDto> GetVariables();

        [OperationContract]
        List<TerminalDto> GetTerminal();

        [OperationContract]
        List<HistogramDto> GetHistogram();

        [OperationContract]
        Single GetAverageLastDay(string Name);
    }
}