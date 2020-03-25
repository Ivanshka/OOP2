using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    [DataContract]
    class Address
    {
        public Address(string city, string index, string street, string house, int flat)
        {
            City = city;
            Index = index;
            Street = street;
            House = house;
            Flat = flat;
        }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Index { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public int Flat { get; set; }
    }
}
