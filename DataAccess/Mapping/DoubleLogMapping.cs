using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class DoubleLogMapping : EntityTypeConfiguration<DoubleLog>
    {
        public DoubleLogMapping()
        {
            HasRequired(t => t.Variable).WithMany(t => t.DoubleLogs).HasForeignKey(d => d.VariableId);
        }
    }
}

