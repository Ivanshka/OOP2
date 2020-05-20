using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laba_11
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int GroupID { get; set; }

        public Student(int id, string name, int course, int groupId)
        {
            ID = id;
            Name = name;
            Course = course;
            GroupID = groupId;
        }
    }
}