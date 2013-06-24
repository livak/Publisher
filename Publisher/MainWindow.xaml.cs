using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using NationalInstruments.NetworkVariable;

using System.Collections.ObjectModel;

namespace Publisher
{
    public partial class MainWindow
    {
        private const string ProcessLocationRemote = @"\\161.53.66.11\S1 Modbus Library";
        private const string ProcessLocationLocal = @"\\Jure-PC\jure";
        readonly ServiceReference.ServiceClient _svc = new ServiceReference.ServiceClient();
        readonly ObservableCollection<MySingleSubscriber> _subscribers = new ObservableCollection<MySingleSubscriber>();
        readonly Browser _browser;

        public MainWindow()
        {
            InitializeComponent();
            cbxProcesToAdd.Items.Add(ProcessLocationLocal);
            cbxProcesToAdd.Items.Add(ProcessLocationRemote);

            _browser = new Browser();
            _browser.GetSubitemsCompleted += BrowserGetSubitemsCompleted;

            LoadBrowserToGetSubItemsAsync(ProcessLocationRemote);
            LoadBrowserToGetSubItemsAsync(ProcessLocationLocal);
            DataContext = _subscribers;
        }

        private void LoadBrowserToGetSubItemsAsync(string processLocation)
        {
            try
            {
                BrowserItem process;
                if (_browser.TryGetItem(processLocation, out process))
                {
                    _browser.GetSubitemsAsync(process, _browser);
                }
                else
                {
                    MessageBox.Show("Failed to get process from location \n\r:" + processLocation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void BrowserGetSubitemsCompleted(object sender, GetSubitemsCompletedEventArgs e)
        {
            if (e.Error==null && e.Items!=null)
            {
                SubscribeVariables(e.Items);
            }
            else
            {
                MessageBox.Show("Failed to get process SubItems");
            }
        }

        private void SubscribeVariables(IEnumerable<BrowserItem> variables)
        {
            foreach (BrowserItem browserItem in variables)
            {
                if (browserItem.ItemType == BrowserItemType.Item && browserItem.GetVariableType() == typeof(Single))
                {
                    var subscriberSingle = new MySingleSubscriber(browserItem);
                    subscriberSingle.ConnectCompleted += SubscriberSingleConnectCompleted;
                    subscriberSingle.ConnectAsync();
                }
            }
        }

        void SubscriberSingleConnectCompleted(object sender, ConnectCompletedEventArgs e)
        {
            var subscriber = sender as MySingleSubscriber;
            if (e.Error == null && subscriber != null)
            {
                subscriber.DataUpdated += SubscriberSingleDataUpdated;
                _subscribers.Add(subscriber);
            }
            else
            {
                if (subscriber != null)
                    MessageBox.Show("Variable: " + subscriber.BrowserItem.Name + " failed to subscribe");
            }
        }
        void SubscriberSingleDataUpdated(object sender, DataUpdatedEventArgs<float> e)
        {
            _svc.UpdateVariableSingleAsync(((MySingleSubscriber)sender).BrowserItem.Name, e.Data.GetValue(), e.Data.TimeStamp);      
        }

        private void BtnAddProcessClick(object sender, RoutedEventArgs e)
        {
            if (cbxProcesToAdd.SelectedItem!=null)
            {
               LoadBrowserToGetSubItemsAsync(cbxProcesToAdd.Text);
            }
            else
            {
                MessageBox.Show("Selected item Null");
            }
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            _browser.Dispose();
        }
    }
}
