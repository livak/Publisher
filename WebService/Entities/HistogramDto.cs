using System;
using System.Runtime.Serialization;

namespace WebService.Entities
{
    [DataContract]
    public class HistogramDto
    {
        [DataMember]
        public Single SingleValue { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}