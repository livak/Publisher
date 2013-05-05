using System;
using System.Runtime.Serialization;

namespace WebService.Entities
{
    [DataContract]
    public class TerminalDto
    {
        [DataMember]
        public int AlarmId { get; set; }

        [DataMember]
        public string VariableName { get; set; }

        [DataMember]
        public string AlarmLevelName { get; set; }

        [DataMember]
        public DateTime SetTime { get; set; }

        [DataMember]
        public double MaxValue { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public bool Acknowledged { get; set; }
    }
}