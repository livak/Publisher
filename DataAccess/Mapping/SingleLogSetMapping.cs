using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class SingleLogSetMapping : EntityTypeConfiguration<SingleLogSet>
    {
        public SingleLogSetMapping()
        {
            HasKey(t => t.Id);
            HasRequired(t => t.VariableSet).WithMany(t => t.SingleLogSets).HasForeignKey(d => d.VariableId);
        }
    }
}
