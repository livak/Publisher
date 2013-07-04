using System.Data.Entity.ModelConfiguration;
using PowerMonitoring.Data;

namespace PowerMonitoring.DataAccess.Mapping
{
    internal class DoubleLogSetMapping : EntityTypeConfiguration<DoubleLogSet>
    {
        public DoubleLogSetMapping()
        {                        
              HasKey(t => t.Id);        
              ToTable("DoubleLogSet");
              Property(t => t.Id).HasColumnName("Id");
              Property(t => t.DoubleValue).HasColumnName("DoubleValue");
              Property(t => t.TimeStamp).HasColumnName("TimeStamp");
              Property(t => t.VariableId).HasColumnName("VariableId");
              HasRequired(t => t.VariableSet).WithMany(t => t.DoubleLogSets).HasForeignKey(d => d.VariableId);
         }
    }

