//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PowerMonitoring.Data
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public partial class AlarmLogSet
    {
        public int Id { get; set; }
        public string AlarmLevelName { get; set; }
        public string Action { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int AlarmConfigId { get; set; }
        public string CurrentValue { get; set; }
    
        public virtual AlarmConfigSet AlarmConfigSet { get; set; }
    }
}
