namespace Publisher.Subscriber.Intefaces
{
    internal interface IBrowserItem
    {
        IBrowserItem ParentItem { get; }
        string Name { get; }
        string Path { get; }
    }
}
