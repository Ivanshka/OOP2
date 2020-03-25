using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    [DataContract]
    public class Work
    {
        public Work(string company, string position, int exp) { Company = company; Position = position; Expirience = exp; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public int Expirience { get; set; }
        public override string ToString() => $"{Company}, {Position}";
    }
}
