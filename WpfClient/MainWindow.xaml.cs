using System.Windows;

namespace WpfClient
{
    public partial class MainWindow
    {
        private readonly PowerMonitoringViewModel _pwmViewModel = new PowerMonitoringViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _pwmViewModel;
        }

        private void btnGetLastDay_Click(object sender, RoutedEventArgs e)
        {
            var variable = lbxVariable.SelectedItem as NetVariableViewModel;
            if (variable != null)
            {
                _pwmViewModel.GetAverageLastDay(variable.Name);
            }
        }
    }
}
