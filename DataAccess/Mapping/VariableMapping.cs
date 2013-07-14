using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;
using PowerMonitoring.Data.Poco;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class VariableMapping : EntityTypeConfiguration<Variable>
    {
        public VariableMapping()
        {
            Property(t => t.Name).IsRequired();
            Property(t => t.Type).IsRequired();
        }
    }
}

