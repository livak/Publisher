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
    using System;
    using System.Collections.Generic;
    
    public partial class AlarmConfigSet
    {
        public AlarmConfigSet()
        {
            this.AlarmLogSets = new HashSet<AlarmLogSet>();
            this.AlarmTerminalSets = new HashSet<AlarmTerminalSet>();
        }
    
        public int Id { get; set; }
        public bool HIHI_Enable { get; set; }
        public string HIHI_Name { get; set; }
        public double HIHI_LevelChange { get; set; }
        public int HIHI_Delay { get; set; }
        public bool HI_Enable { get; set; }
        public string HI_Name { get; set; }
        public double HI_LevelChange { get; set; }
        public int HI_Delay { get; set; }
        public bool LO_Enable { get; set; }
        public string LO_Name { get; set; }
        public double LO_LevelChange { get; set; }
        public int LO_Delay { get; set; }
        public bool LOLO_Enabled { get; set; }
        public string LOLO_Name { get; set; }
        public double LOLO_LevelChange { get; set; }
        public int LOLO_Delay { get; set; }
        public bool Enabled { get; set; }
        public string Location { get; set; }
    
        public virtual ICollection<AlarmLogSet> AlarmLogSets { get; set; }
        public virtual ICollection<AlarmTerminalSet> AlarmTerminalSets { get; set; }
        public virtual VariableSet VariableSet { get; set; }
    }
}
