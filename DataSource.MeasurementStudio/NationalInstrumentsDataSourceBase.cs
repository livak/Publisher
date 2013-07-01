using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    public abstract class NationalInstrumentsDataSourceBase : IDataSourceBase
    {
        protected ObservableCollection<IObservableSubscriberBase> Subscribers;
        protected Browser Browser;

        public event EventHandler<MessageEventArgs> Massage;

        public void OnMassage(string message)
        {
            EventHandler<MessageEventArgs> handler = Massage;
            if (handler != null) handler(this, new MessageEventArgs(message));
        }

        public void SubscribeFromLocationAsync(string location)
        {
            LoadBrowserToGetSubItemsAsync(location);
        }

        protected void LoadBrowserToGetSubItemsAsync(string processLocation)
        {
            try
            {
                BrowserItem process;
                if (Browser.TryGetItem(processLocation, out process))
                {
                    Browser.GetSubitemsAsync(process, Browser);
                }
                else
                {
                    OnMassage("Failed to get process from location \n\r:" + processLocation);
                }
            }
            catch (Exception ex)
            {
                OnMassage(ex.Message);
            }
        }

        protected void BrowserGetSubitemsCompleted(object sender, GetSubitemsCompletedEventArgs e)
        {
            if (e.Error == null && e.Items != null)
            {
                SubscribeVariables(e.Items);
            }
            else
            {
                OnMassage("Failed to get process SubItems");
            }
        }

        protected abstract void SubscribeVariables(IEnumerable<BrowserItem> variables);

        protected abstract void ObservableSubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e);

        public void Dispose()
        {
            if (Browser != null)
            {
                Browser.Dispose();
            }
        }
    }
}