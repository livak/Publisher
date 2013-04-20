using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class ValueTime
        {
            public Single Value { get; set; }
            public DateTime Time { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            using (var context = new PowerLogDBEntities())
            {
                DateTime Sad = DateTime.UtcNow;
                DateTime SadBezMiliSec = (Sad.AddSeconds(-Sad.Second)).AddMilliseconds(-Sad.Millisecond);

                foreach (var variable in context.VariableSet)
                {
                    var date = (from log in variable.SingleLogSet
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
                                        Single trapez = ((a + log.SingleValue) / 2) * (Single)(log.TimeStamp-timeA).TotalSeconds;
                                        
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
                                DateTime TimeStamp=new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                                SingleHistogramSet histogram = SingleHistogramSet.CreateSingleHistogramSet(-1,snaga,TimeStamp,-1);

                                 if (!variable.SingleHistogramSet.Any(s => s.TimeStamp == TimeStamp))
                                 {
                                     variable.SingleHistogramSet.Add(histogram);
                                 }                               
                            }
                        }
                    }
                }
               // context.SaveChanges();
            }


        }

        private System.Data.Objects.ObjectQuery<SingleHistogramSet> GetSingleHistogramSetQuery(PowerLogDBEntities powerLogDBEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<proba.SingleHistogramSet> singleHistogramSetQuery = powerLogDBEntities.SingleHistogramSet;
            // To explicitly load data, you may need to add Include methods like below:
            // singleHistogramSetQuery = singleHistogramSetQuery.Include("SingleHistogramSet.VariableSet").
            // For more information, please see http://go.microsoft.com/fwlink/?LinkId=157380
            // Returns an ObjectQuery.
            return singleHistogramSetQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            proba.PowerLogDBEntities powerLogDBEntities = new proba.PowerLogDBEntities();
            // Load data into SingleHistogramSet. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource singleHistogramSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("singleHistogramSetViewSource")));
            System.Data.Objects.ObjectQuery<proba.SingleHistogramSet> singleHistogramSetQuery = this.GetSingleHistogramSetQuery(powerLogDBEntities);
            singleHistogramSetViewSource.Source = singleHistogramSetQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
            // Load data into VariableSet. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource variableSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("variableSetViewSource")));
            System.Data.Objects.ObjectQuery<proba.VariableSet> variableSetQuery = this.GetVariableSetQuery(powerLogDBEntities);
            variableSetViewSource.Source = variableSetQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
            // Load data into SingleLogSet. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource singleLogSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("singleLogSetViewSource")));
            System.Data.Objects.ObjectQuery<proba.SingleLogSet> singleLogSetQuery = this.GetSingleLogSetQuery(powerLogDBEntities);
            singleLogSetViewSource.Source = singleLogSetQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private System.Data.Objects.ObjectQuery<VariableSet> GetVariableSetQuery(PowerLogDBEntities powerLogDBEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<proba.VariableSet> variableSetQuery = powerLogDBEntities.VariableSet;
            // To explicitly load data, you may need to add Include methods like below:
            // variableSetQuery = variableSetQuery.Include("VariableSet.AlarmConfigSet").
            // For more information, please see http://go.microsoft.com/fwlink/?LinkId=157380
            // Returns an ObjectQuery.
            return variableSetQuery;
        }

        private System.Data.Objects.ObjectQuery<SingleLogSet> GetSingleLogSetQuery(PowerLogDBEntities powerLogDBEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<proba.SingleLogSet> singleLogSetQuery = powerLogDBEntities.SingleLogSet;
            // To explicitly load data, you may need to add Include methods like below:
            // singleLogSetQuery = singleLogSetQuery.Include("SingleLogSet.VariableSet").
            // For more information, please see http://go.microsoft.com/fwlink/?LinkId=157380
            // Returns an ObjectQuery.
            return singleLogSetQuery;
        }
    }
}
