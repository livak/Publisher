//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace PowerMonitoring.Data
{
    #pragma warning disable 1573
    
    public partial class AlarmConfiguration
    {
        public AlarmConfiguration()
        {
            this.AlarmLogs = new HashSet<AlarmLog>();
            this.Alarms = new HashSet<Alarm>();
        }

        public int VariableId { get; set; }
        public AlarmLevelConfiguration HIHI { get; set; }      
        public AlarmLevelConfiguration HI { get; set; }      
        public AlarmLevelConfiguration LO { get; set; }      
        public AlarmLevelConfiguration LOLO { get; set; }
        public bool Enabled { get; set; }
        public string Location { get; set; }
    
        public virtual ICollection<AlarmLog> AlarmLogs { get; set; }
        public virtual ICollection<Alarm> Alarms { get; set; }
        public virtual Variable Variable { get; set; }
    }
}
