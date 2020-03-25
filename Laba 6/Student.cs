using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    public enum Gender { М, Ж };
    [DataContract]
    public class Student
    {
        [DataMember]
        [Required(ErrorMessage = "Не установлено имя!")]
        public string Name { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлена фамилия!")]
        public string SurName { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлено отчество!")]
        public string MiddleName { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлен возраст!")]
        public byte Age { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлена дата рождения!")]
        public DateTime Birthday { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлена специальность!")]
        public string Specialty { get; set; }
        [DataMember]
        [Range(1, 4, ErrorMessage = "Недопустимое значение курса!")]
        [Required(ErrorMessage = "Курс не установлен!")]
        public byte Course { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлена группа!")]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст!")]
        public byte Group { get; set; }
        [DataMember]
        [Range(1, 10, ErrorMessage = "Недопустимое значение среднего балла!")]
        public float AverageScore { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Не установлен пол!")]
        public Gender Gender { get; set; }
        [DataMember]
        public Address MainAddress { get; set; }
        [DataMember]
        public Address SecondAddress { get; set; }
        [DataMember]
        public Work Work { get; set; }

        public override string ToString() => $"{SurName} {Name} {MiddleName}, {Specialty} {Course}-{Group}";
    }
}
