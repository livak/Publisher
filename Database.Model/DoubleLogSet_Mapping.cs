//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.Model
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;
    
    internal partial class DoubleLogSet_Mapping : EntityTypeConfiguration<DoubleLogSet>
    {
        public DoubleLogSet_Mapping()
        {                        
              this.HasKey(t => t.Id);        
              this.ToTable("DoubleLogSet");
              this.Property(t => t.Id).HasColumnName("Id");
              this.Property(t => t.DoubleValue).HasColumnName("DoubleValue");
              this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
              this.Property(t => t.VariableId).HasColumnName("VariableId");
              this.HasRequired(t => t.VariableSet).WithMany(t => t.DoubleLogSets).HasForeignKey(d => d.VariableId);
         }
    }
}
