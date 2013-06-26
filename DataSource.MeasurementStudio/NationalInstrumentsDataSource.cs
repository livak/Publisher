using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    public class NationalInstrumentsDataSource : IDataSource
    {
        public event EventHandler<MessageEventArgs> OnMassage;
        public event EventHandler<PowerMonitoring.DataSource.Common.Intefaces.DataUpdatedEventArgs<float>> SubscriberDataUpdated;

        private const string ProcessLocationRemote = @"\\161.53.66.11\S1 Modbus Library";
        private const string ProcessLocationLocal = @"\\Jure-PC\jure";

        private readonly ObservableCollection<ObservableSubscriber<Single>> _subscribers;

        private readonly Browser _browser;

        public NationalInstrumentsDataSource(ObservableCollection<ObservableSubscriber<float>> subscribers)
        {
            _subscribers = subscribers;

            _browser = new Browser();
            _browser.GetSubitemsCompleted += BrowserGetSubitemsCompleted;

            LoadBrowserToGetSubItemsAsync(ProcessLocationRemote);
            LoadBrowserToGetSubItemsAsync(ProcessLocationLocal);

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
                    TriggerMessageEvent("Failed to get process from location \n\r:" + processLocation);
                }
            }
            catch (Exception ex)
            {
                TriggerMessageEvent(ex.Message);
            }
        }

        private void BrowserGetSubitemsCompleted(object sender, GetSubitemsCompletedEventArgs e)
        {
            if (e.Error == null && e.Items != null)
            {
                SubscribeVariables(e.Items);
            }
            else
            {
                TriggerMessageEvent("Failed to get process SubItems");
            }
        }

        private void SubscribeVariables(IEnumerable<BrowserItem> variables)
        {
            foreach (BrowserItem browserItem in variables)
            {
                if (browserItem.ItemType == BrowserItemType.Item && browserItem.GetVariableType() == typeof (Single))
                {
                    IObservableSubscriber<Single> observableSubscriber = new ObservableSubscriber<float>(new NationalInstrumentsSubscriber<float>(browserItem.Path), new NationalInstrumentsBrowserItem(browserItem));
                    observableSubscriber.ConnectCompleted += ObservableSubscriberConnectCompleted;
                    observableSubscriber.ConnectAsync();
                }
            }
        }

        private void ObservableSubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var subscriber = sender as ObservableSubscriber<Single>;
            if (subscriber != null)
            {
                if (e.Error == null)
                {
                    subscriber.DataUpdated += SubscriberDataUpdated;
                    _subscribers.Add(subscriber);

                }
                else
                {
                    TriggerMessageEvent("Variable: " + subscriber.BrowserItem.Name + " failed to subscribe");
                }
            }
        }

        private void TriggerMessageEvent(string message)
        {
            if (OnMassage != null)
            {
                OnMassage(this, new MessageEventArgs(message));
            }
        }

        public void Dispose()
        {
            if (_browser != null)
            {
                _browser.Dispose();
            }
        }
    }
}
