//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2013.07.14 - 16:59:45
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace PowerMonitoring.Data
{
    [DataContract()]
    public partial class DoubleLogDto
    {
        [DataMember()]
        public Int32 DoubleLogId { get; set; }

        [DataMember()]
        public Double DoubleValue { get; set; }

        [DataMember()]
        public DateTime TimeStamp { get; set; }

        [DataMember()]
        public Int32 VariableId { get; set; }

        [DataMember()]
        public Int32 Variable_VariableId { get; set; }

        public DoubleLogDto()
        {
        }

        public DoubleLogDto(Int32 doubleLogId, Double doubleValue, DateTime timeStamp, Int32 variableId, Int32 variable_VariableId)
        {
			this.DoubleLogId = doubleLogId;
			this.DoubleValue = doubleValue;
			this.TimeStamp = timeStamp;
			this.VariableId = variableId;
			this.Variable_VariableId = variable_VariableId;
        }
    }
}
