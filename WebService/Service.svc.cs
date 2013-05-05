using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
                time_Elapsed_Minute(sender, e);       
            }
        }

        static void time_Elapsed_Minute(object sender, ElapsedEventArgs e)
        {
                DateTime sad = DateTime.UtcNow;
                DateTime sadBezMiliSec = (sad.AddSeconds(-sad.Second)).AddMilliseconds(-sad.Millisecond);
                UpdateHistogramFromLog(sadBezMiliSec.AddMinutes(-1), sadBezMiliSec);
        }

        static void UpdateHistogramFromLog(DateTime dateTimeBegin,DateTime datetimeEnd)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                foreach (var variable in context.VariableSet)
                {
                    var date = (from log in variable.SingleLogSet
                                where log.TimeStamp >= dateTimeBegin && log.TimeStamp < datetimeEnd
                                group log by log.TimeStamp.Date);

                    foreach (var day in date)
                    {
                        var hours = (from h in day
                                     group h by h.TimeStamp.Hour);
                        foreach (var hour in hours)
                        {
                            var minutes = (from min in hour
                                           group min by min.TimeStamp.Minute);
                            foreach (var m in minutes)
                            {
                                var mPoredanPoVremenu = m.OrderBy(s => s.TimeStamp.Second);
                                Single a = 0;
                                Single energy = 0;
                                var timeA = new DateTime();

                                bool prva = true;
                                foreach (var log in mPoredanPoVremenu)
                                {
                                    if (prva)
                                    {
                                        prva = false;
                                        a = log.SingleValue;
                                        timeA = log.TimeStamp;
                                        if (mPoredanPoVremenu.Count() == 1)
                                        {
                                            energy = log.SingleValue;
                                        }
                                    }
                                    else
                                    {
                                        Single trapez = ((a + log.SingleValue) / 2) * (Single)(log.TimeStamp - timeA).TotalSeconds;
                                        a = log.SingleValue;
                                        timeA = log.TimeStamp;
                                        energy = energy + trapez;
                                    }
                                }

                                Single snaga;
                                if (mPoredanPoVremenu.Count() == 1)
                                {
                                    snaga = energy;
                                }
                                else
                                {
                                    snaga = energy / (Single)(mPoredanPoVremenu.Last().TimeStamp - mPoredanPoVremenu.First().TimeStamp).TotalSeconds;
                                }

                                DateTime d = m.First().TimeStamp;
                                var timeStamp = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                                var histogram = SingleHistogram.CreateSingleHistogram(-1, snaga, timeStamp, -1);

                                if (variable.SingleHistogram.All(s => s.TimeStamp != timeStamp))
                                {
                                    variable.SingleHistogram.Add(histogram);
                                }
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        #region UpdateVariableSingle
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

            #region Upisuje se u service

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

            #endregion

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
                if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "HI", alarmConfiguration.HI_LevelChange, alarmConfiguration.HI_Enable, UsporediHi, context) == false)
                {
                    RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration,"HI","HIHI");
                }
                else
                {
                    UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration,"HI","HIHI");
                }

                if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "HIHI", alarmConfiguration.HIHI_LevelChange, alarmConfiguration.HIHI_Enable, UsporediHi, context))
                {
                    RemoveAlarmIfExist(context, alarmConfiguration, "HI");
                }


                //Low
                if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "LO", alarmConfiguration.LO_LevelChange, alarmConfiguration.LO_Enable, UsporediLo, context) == false)
                {
                    RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration, "LO", "LOLO");
                }
                else
                {
                    UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration, "LO", "LOLO");
                }
                if ( UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "LOLO", alarmConfiguration.LOLO_LevelChange, alarmConfiguration.LOLO_Enabled, UsporediLo, context))
                {
                    RemoveAlarmIfExist(context, alarmConfiguration, "LO");
                }                     

                context.SaveChanges();
            }
        }

        private static void UpdateAcknowladgeFromHigherLevelIfExist(AlarmConfig alarmConfiguration, string lowerAlarmLevelName, string higherAlarmLevelName)
        {
            try
            {
                alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == lowerAlarmLevelName).Acknowledged =
                    alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == higherAlarmLevelName).Acknowledged;
            }
            catch (Exception)
            {

            }
        }

        private static void RemoveLowerAlarmIfHigherLevelExist(PowerMonitoringModelContainer context, AlarmConfig alarmConfiguration, string lowerAlarmLevelName, string higherAlarmLevelName)
        {
            if (AlarmExist(alarmConfiguration, higherAlarmLevelName))
            {
                RemoveAlarmIfExist(context, alarmConfiguration, lowerAlarmLevelName);
            }
        }

        private static void RemoveAlarmIfExist(PowerMonitoringModelContainer context, AlarmConfig alarmConfiguration, string alarmLevelName)
        {
            try
            {
                var alarm = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == alarmLevelName);
                context.DeleteObject(alarm);
            }
            catch (Exception)
            {

            }
        }

        private static bool AlarmExist(AlarmConfig alarmConfiguration, string alarmLevelName)
        {
            try
            {
                var alarm = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == alarmLevelName);
                return alarm != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool UpdateAndAlarmReturnIsActive(float currentValue, AlarmConfig alarmConfiguration, string alarmLevelName, double alarmConfigurationLevelChange, bool alarmConfigurationEnable, Usporedi delegateUsporedi, PowerMonitoringModelContainer context)
        {
            AlarmTerminal alarmTerminal;
            try
            {
                alarmTerminal = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == alarmLevelName);

            }
            catch (Exception)
            {
                alarmTerminal = null;
            }

            if (delegateUsporedi(currentValue, alarmConfigurationLevelChange) && alarmConfigurationEnable)
            {
                if (alarmTerminal == null)
                {
                    bool Acnowladged = false;
                    if (alarmLevelName == "HI")
                    {
                        try
                        {
                            Acnowladged = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == "HIHI").Acknowledged;
                        }
                        catch (Exception)
                        {
                            Acnowladged = false;
                        }
                    }
                    if (alarmLevelName == "LO")
                    {
                        try
                        {
                            Acnowladged = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == "LOLO").Acknowledged;
                        }
                        catch (Exception)
                        {
                            Acnowladged = false;
                        }
                    }

                    alarmTerminal = AlarmTerminal.CreateAlarmTerminal(-1, true, false, alarmLevelName, currentValue, DateTime.Now, DateTime.Now, alarmConfigurationLevelChange, 1,-1);
                    alarmConfiguration.AlarmTerminalSet.Add(alarmTerminal);
                }
                else
                {
                    alarmTerminal.Active = true;
                    if (delegateUsporedi(currentValue, alarmTerminal.MaxValue))
                    {
                        alarmTerminal.MaxValue = currentValue;
                        alarmTerminal.MaxValueTime = DateTime.Now;
                    }

                }
            }
            else
            {
                if (alarmTerminal != null)
                {
                    alarmTerminal.Active = false;
                    if (alarmTerminal.Acknowledged)
                    {
                        context.AlarmTerminalSet.DeleteObject(alarmTerminal);
                    }
                }
            }
            
            return alarmTerminal!=null && alarmTerminal.Active;
        }

        #region DelegatZaUsporedbu
        delegate bool Usporedi(double current, double max);
        private static bool UsporediHi(double current, double max)
        {
            return current >= max;
        }

        private static bool UsporediLo(double current, double max)
        {
            return current <= max;
        }

        #endregion        

        #endregion

        public void AcknowledgeAlarm(int AlarmID)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                try
                {
                    var alarm = (from activeAlarms in context.AlarmTerminalSet
                                 where activeAlarms.Id == AlarmID
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


        #region Junk
        //private  void UpdateServiceListVariableDto(string name, string currentValue)
        //{
        //    bool variableExist = false;
        //    foreach (var variable in ServiceVariables.Where(s => s.VariableDto.VariableName == name))
        //    {
        //        variable.VariableDto.CurrentValue = currentValue;
        //        variableExist = true;
        //    }

        //    if (variableExist == false)
        //    {
        //        ServiceVariables.Add(
        //            new ServiceVariable(new VariableDto()
        //                                {
        //                                    CurrentValue = currentValue,
        //                                    VariableName = name,
        //                                }
        //        ));
        //    }
        //}

        //public void UpdateVariable(string name, string currentValue)
        //{

        //    using (var context= new PowerMonitoringModelContainer())
        //    {
        //        //ako nema dodaj
        //        if (context.VariableSet.Count(s => s.Name == name) == 0)
        //        {
        //            context.AddToVariableSet(Variable.CreateVariable(-1, name, singleTypeString));
        //            context.SaveChanges();
        //        }

        //        (from a in context.VariableSet
        //         where a.Name == name && a.Type == singleTypeString
        //         select a.SingleLog
        //         ).First().Add(SingleLog.CreateSingleLog(-1, Single.Parse(currentValue), DateTime.UtcNow, -1));
        //        context.SaveChanges();
        //    }

        //    UpdateServiceListVariableDto(name, currentValue);
        //}
        // int j = 1;
        #endregion
    }
}