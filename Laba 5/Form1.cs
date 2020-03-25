using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Laba_6
{
    public partial class Form1 : Form
    {
        static List<Student> Students;
        static int Count = 0;
        public Form1()
        {
            InitializeComponent();
            Students = new List<Student>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox8.Text.Length == 0 || textBox9.Text.Length == 0 || textBox10.Text.Length == 0 || textBox11.Text.Length == 0)
            {
                MessageBox.Show("Не введены минимальные данные!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // information
            Student st = new Student()
            {
                Name = textBox2.Text,
                SurName = textBox1.Text,
                MiddleName = textBox3.Text,
                Specialty = textBox4.Text,
                Age = (byte)numericUpDown1.Value,
                Course = (byte)numericUpDown2.Value,
                Group = (byte)numericUpDown3.Value,
            };
            try
            {
                st.AverageScore = (float)Convert.ToDouble(textBox5.Text);
            }
            catch { MessageBox.Show("Неверное значение среднего балла!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Не установлен пол!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (radioButton1.Checked)
                st.Gender = Gender.М;
            else
                st.Gender = Gender.Ж;
            st.Birthday = dateTimePicker1.Value;
            // addesses
            /*int index;
            try
            {
                index = Convert.ToInt32(textBox9.Text);
            }
            catch
            {
                MessageBox.Show("Неверный индекс основного адреса!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            st.MainAddress = new Address(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, (int)numericUpDown5.Value);
            /*try
            {
                index = Convert.ToInt32();
            }
            catch
            {
                MessageBox.Show("Неверный индекс дополнительного адреса!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            st.SecondAddress = new Address(textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, (int)numericUpDown6.Value);
            // work
            st.Work = new Work(textBox6.Text, textBox7.Text, (int)numericUpDown4.Value);
            Students.Add(st);

            // grid
            table.Rows.Add(st.SurName, st.Name, st.MiddleName, st.Age, st.Birthday, st.Specialty, st.Course, st.Group, st.AverageScore, st.Gender);
            Count++;
            toolStripStatusLabel1.Text = $"Студентов: {Count}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (table.SelectedRows.Count != 0)
            {
                try
                {
                    table.Rows.RemoveAt(table.SelectedRows[0].Index);
                    toolStripStatusLabel1.Text = $"Студентов: {--Count}";
                }
                catch { }
            }
        }

        private void table_SelectionChanged(object sender, EventArgs e)
        {
            if (table.SelectedRows.Count == 0) // без проверки - исключение при выделенной пустой строке и попытке создать новый файл
                return;
            if (!(table.SelectedRows[0].Index > -1 && table.SelectedRows[0].Index < Students.Count))
                return;
            Student st = Students[table.SelectedRows[0].Index];
            textBox1.Text = st.SurName;
            textBox2.Text = st.Name;
            textBox3.Text = st.MiddleName;
            textBox4.Text = st.Specialty;
            dateTimePicker1.Value = st.Birthday;
            numericUpDown1.Value = st.Age;
            numericUpDown2.Value = st.Course;
            numericUpDown3.Value = st.Group;
            textBox5.Text = st.AverageScore.ToString();
            if (st.Gender == Gender.М)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            textBox8.Text = st.MainAddress.City;
            textBox9.Text = st.MainAddress.Index;
            textBox10.Text = st.MainAddress.Street;
            textBox11.Text = st.MainAddress.House;
            numericUpDown5.Value = st.MainAddress.Flat;
            textBox12.Text = st.SecondAddress.City;
            textBox13.Text = st.SecondAddress.Index;
            textBox14.Text = st.SecondAddress.Street;
            textBox15.Text = st.SecondAddress.House;
            numericUpDown6.Value = st.SecondAddress.Flat;

            textBox6.Text = st.Work.Company;
            textBox7.Text = st.Work.Position;
            numericUpDown4.Value = st.Work.Expirience;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox8.Text.Length == 0 || textBox9.Text.Length == 0 || textBox10.Text.Length == 0 || textBox11.Text.Length == 0)
            {
                MessageBox.Show("Не введены минимальные данные!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // information
            Student st = new Student()
            {
                Name = textBox2.Text,
                SurName = textBox1.Text,
                MiddleName = textBox3.Text,
                Specialty = textBox4.Text,
                Age = (byte)numericUpDown1.Value,
                Course = (byte)numericUpDown2.Value,
                Group = (byte)numericUpDown3.Value,
            };
            try
            {
                st.AverageScore = (float)Convert.ToDouble(textBox5.Text);
            }
            catch { MessageBox.Show("Неверное значение среднего балла!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Не установлен пол!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (radioButton1.Checked)
                st.Gender = Gender.М;
            else
                st.Gender = Gender.Ж;
            st.Birthday = dateTimePicker1.Value;
            st.MainAddress = new Address(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, (int)numericUpDown5.Value);
            st.SecondAddress = new Address(textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, (int)numericUpDown6.Value);
            // work
            st.Work = new Work(textBox6.Text, textBox7.Text, (int)numericUpDown4.Value);
            Students.Add(st);
            // collection
            Students[table.SelectedRows[0].Index] = st;
            // grid
            table.Rows.RemoveAt(table.SelectedRows[0].Index);
            table.Rows.Insert(table.SelectedRows[0].Index, st.SurName, st.Name, st.MiddleName, st.Age, st.Birthday, st.Specialty, st.Course, st.Group, st.AverageScore, st.Gender);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON-файл|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                json.WriteObject(fs, Students);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON-файл|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                Students = (List<Student>)json.ReadObject(fs);

            Count = 0;

            table.Rows.Clear();
            foreach (Student s in Students)
            {
                table.Rows.Add(s.SurName, s.Name, s.MiddleName, s.Age, s.Birthday, s.Specialty, s.Course, s.Group, s.AverageScore, s.Gender);
                Count++;
            }
            toolStripStatusLabel1.Text = $"Студентов: {Count}";
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Count = 0;
            toolStripStatusLabel1.Text = $"Студентов: {Count}";

            table.Rows.Clear();
            Students.Clear();

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
            numericUpDown2.Value = numericUpDown3.Value = numericUpDown5.Value = numericUpDown6.Value = 1;
            numericUpDown1.Value = 18;
            numericUpDown4.Value = 0;
        }
    }
}
