using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class SingleLogMapping : EntityTypeConfiguration<SingleLog>
    {
        public SingleLogMapping()
        {
            HasRequired(t => t.Variable).WithMany(t => t.SingleLogs).HasForeignKey(d => d.VariableId);
        }
    }
}
