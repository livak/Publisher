using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class VariableSetMapping : EntityTypeConfiguration<VariableSet>
    {
        public VariableSetMapping()
        {
            HasKey(t => t.Id);
            ToTable("VariableSet");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.Type).HasColumnName("Type").IsRequired();
            Property(t => t.DataLoggingEnabled).HasColumnName("DataLoggingEnabled");
        }
    }
}

