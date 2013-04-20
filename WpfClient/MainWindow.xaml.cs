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

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PowerMonitoringViewModel pwmViewModel = new PowerMonitoringViewModel();

        public MainWindow()
        {
            InitializeComponent();
           this.DataContext = pwmViewModel;


        }

        private void btnGetLastDay_Click(object sender, RoutedEventArgs e)
        {
            NetVariableViewModel variable = lbxVariable.SelectedItem as NetVariableViewModel;
            if (variable!=null)
            {
                pwmViewModel.GetAverageLastDay(variable.Name);
            }

        }
    } 
}
