using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmLogSetMapping : EntityTypeConfiguration<AlarmLogSet>
    {
        public AlarmLogSetMapping()
        {
            HasKey(t => t.Id);
            Property(t => t.AlarmLevelName).IsRequired();
            Property(t => t.Action).IsRequired();
            Property(t => t.CurrentValue).IsRequired();
            HasRequired(t => t.AlarmConfigSet).WithMany(t => t.AlarmLogSets).HasForeignKey(d => d.AlarmConfigId);
        }
    }
}
