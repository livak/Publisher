using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;
using PowerMonitoring.Data.Poco;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmLogMapping : EntityTypeConfiguration<AlarmLog>
    {
        public AlarmLogMapping()
        {
            Property(t => t.AlarmLevelName).IsRequired();
            Property(t => t.Action).IsRequired();
            Property(t => t.CurrentValue).IsRequired();
            HasRequired(t => t.AlarmConfiguration).WithMany(t => t.AlarmLogs).HasForeignKey(d => d.VariableId);
        }
    }
}
