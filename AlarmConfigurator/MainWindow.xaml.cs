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

namespace AlarmConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PowerLogDBDataSet aset = new PowerLogDBDataSet();

        PowerLogDBDataSetTableAdapters.VariableSetTableAdapter variableAdap = new PowerLogDBDataSetTableAdapters.VariableSetTableAdapter();
        PowerLogDBDataSetTableAdapters.AlarmConfigSetTableAdapter alarmAdap = new PowerLogDBDataSetTableAdapters.AlarmConfigSetTableAdapter();

        public MainWindow()
        {
            InitializeComponent();

            variableAdap.Fill(aset.VariableSet);
            alarmAdap.Fill(aset.AlarmConfigSet);

            this.DataContext = aset.VariableSet;
            alarmConfigSetDataGrid.DataContext = aset.AlarmConfigSet;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddAlarmForSelectedVeriable_Click(object sender, RoutedEventArgs e)
        {
            PowerLogDBDataSet.VariableSetRow variable = ((System.Data.DataRowView)variableSetDataGrid.SelectedValue).Row as PowerLogDBDataSet.VariableSetRow;

            PowerLogDBDataSet.AlarmConfigSetRow alarmConfigRow =
            aset.AlarmConfigSet.NewRow() as PowerLogDBDataSet.AlarmConfigSetRow;

            try
            {
                aset.AlarmConfigSet.AddAlarmConfigSetRow(variable,
                                    true,
                                    variable.Name + " HIHI",
                                    90,
                                    0,
                                    true,
                                    variable.Name + " HI",
                                    75,
                                    0,
                                    true,
                                    variable.Name + " LO",
                                    20,
                                    0,
                                    true,
                                    variable.Name + " LOLO",
                                    10,
                                    0,
                                    true,
                                    variable.Type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #region Junk
            //PowerLogDBDataSet.AlarmConfigSetRow alarmConfigRow=row as PowerLogDBDataSet.AlarmConfigSetRow;

            //powerLogDBDataSet.AlarmConfigSet.AddAlarmConfigSetRow(new System.Data.DataRow
            //    new PowerLogDBDataSet.AlarmConfigSetRow())
            //    {
            //        Id = variable.Id,
            //        HIHI_Enable = true,
            //        HIHI_Name = variable.Name + "HIHI",
            //        HIHI_LevelChange = 90,
            //        HIHI_Delay = 0,
            //        HI_Enable = true,
            //        HI_Name = variable.Name + "HI",
            //        HI_LevelChange = 75,
            //        HI_Delay = "0",
            //        LO_Enable = true,
            //        LO_Name = variable.Name + "LO",
            //        LO_LevelChange = 20,
            //        LO_Delay = 0,
            //        LOLO_Enabled = true,
            //        LOLO_Name = variable.Name + "LOLO",
            //        LOLO_LevelChange = 10,
            //        LOLO_Delay = 0,
            //        Enabled = true,
            //        Location = variable.Type,

            //    });
            
            #endregion           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            alarmAdap.Update(aset);
           // aset.AcceptChanges();

        }
    }
}
