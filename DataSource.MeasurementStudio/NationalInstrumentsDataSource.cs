using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    public class NationalInstrumentsDataSource<T> :NationalInstrumentsDataSourceBase, IDataSource<T> where T : struct
    {
        public event EventHandler<Common.Intefaces.DataUpdatedEventArgs<T>> DataUpdated;
        public void OnSubscriberDataUpdated(object sender, Common.Intefaces.DataUpdatedEventArgs<T> e)
        {
            EventHandler<Common.Intefaces.DataUpdatedEventArgs<T>> handler = DataUpdated;
            if (handler != null) handler(sender, e);
        }

        public NationalInstrumentsDataSource(ObservableCollection<IObservableSubscriberBase> subscribers)
        {
            Subscribers = subscribers;
            Browser = new Browser();
            Browser.GetSubitemsCompleted += BrowserGetSubitemsCompleted;
        }

        protected override void SubscribeVariables(IEnumerable<BrowserItem> variables)
        {
            foreach (BrowserItem browserItem in variables)
            {
                if (browserItem.ItemType == BrowserItemType.Item && browserItem.GetVariableType() == typeof(T))
                {
                    IObservableSubscriber<T> observableSubscriber = new ObservableSubscriber<T>(new NationalInstrumentsSubscriber<T>(browserItem.Path), new NationalInstrumentsBrowserItem(browserItem));
                    observableSubscriber.ConnectCompleted += ObservableSubscriberConnectCompleted;
                    observableSubscriber.ConnectAsync();
                }
            }
        }

        protected override void ObservableSubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var subscriber = sender as IObservableSubscriber<T>;
            if (subscriber != null)
            {
                if (e.Error == null)
                {
                    subscriber.DataUpdated += SubscriberDataUpdated;
                    Subscribers.Add(subscriber);
                }
                else
                {
                    OnMassage("Variable: " + subscriber.BrowserItem.Name + " failed to subscribe");
                }
            }
        }

        void SubscriberDataUpdated(object sender, Common.Intefaces.DataUpdatedEventArgs<T> e)
        {
            OnSubscriberDataUpdated(sender, e);
        }
    }






    public class NationalInstrumentsDataSource :NationalInstrumentsDataSourceBase, IDataSource
    {
        public event EventHandler<DataUpdatedEventArgs> DataUpdated;
        public void OnSubscriberDataUpdated(object sender, DataUpdatedEventArgs e)
        {
            EventHandler<DataUpdatedEventArgs> handler = DataUpdated;
            if (handler != null) handler(sender, e);
        }

        public NationalInstrumentsDataSource(ObservableCollection<IObservableSubscriberBase> subscribers)
        {
            Subscribers = subscribers;
            Browser = new Browser();
            Browser.GetSubitemsCompleted += BrowserGetSubitemsCompleted;
        }


        protected override void SubscribeVariables(IEnumerable<BrowserItem> variables)
        {
            foreach (BrowserItem browserItem in variables)
            {
                if (browserItem.ItemType == BrowserItemType.Item)
                {
                    Type elementType = browserItem.GetVariableType();

                    Type subscriber = typeof(ObservableSubscriber<>);
                    Type niSubscriber = typeof(NationalInstrumentsSubscriber<>);

                    Type combinedType = subscriber.MakeGenericType(elementType);
                    Type niCombinedType = niSubscriber.MakeGenericType(elementType);

                    //NationalInstrumentsSubscriber<T>
                    var nationalInstrumentsSubscriber = (ISubscriberBase) Activator.CreateInstance(niCombinedType, browserItem.Path);

                    //ObservableSubscriber<T>
                    var observableSubscriber = (ISubscriberBase) Activator.CreateInstance(combinedType, nationalInstrumentsSubscriber, new NationalInstrumentsBrowserItem(browserItem));

                    observableSubscriber.ConnectCompleted += ObservableSubscriberConnectCompleted;
                    observableSubscriber.ConnectAsync();
                }
            }
        }

        protected override void ObservableSubscriberConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var subscriber = sender as IObservableSubscriberBase;
         
            if (subscriber != null)
            {
                if (e.Error == null)
                {
                    //site: http://stackoverflow.com/questions/1121441/addeventhandler-using-reflection
                    
                    //Find event
                    EventInfo eventInfo = subscriber.GetType().GetEvent("DataUpdated");
                    Type eventHandlerType = eventInfo.EventHandlerType;

                    // Find the handler method
                    MethodInfo method = GetType().GetMethod("OnSubscriberDataUpdated");

                    // Subscribe to the event
                    Delegate handler = Delegate.CreateDelegate(eventHandlerType, this, method);
                    eventInfo.AddEventHandler(subscriber, handler);

                    Subscribers.Add(subscriber);
                }
                else
                {
                    OnMassage("Variable: " + subscriber.BrowserItem.Name + " failed to subscribe");
                }
            }
        }
    }
}
