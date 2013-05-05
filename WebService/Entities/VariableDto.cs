using System.Runtime.Serialization;

namespace WebService.Entities
{
    [DataContract]
    public class VariableDto
    {
        [DataMember]
        public string VariableName { get; set; }

        [DataMember]
        public string CurrentValue { get; set; }
    }
}