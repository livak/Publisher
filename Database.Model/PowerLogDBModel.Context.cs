﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PowerLogDBEntities : DbContext
    {
        public PowerLogDBEntities()
            : base("name=PowerLogDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AlarmConfigSet> AlarmConfigSets { get; set; }
        public DbSet<AlarmLogSet> AlarmLogSets { get; set; }
        public DbSet<AlarmTerminalSet> AlarmTerminalSets { get; set; }
        public DbSet<DoubleLogSet> DoubleLogSets { get; set; }
        public DbSet<SingleHistogramSet> SingleHistogramSets { get; set; }
        public DbSet<SingleLogSet> SingleLogSets { get; set; }
        public DbSet<VariableSet> VariableSets { get; set; }
    }
}
