using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    enum Gender { М, Ж };
    [DataContract]
    class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public byte Age { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public string Specialty { get; set; }
        [DataMember]
        public byte Course { get; set; }
        [DataMember]
        public byte Group { get; set; }
        [DataMember]
        public float AverageScore { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
        [DataMember]
        public Address MainAddress { get; set; }
        [DataMember]
        public Address SecondAddress { get; set; }
        [DataMember]
        public Work Work { get; set; }
    }
}
