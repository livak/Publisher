using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class DoubleLogSetMapping : EntityTypeConfiguration<DoubleLogSet>
    {
        public DoubleLogSetMapping()
        {
            HasKey(t => t.Id);
            HasRequired(t => t.VariableSet).WithMany(t => t.DoubleLogSets).HasForeignKey(d => d.VariableId);
        }
    }
}

