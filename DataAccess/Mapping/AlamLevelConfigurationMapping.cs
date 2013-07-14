using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;
using PowerMonitoring.Data.Poco;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlamLevelConfigurationMapping : ComplexTypeConfiguration<AlarmLevelConfiguration>
    {
        public AlamLevelConfigurationMapping()
        {
            Property(t => t.Name).IsRequired();
        }
    }
}
