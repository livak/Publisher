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
    
    public partial class DoubleLogSet
    {
        public int Id { get; set; }
        public double DoubleValue { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int VariableId { get; set; }
    
        public virtual VariableSet VariableSet { get; set; }
    }
}
