namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public interface IBrowserItem
    {
        IBrowserItem ParentItem { get; }
        string Name { get; }
        string Path { get; }
    }
}
