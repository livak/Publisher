using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class VariableSetMapping : EntityTypeConfiguration<VariableSet>
    {
        public VariableSetMapping()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired();
            Property(t => t.Type).IsRequired();
        }
    }
}

