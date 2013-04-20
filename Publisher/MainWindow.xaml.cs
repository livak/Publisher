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


using NationalInstruments.NetworkVariable;

using System.Collections.ObjectModel;

namespace Publisher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string processLocationRemote = @"\\161.53.66.11\S1 Modbus Library";
        readonly string processLocationLocal = @"\\Jure-PC\jure";

        ObservableCollection<MySingleSubscriber> subscribers = new ObservableCollection<MySingleSubscriber>();
        NationalInstruments.NetworkVariable.Browser browser;


        ServiceReference.ServiceClient _svc = new ServiceReference.ServiceClient();

        public MainWindow()
        {
            InitializeComponent();
            cbxProcesToAdd.Items.Add(processLocationLocal);
            cbxProcesToAdd.Items.Add(processLocationRemote);


            browser = new Browser();
            browser.GetSubitemsCompleted += new EventHandler<GetSubitemsCompletedEventArgs>(browser_GetSubitemsCompleted);

            LoadBrowserToGetSubItemsAsync(processLocationRemote);
            LoadBrowserToGetSubItemsAsync(processLocationLocal);
            this.DataContext = subscribers;


        }

        private void LoadBrowserToGetSubItemsAsync(string processLocation)
        {
            BrowserItem process = null;
            try
            {
                if (browser.TryGetItem(processLocation, out process))
                {
                    browser.GetSubitemsAsync(process, browser);
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

        void browser_GetSubitemsCompleted(object sender, GetSubitemsCompletedEventArgs e)
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

        private void SubscribeVariables(BrowserItem[] variables)
        {
            foreach (BrowserItem bi in variables)
            {
                if (bi.ItemType == BrowserItemType.Item && bi.GetVariableType() == typeof(Single))
                {
                    MySingleSubscriber subscriberSingle = new MySingleSubscriber(bi);
                    subscriberSingle.ConnectCompleted += new EventHandler<ConnectCompletedEventArgs>(subscriberSingle_ConnectCompleted);
                    subscriberSingle.ConnectAsync();
                }
            }
        }


        void subscriberSingle_ConnectCompleted(object sender, ConnectCompletedEventArgs e)
        {
            MySingleSubscriber subscriber = sender as MySingleSubscriber;
            if (e.Error==null && subscriber!=null)
            {
                subscriber.DataUpdated += new EventHandler<DataUpdatedEventArgs<float>>(subscriberSingle_DataUpdated);
                subscribers.Add(subscriber);
            }
            else
            {
                MessageBox.Show("Variable: " + subscriber.BrowserItem.Name + " failed to subscribe");
            }
        }
        void subscriberSingle_DataUpdated(object sender, DataUpdatedEventArgs<float> e)
        {
            
           // _svc.UpdateVariableAsync(((MySingleSubscriber)sender).BrowserItem.Name, e.Data.GetValue().ToString());

            _svc.UpdateVariableSingleAsync(((MySingleSubscriber)sender).BrowserItem.Name, e.Data.GetValue(), e.Data.TimeStamp);      
        }

        private void btnAddProcess_Click(object sender, RoutedEventArgs e)
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //potrebno je desposat browser zbog toga što se javlja error pri zatvaranju programa
            browser.Dispose();
        }
    }
}
