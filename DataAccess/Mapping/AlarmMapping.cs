using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmMapping : EntityTypeConfiguration<Alarm>
    {
        public AlarmMapping()
        {
            Property(t => t.AlarmLevelName).IsRequired();
            HasRequired(t => t.AlarmConfiguration).WithMany(t => t.Alarms).HasForeignKey(d => d.VariableId);
        }
    }
}
