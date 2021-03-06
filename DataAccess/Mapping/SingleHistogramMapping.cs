using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class SingleHistogramMapping : EntityTypeConfiguration<SingleHistogram>
    {
        public SingleHistogramMapping()
        {
            HasRequired(t => t.Variable).WithMany(t => t.SingleHistograms).HasForeignKey(d => d.VariableId);
        }
    }
}