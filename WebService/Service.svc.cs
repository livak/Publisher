using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WebService.Business;
using WebService.Entities;
using System.Timers;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class Service :IService
    {
        readonly string _singleTypeString = (typeof(Single)).ToString();
        readonly string _doubleTypeString = (typeof(Double)).ToString();
        public List<ServiceVariable> ServiceVariables = new List<ServiceVariable>();
        Timer _time;
        int _longTimer;

        void time_Elapsed(object sender, ElapsedEventArgs e)
        {
            _longTimer++;

            if (_longTimer>=60)
            {
                _longTimer = 0;
               AlarmTools.time_Elapsed_Minute(sender, e);       
            }
        }

        public void UpdateVariableSingle(string name, float currentValue, DateTime timeStamp)
        {
            if (_time == null)
            {
                _longTimer = DateTime.UtcNow.Second;
                _time = new Timer(1000);
                _time.Elapsed += time_Elapsed;
                _time.AutoReset = true;
                _time.Start();
            }

            ServiceVariable serviceVariable;
            //ako postoji variabla pod imenom na servisu updejtaj vrijednost ako ne postoji kreiraj
            try
            {
                serviceVariable = (from v in ServiceVariables
                                   where v.VariableDto.VariableName == name
                                   select v).First();
                serviceVariable.VariableDto.CurrentValue = currentValue.ToString();
            }
            catch (Exception)
            {
                var variableDto = new VariableDto
                    {
                        CurrentValue = currentValue.ToString(),
                        VariableName = name,
                    };
                serviceVariable = new ServiceVariable(variableDto);
                ServiceVariables.Add(serviceVariable);
            }

            using (var context = new PowerMonitoringModelContainer())
            {
                //ako ne postoji entity na sevicu pogledaj dali variajbla postoji u bazi ako ne postoji kreiraj
                // provaj je naći u bazi pod imenom ako ne postoji kreiraj
                Variable variableEnty;
                try
                {
                    variableEnty = (from v in context.VariableSet
                                    where v.Name == name
                                    select v).First();
                }
                catch (Exception)
                {
                    variableEnty = Variable.CreateVariable(-1, name, _singleTypeString, true);
                    context.AddToVariableSet(variableEnty);
                    context.SaveChanges();
                }

                if (variableEnty == null) return;
                
                //logiranje
                if (variableEnty.DataLoggingEnabled)
                {
                    if (variableEnty.Type == _singleTypeString)
                    {
                        variableEnty.SingleLogSet.Add(SingleLog.CreateSingleLog(-1, currentValue, timeStamp, -1));
                    }
                    if (variableEnty.Type == _doubleTypeString)
                    {
                        variableEnty.DoubleLogSet.Add(DoubleLog.CreateDoubleLog(-1, currentValue, timeStamp, -1));
                    }
                }
                context.SaveChanges();

                AlarmConfig alarmConfiguration = variableEnty.AlarmConfigSet;
                if (alarmConfiguration == null) return;

                //High
                if (AlarmTools.UpdateAlarmAndReturnIsActive(currentValue, alarmConfiguration, "HI", alarmConfiguration.HI_LevelChange, alarmConfiguration.HI_Enable, AlarmTools.UsporediHi, context) == false)
                {
                    AlarmTools.RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration,"HI","HIHI");
                }
                else
                {
                    AlarmTools.UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration,"HI","HIHI");
                }

                if (AlarmTools.UpdateAlarmAndReturnIsActive(currentValue, alarmConfiguration, "HIHI", alarmConfiguration.HIHI_LevelChange, alarmConfiguration.HIHI_Enable, AlarmTools.UsporediHi, context))
                {
                    AlarmTools.RemoveAlarmIfExist(context, alarmConfiguration, "HI");
                }

                //Low
                if (AlarmTools.UpdateAlarmAndReturnIsActive(currentValue, alarmConfiguration, "LO", alarmConfiguration.LO_LevelChange, alarmConfiguration.LO_Enable, AlarmTools.UsporediLo, context) == false)
                {
                    AlarmTools.RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration, "LO", "LOLO");
                }
                else
                {
                    AlarmTools.UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration, "LO", "LOLO");
                }
                if (AlarmTools.UpdateAlarmAndReturnIsActive(currentValue, alarmConfiguration, "LOLO", alarmConfiguration.LOLO_LevelChange, alarmConfiguration.LOLO_Enabled, AlarmTools.UsporediLo, context))
                {
                    AlarmTools.RemoveAlarmIfExist(context, alarmConfiguration, "LO");
                }                     

                context.SaveChanges();
            }
        }

        public void AcknowledgeAlarm(int alarmId)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                try
                {
                    var alarm = (from activeAlarms in context.AlarmTerminalSet
                                 where activeAlarms.Id == alarmId
                                 select activeAlarms).First();

                    alarm.Acknowledged = !alarm.Acknowledged;

                    //Potrebno kada je publisher ugasen pa se variajbla ne updeta
                    if (alarm.Active == false && alarm.Acknowledged)
                    {
                        context.DeleteObject(alarm);
                    }
                }
                catch (Exception)
                {
                    // implement
                }
                context.SaveChanges();
            }
        }

        public List<VariableDto> GetVariables()
        {
            return (from d in ServiceVariables
                    select d.VariableDto).ToList();
        }

        public List<TerminalDto> GetTerminal()
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                List<TerminalDto> lista =
                    (from t in context.AlarmTerminalSet
                     select new TerminalDto
                         {
                             AlarmId = t.Id,
                             Acknowledged = t.Acknowledged,
                             Active = t.Active,
                             AlarmLevelName = t.AlarmLevelName,
                             MaxValue = t.MaxValue,
                             SetTime = t.SetTime,
                             VariableName = t.AlarmConfigSet.VariableSet.Name,
                         }).ToList();
                return lista;
            }
        }

        public List<HistogramDto> GetHistogram()
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                var nowUct = DateTime.UtcNow.AddMinutes(-24);

                var variabla = (from v in context.VariableSet
                                where v.Name == "Ptot"
                                select v).First();
                return (from histogram in variabla.SingleHistogram
                        where histogram.TimeStamp > nowUct
                        select new HistogramDto
                            {
                                SingleValue = histogram.SingleValue,
                                TimeStamp = histogram.TimeStamp,
                            }).ToList();
            }
        }

        public float GetAverageLastDay(string name)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                var lastDay = DateTime.UtcNow.AddDays(-1);

                try
                {
                    return (from v in context.VariableSet
                            where v.Name == name && v.Type == _singleTypeString
                            from log in v.SingleLogSet
                            where log.TimeStamp > lastDay
                            select log.SingleValue).Average();
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
    }
}