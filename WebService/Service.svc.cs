using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WebService.Entities;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class Service :IService
    {
        readonly string singleTypeString = (typeof(Single)).ToString();
        readonly string doubleTypeString = (typeof(Double)).ToString();
        
        public List<ServiceVariable> ServiceVariables = new List<ServiceVariable>();

        System.Timers.Timer time;

        int longTimer = 0;

        void time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            longTimer++;

            if (longTimer>=60)
            {
                longTimer = 0;
                time_Elapsed_Minute(sender, e);       
            }

        }

        class ValueTime
        {
            public Single  Value { get; set; }
            public DateTime Time { get; set; }
        }

        void time_Elapsed_Minute(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                DateTime Sad = DateTime.UtcNow;
                DateTime SadBezMiliSec = (Sad.AddSeconds(-Sad.Second)).AddMilliseconds(-Sad.Millisecond);

                UpdateHistogramFromLog(SadBezMiliSec.AddMinutes(-1), SadBezMiliSec);
            }



        }

        void UpdateHistogramFromLog(DateTime dateTimeBegin,DateTime datetimeEnd)
        {
            using (var context = new PowerMonitoringModelContainer())
            {
                DateTime Sad = DateTime.UtcNow;
                DateTime SadBezMiliSec = (Sad.AddSeconds(-Sad.Second)).AddMilliseconds(-Sad.Millisecond);

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
                                Single average = m.Average(s => s.SingleValue);
                                var mPoredanPoVremenu = m.OrderBy(s => s.TimeStamp.Second);
                                Single a = 0;
                                Single Energy = 0;
                                DateTime timeA = new DateTime();

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
                                            Energy = log.SingleValue;
                                        }

                                    }
                                    else
                                    {
                                        Single trapez = ((a + log.SingleValue) / 2) * (Single)(log.TimeStamp - timeA).TotalSeconds;

                                        a = log.SingleValue;
                                        timeA = log.TimeStamp;

                                        Energy = Energy + trapez;
                                    }

                                }

                                Single snaga;
                                if (mPoredanPoVremenu.Count() == 1)
                                {
                                    snaga = Energy;
                                }

                                else
                                {
                                    snaga = Energy / (Single)(mPoredanPoVremenu.Last().TimeStamp - mPoredanPoVremenu.First().TimeStamp).TotalSeconds;
                                }

                                DateTime d = m.First().TimeStamp;
                                DateTime TimeStamp = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                                SingleHistogram histogram = SingleHistogram.CreateSingleHistogram(-1, snaga, TimeStamp, -1);

                                if (!variable.SingleHistogram.Any(s => s.TimeStamp == TimeStamp))
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

            if (time == null)
            {
                longTimer = DateTime.UtcNow.Second;
                time = new System.Timers.Timer(1000);
                time.Elapsed += new System.Timers.ElapsedEventHandler(time_Elapsed);
                time.AutoReset = true;
                time.Start();
            }

            #region Upisuje se u service

            ServiceVariable serviceVariable = null;



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
                VariableDto variableDto = new VariableDto
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
                Variable VariableEnty = null;
                try
                {
                    VariableEnty = (from v in context.VariableSet
                                    where v.Name == name
                                    select v).First();
                }
                catch (Exception)
                {
                    VariableEnty = Variable.CreateVariable(-1, name, singleTypeString, true);
                    context.AddToVariableSet(VariableEnty);
                    context.SaveChanges();
                }

                if (VariableEnty != null)
                {
                    //logiranje
                    if (VariableEnty.DataLoggingEnabled)
                    {
                        if (VariableEnty.Type == singleTypeString)
                        {
                            VariableEnty.SingleLogSet.Add(SingleLog.CreateSingleLog(-1, currentValue, timeStamp, -1));
                        }
                        if (VariableEnty.Type == doubleTypeString)
                        {
                            VariableEnty.DoubleLogSet.Add(DoubleLog.CreateDoubleLog(-1, currentValue, timeStamp, -1));
                        }
                    }
                    context.SaveChanges();


                    AlarmConfig alarmConfiguration = VariableEnty.AlarmConfigSet;
                    if (alarmConfiguration != null)
                    {

                        //High
                        if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "HI", alarmConfiguration.HI_LevelChange, alarmConfiguration.HI_Enable, UsporediHI, context) == false)
                        {
                            RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration,"HI","HIHI");
                        }
                        else
                        {
                            UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration,"HI","HIHI");
                        }

                        if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "HIHI", alarmConfiguration.HIHI_LevelChange, alarmConfiguration.HIHI_Enable, UsporediHI, context))
                        {
                            RemoveAlarmIfExist(context, alarmConfiguration, "HI");
                        }


                        //Low
                        if (UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "LO", alarmConfiguration.LO_LevelChange, alarmConfiguration.LO_Enable, UsporediLO, context) == false)
                        {
                            RemoveLowerAlarmIfHigherLevelExist(context, alarmConfiguration, "LO", "LOLO");
                        }
                        else
                        {
                            UpdateAcknowladgeFromHigherLevelIfExist(alarmConfiguration, "LO", "LOLO");
                        }
                        if ( UpdateAndAlarmReturnIsActive(currentValue, alarmConfiguration, "LOLO", alarmConfiguration.LOLO_LevelChange, alarmConfiguration.LOLO_Enabled, UsporediLO, context))
                        {
                            RemoveAlarmIfExist(context, alarmConfiguration, "LO");
                        }                     

                       context.SaveChanges();

                    }

                }

            }

        }

        private static void UpdateAcknowladgeFromHigherLevelIfExist(AlarmConfig alarmConfiguration, string lowerAlarmLevelName, string higherAlarmLevelName)
        {
            try
            {
                alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == lowerAlarmLevelName).First().Acknowledged =
                    alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == higherAlarmLevelName).First().Acknowledged;
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
                var alarm = alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == alarmLevelName).First();
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
                var alarm = alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == alarmLevelName).First();
                if (alarm == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool UpdateAndAlarmReturnIsActive(float currentValue, AlarmConfig alarmConfiguration, string AlarmLevelName, double alarmConfiguration_LevelChange, bool alarmConfigurationEnable, Usporedi delegateUsporedi, PowerMonitoringModelContainer context)
        {
            AlarmTerminal alarmTerminal = null;
            try
            {
                alarmTerminal = alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == AlarmLevelName).First();

            }
            catch (Exception)
            {
                alarmTerminal = null;
            }

            if (delegateUsporedi(currentValue, alarmConfiguration_LevelChange) && alarmConfigurationEnable)
            {
                if (alarmTerminal == null)
                {
                    bool Acnowladged = false;
                    if (AlarmLevelName == "HI")
                    {
                        try
                        {
                            Acnowladged = alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == "HIHI").First().Acknowledged;
                        }
                        catch (Exception)
                        {
                            Acnowladged = false;
                        }
                    }
                    if (AlarmLevelName == "LO")
                    {
                        try
                        {
                            Acnowladged = alarmConfiguration.AlarmTerminalSet.Where(s => s.AlarmLevelName == "LOLO").First().Acknowledged;
                        }
                        catch (Exception)
                        {
                            Acnowladged = false;
                        }
                    }

                    alarmTerminal = AlarmTerminal.CreateAlarmTerminal(-1, true, false, AlarmLevelName, currentValue, DateTime.Now, DateTime.Now, alarmConfiguration_LevelChange, 1,-1);
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
                        context.AlarmTerminalSet.DeleteObject(alarmTerminal);
                }
            }
            

            if (alarmTerminal!=null)
            {
                return alarmTerminal.Active;
            }
            else
            {
                return false;
            }

        }

        #region DelegatZaUsporedbu
        delegate bool Usporedi(double current, double max);
        private bool UsporediHI(double current, double max)
        {
            if (current >= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UsporediLO(double current, double max)
        {
            if (current <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        #endregion        

        #endregion

        public void AcknowledgeAlarm(int AlarmID)
        {
            using (var Context = new PowerMonitoringModelContainer())
            {
                try
                {
                    var alarm = (from activeAlarms in Context.AlarmTerminalSet
                                 where activeAlarms.Id == AlarmID
                                 select activeAlarms).First();

                    if (alarm.Acknowledged)
                    {
                        alarm.Acknowledged = false;
                    }
                    else
                    {
                        alarm.Acknowledged = true;
                    }

                    //Potrebno kada je publisher ugasen pa se variajbla ne updeta
                    if (alarm.Active == false && alarm.Acknowledged)
                    {
                        Context.DeleteObject(alarm);
                    }
                }
                catch (Exception)
                {
                    // implement
                }
                Context.SaveChanges();
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
                DateTime nowUct=DateTime.UtcNow.AddMinutes(-24);

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

                DateTime lastDay = DateTime.UtcNow.AddDays(-1);

                try
                {
                    return (from v in context.VariableSet
                            where v.Name == name && v.Type == singleTypeString
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