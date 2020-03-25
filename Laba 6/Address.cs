using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    [DataContract]
    public class Address
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
        [Required(ErrorMessage = "Не указан город!")]
        public string City { get; set; }
        [DataMember]
        public string Index { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не указана улица!")]
        public string Street { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не указан номер дома!")]
        public string House { get; set; }
        [DataMember]
        public int Flat { get; set; }

        public override string ToString() => $"г.{City}, ул.{Street}, д.{House}, кв.{Flat}";
    }
}
