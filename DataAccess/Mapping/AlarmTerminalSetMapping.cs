using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmTerminalSetMapping : EntityTypeConfiguration<AlarmTerminalSet>
    {
        public AlarmTerminalSetMapping()
        {
            HasKey(t => t.Id);
            ToTable("AlarmTerminalSet");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Active).HasColumnName("Active");
            Property(t => t.Acknowledged).HasColumnName("Acknowledged");
            Property(t => t.AlarmLevelName).HasColumnName("AlarmLevelName").IsRequired();
            Property(t => t.MaxValue).HasColumnName("MaxValue");
            Property(t => t.SetTime).HasColumnName("SetTime");
            Property(t => t.MaxValueTime).HasColumnName("MaxValueTime");
            Property(t => t.DeactivatedTime).HasColumnName("DeactivatedTime");
            Property(t => t.SetPoint).HasColumnName("SetPoint");
            Property(t => t.Priority).HasColumnName("Priority");
            Property(t => t.AlarmConfig_Id).HasColumnName("AlarmConfig_Id");
            HasRequired(t => t.AlarmConfigSet).WithMany(t => t.AlarmTerminalSets).HasForeignKey(d => d.AlarmConfig_Id);
        }
    }
}
