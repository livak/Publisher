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
            ToTable("AlarmConfigSet");
            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.HIHI_Enable).HasColumnName("HIHI_Enable");
            Property(t => t.HIHI_Name).HasColumnName("HIHI_Name").IsRequired();
            Property(t => t.HIHI_LevelChange).HasColumnName("HIHI_LevelChange");
            Property(t => t.HIHI_Delay).HasColumnName("HIHI_Delay");
            Property(t => t.HI_Enable).HasColumnName("HI_Enable");
            Property(t => t.HI_Name).HasColumnName("HI_Name").IsRequired();
            Property(t => t.HI_LevelChange).HasColumnName("HI_LevelChange");
            Property(t => t.HI_Delay).HasColumnName("HI_Delay");
            Property(t => t.LO_Enable).HasColumnName("LO_Enable");
            Property(t => t.LO_Name).HasColumnName("LO_Name").IsRequired();
            Property(t => t.LO_LevelChange).HasColumnName("LO_LevelChange");
            Property(t => t.LO_Delay).HasColumnName("LO_Delay");
            Property(t => t.LOLO_Enabled).HasColumnName("LOLO_Enabled");
            Property(t => t.LOLO_Name).HasColumnName("LOLO_Name").IsRequired();
            Property(t => t.LOLO_LevelChange).HasColumnName("LOLO_LevelChange");
            Property(t => t.LOLO_Delay).HasColumnName("LOLO_Delay");
            Property(t => t.Enabled).HasColumnName("Enabled");
            Property(t => t.Location).HasColumnName("Location").IsRequired();
            HasRequired(t => t.VariableSet).WithOptional(t => t.AlarmConfigSet);
        }
    }
}
