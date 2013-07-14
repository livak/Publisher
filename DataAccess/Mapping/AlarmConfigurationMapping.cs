using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmConfigurationMapping : EntityTypeConfiguration<AlarmConfiguration>
    {
        public AlarmConfigurationMapping()
        {
            HasKey(t => t.VariableId);
            Property(t => t.VariableId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Location).IsRequired();
            HasRequired(t => t.Variable).WithOptional(t => t.AlarmConfiguration);
        }
    }
}
