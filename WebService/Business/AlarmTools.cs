using System;
using System.Linq;
using System.Timers;

namespace WebService.Business
{
    public class AlarmTools
    {
        // delegate
        public delegate bool Usporedi(double current, double max);

        // delegate methods
        public static bool UsporediHi(double current, double max)
        {
            return current >= max;
        }

        public static bool UsporediLo(double current, double max)
        {
            return current <= max;
        }

        //public methods
        public static void time_Elapsed_Minute(object sender, ElapsedEventArgs e)
        {
            DateTime sad = DateTime.UtcNow;
            DateTime sadBezMiliSec = (sad.AddSeconds(-sad.Second)).AddMilliseconds(-sad.Millisecond);
            UpdateHistogramFromLog(sadBezMiliSec.AddMinutes(-1), sadBezMiliSec);
        }

        public static bool UpdateAcknowladgeFromHigherLevelIfExist(AlarmConfig alarmConfiguration, string lowerAlarmLevelName, string higherAlarmLevelName)
        {
            try
            {
                alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == lowerAlarmLevelName).Acknowledged = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == higherAlarmLevelName).Acknowledged;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveLowerAlarmIfHigherLevelExist(PowerMonitoringModelContainer context, AlarmConfig alarmConfiguration, string lowerAlarmLevelName, string higherAlarmLevelName)
        {
            return AlarmExist(alarmConfiguration, higherAlarmLevelName) && RemoveAlarmIfExist(context, alarmConfiguration, lowerAlarmLevelName);
        }

        public static bool RemoveAlarmIfExist(PowerMonitoringModelContainer context, AlarmConfig alarmConfiguration, string alarmLevelName)
        {
            try
            {
                var alarm = alarmConfiguration.AlarmTerminalSet.First(s => s.AlarmLevelName == alarmLevelName);
                context.DeleteObject(alarm);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateAlarmAndReturnIsActive(float currentValue, AlarmConfig alarmConfiguration, string alarmLevelName, double alarmConfigurationLevelChange, bool alarmConfigurationEnable, Usporedi delegateUsporedi, PowerMonitoringModelContainer context)
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

        //private methods
        private static void UpdateHistogramFromLog(DateTime dateTimeBegin, DateTime datetimeEnd)
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
    }
}