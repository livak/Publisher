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
    
    public partial class SingleLogSet
    {
        public int Id { get; set; }
        public float SingleValue { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int VariableId { get; set; }
    
        public virtual VariableSet VariableSet { get; set; }
    }
}
