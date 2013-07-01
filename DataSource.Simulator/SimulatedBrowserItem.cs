using System;
using PowerMonitoring.DataSource.Common.Intefaces;

namespace PowerMonitoring.DataSource.Simulator
{
    class SimulatedBrowserItem : IBrowserItem
    {
        public IBrowserItem ParentItem { get { return this; } }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public Type Type { get; private set; }

        public SimulatedBrowserItem(string name, string path, Type type)
        {
            Name = name;
            Path = path;
            Type = type;
        }
    }
}
