using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class AlarmConfigSetMapping : EntityTypeConfiguration<AlarmConfigSet>
    {
        public AlarmConfigSetMapping()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.HIHI_Name).IsRequired();
            Property(t => t.HI_Name).IsRequired();
            Property(t => t.LO_Name).IsRequired();
            Property(t => t.LOLO_Name).IsRequired();
            Property(t => t.Location).IsRequired();
            HasRequired(t => t.VariableSet).WithOptional(t => t.AlarmConfigSet);
        }
    }
}
