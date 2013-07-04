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
            Property(t => t.AlarmLevelName).IsRequired();
            HasRequired(t => t.AlarmConfigSet).WithMany(t => t.AlarmTerminalSets).HasForeignKey(d => d.AlarmConfig_Id);
        }
    }
}
