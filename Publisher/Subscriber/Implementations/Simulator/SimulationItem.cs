using Publisher.Subscriber.Intefaces;

namespace Publisher.Subscriber.Implementations.Simulator
{
    class SimulationItem : IBrowserItem
    {
        public IBrowserItem ParentItem { get { return this; } }
        public string Name { get; private set; }
        public string Path { get; private set; }

        public SimulationItem(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
