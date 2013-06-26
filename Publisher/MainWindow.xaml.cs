using System;
using System.Windows;
using System.Collections.ObjectModel;

using PowerMonitoring.DataSource.Common;
using PowerMonitoring.DataSource.Common.Intefaces;
using PowerMonitoring.DataSource.MeasurementStudio;
using PowerMonitoring.DataSource.Simulator;

namespace Publisher
{
    public partial class MainWindow
    {
        private const string ProcessLocationRemote = @"\\161.53.66.11\S1 Modbus Library";
        private const string ProcessLocationLocal = @"\\Jure-PC\jure";
        readonly ServiceReference.ServiceClient _svc = new ServiceReference.ServiceClient();
        readonly ObservableCollection<ObservableSubscriber<Single>> _subscribers = new ObservableCollection<ObservableSubscriber<Single>>();
        private readonly IDataSource _dataSource;
        public MainWindow()
        {
            InitializeComponent();
            cbxProcesToAdd.Items.Add(ProcessLocationLocal);
            cbxProcesToAdd.Items.Add(ProcessLocationRemote);

            _dataSource = new SimulatedDataSource(_subscribers);
            _dataSource = new NationalInstrumentsDataSource(_subscribers);
            _dataSource.SubscriberDataUpdated += ObservableSubscriberDataUpdated;
            _dataSource.OnMassage += dataSource_OnMassage;

            DataContext = _subscribers;
        }

        void dataSource_OnMassage(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        void ObservableSubscriberDataUpdated(object sender, DataUpdatedEventArgs<float> e)
        {
            _svc.UpdateVariableSingleAsync(((ObservableSubscriber<Single>)sender).BrowserItem.Name, e.Data.GetValue(), e.Data.TimeStamp);
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
