using NationalInstruments.NetworkVariable;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.MeasurementStudio
{
    class NationalInstrumentsBrowserItem : IBrowserItem
    {
        private readonly BrowserItem _browserItem;

        public IBrowserItem ParentItem { get { return new NationalInstrumentsBrowserItem(_browserItem); } }

        public string Name { get { return _browserItem.Name; } }
        public string Path { get { return _browserItem.Path; } }

        public NationalInstrumentsBrowserItem(BrowserItem browserItem)
        {
            _browserItem = browserItem;
        }
    }
}
