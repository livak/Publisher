namespace PowerMonitoring.Data
{
    public class AlarmLevelConfiguration
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public double LevelChange { get; set; }
        public int Delay { get; set; }
    }
}
