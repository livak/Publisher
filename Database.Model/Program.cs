using System;
using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Repository;

namespace Database.Model
{
    class Program
    {
        static void Main(string[] args)
        {

            var variableRepo = new VariableRepository();
            var variable = new Variable
                               {
                                   Name = "1",
                                   Type = "1",
                                   DataLoggingEnabled = true,
                                   AlarmConfiguration = new AlarmConfiguration()
                               };

            var singleLogs = variable.SingleLogs;
            for (int i = 0; i < 20; i++)
            {
                var singlelog = new SingleLog
                {
                    SingleValue = i,
                    TimeStamp =  DateTime.Now,
                }; 
                
                singleLogs.Add(singlelog);
            }


            var alarmlevelconfiguration = new AlarmLevelConfiguration
            {
                Enabled = true,
                Name = "1",
                LevelChange = 1,
                Delay = 1,
            };

            var alarmconfiguration = variable.AlarmConfiguration;
            alarmconfiguration.HIHI = alarmlevelconfiguration;
            alarmconfiguration.HI = alarmlevelconfiguration;
            alarmconfiguration.LO = alarmlevelconfiguration;
            alarmconfiguration.LOLO = alarmlevelconfiguration;
            alarmconfiguration.Enabled = true;
            alarmconfiguration.Location = "1";

            variable.AlarmConfiguration = alarmconfiguration;
            variable.SingleLogs = singleLogs;

            //var varfromDB = variableRepo.Insert(variable, true);

            var varfromDB = variableRepo.Context.Variables.Find(8);

        }
    }
}
