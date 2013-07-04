using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class SingleHistogramSetMapping : EntityTypeConfiguration<SingleHistogramSet>
    {
        public SingleHistogramSetMapping()
        {
            HasKey(t => t.Id);
            HasRequired(t => t.VariableSet).WithMany(t => t.SingleHistogramSets).HasForeignKey(d => d.VariableId);
        }
    }
}