using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class SingleLogSetMapping : EntityTypeConfiguration<SingleLogSet>
    {
        public SingleLogSetMapping()
        {
            HasKey(t => t.Id);
            ToTable("SingleLogSet");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.SingleValue).HasColumnName("SingleValue");
            Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            Property(t => t.VariableId).HasColumnName("VariableId");
            HasRequired(t => t.VariableSet).WithMany(t => t.SingleLogSets).HasForeignKey(d => d.VariableId);
        }
    }
}
