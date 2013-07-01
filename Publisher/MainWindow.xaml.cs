using System.Windows;
using System.Collections.ObjectModel;

using PowerMonitoring.DataSource.Common.Intefaces;
using PowerMonitoring.DataSource.MeasurementStudio;
using PowerMonitoring.DataSource.Simulator;

namespace Publisher
{
    public partial class MainWindow
    {
        private const string ProcessLocationRemote = @"\\161.53.66.11\S1 Modbus Library";
        private const string ProcessLocationLocal = @"\\localhost\Jure";

        readonly ServiceReference.ServiceClient _svc = new ServiceReference.ServiceClient();
        private readonly ObservableCollection<IObservableSubscriberBase> _subscribers = new ObservableCollection<IObservableSubscriberBase>();
        private readonly NationalInstrumentsDataSource<double> _dataSource;
        private readonly NationalInstrumentsDataSource _data;
        private readonly SimulatedDataSource<int> _simulatedDataSource;
        public MainWindow()
        {
            InitializeComponent();
            cbxProcesToAdd.Items.Add(ProcessLocationLocal);
            cbxProcesToAdd.Items.Add(ProcessLocationRemote);

            _dataSource = new NationalInstrumentsDataSource<double>(_subscribers);
            _dataSource.DataUpdated += ObservableSubscriberDataUpdated;
            _dataSource.Massage += dataSource_OnMassage;
            _dataSource.SubscribeFromLocation(ProcessLocationLocal);

            _data=new NationalInstrumentsDataSource(_subscribers);
            _data.Massage += dataSource_OnMassage;
            _data.DataUpdated += ObservableSubscriberDataUpdated;
            _data.SubscribeFromLocation(ProcessLocationLocal);
            _data.SubscribeFromLocation(ProcessLocationRemote);

            _simulatedDataSource=new SimulatedDataSource<int>(_subscribers);
            _simulatedDataSource.DataUpdated += ObservableSubscriberDataUpdated;
            _simulatedDataSource.Massage += dataSource_OnMassage;
            _simulatedDataSource.Subscribe(count: 3);

            DataContext = _subscribers;
        }

        void dataSource_OnMassage(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }      
        
        void ObservableSubscriberDataUpdated(object sender, DataUpdatedEventArgs e)
        {
            _svc.UpdateVariableSingleAsync(((IObservableSubscriberBase)sender).BrowserItem.Name, float.Parse(e.Data.GetValue().ToString()), e.Data.TimeStamp);
        }

        private void BtnAddProcessClick(object sender, RoutedEventArgs e)
        {
            if (cbxProcesToAdd.SelectedItem!=null)
            {
               //LoadBrowserToGetSubItemsAsync(cbxProcesToAdd.Text);
            }
            else
            {
                MessageBox.Show("Selected item Null");
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _dataSource.Dispose();
        }
    }
}
