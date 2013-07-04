using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmLogSetMapping : EntityTypeConfiguration<AlarmLogSet>
    {
        public AlarmLogSetMapping()
        {
            HasKey(t => t.Id);
            ToTable("AlarmLogSet");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.AlarmLevelName).HasColumnName("AlarmLevelName").IsRequired();
            Property(t => t.Action).HasColumnName("Action").IsRequired();
            Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            Property(t => t.AlarmConfigId).HasColumnName("AlarmConfigId");
            Property(t => t.CurrentValue).HasColumnName("CurrentValue").IsRequired();
            HasRequired(t => t.AlarmConfigSet).WithMany(t => t.AlarmLogSets).HasForeignKey(d => d.AlarmConfigId);
        }
    }
}
