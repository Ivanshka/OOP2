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
using System.ComponentModel.DataAnnotations;

namespace Laba_6
{
    public enum SearchData { Name, Specialty, Course, AvScore }
    public enum SearchMode { Full, Part }

    public partial class MainWindow : Form
    {
        /*список всех студентов, к которому привязан datagridview. благодаря
         * ему можно работать с элементами без слежки за datagridview */
        public static BindingList<Student> Students;

        public static SearchData SearchData = SearchData.Name;
        public static SearchMode SearchMode = SearchMode.Part;

        public MainWindow()
        {
            InitializeComponent();
            Students = new BindingList<Student>();
            table.DataSource = Students;
            timer.Tick += (o, e) => dateStatus.Text = DateTime.Now.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
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
            catch { }// MessageBox.Show("Неверное значение среднего балла!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (radioButton1.Checked)
                st.Gender = Gender.М;
            if (radioButton2.Checked)
                st.Gender = Gender.Ж;

            st.Birthday = dateTimePicker1.Value;

            Address main = new Address(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, (int)numericUpDown5.Value);

            string validateErrors = "";

            var results = new List<ValidationResult>();
            var context = new ValidationContext(st);
            // валидация студента и запись ошибок
            Validator.TryValidateObject(st, context, results, true);
            context = new ValidationContext(main);
            // валидация адреса и запись ошибок
            Validator.TryValidateObject(main, context, results, true);
            // переводим ошибки в норм формат
            foreach (var error in results)
            {
                validateErrors += $"{error.ErrorMessage}\n";
            }
            // пол почему-то валидатором не чекается. наверн, из-за того, что это перечисление и имеет стандартное значение
            // MessageBox.Show(st.Gender.ToString()); // выдает "М"(((
            if (!radioButton1.Checked && !radioButton2.Checked)
                validateErrors += "Не установлен пол!";
            if (validateErrors.Length != 0)
            {
                MessageBox.Show($"Обнаружены ошибки ввода:\n{validateErrors}", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            st.MainAddress = main;
            
            // дополнительный адрес валидировать не будем
            st.SecondAddress = new Address(textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, (int)numericUpDown6.Value);
            // work
            st.Work = new Work(textBox6.Text, textBox7.Text, (int)numericUpDown4.Value);
            Students.Add(st);
            studentCount.Text = $"Студентов: {Students.Count}.";
        }

        private void EraseBtn_Click(object sender, EventArgs e)
        {
            if (Students.Count != 0 && table.SelectedRows.Count != 0)
            {
                Students.RemoveAt(table.SelectedRows[0].Index);
                studentCount.Text = $"Студентов: {Students.Count}.";
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

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            if (table.SelectedRows.Count == 0)
                return;

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
            catch { }// MessageBox.Show("Неверное значение среднего балла!", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (radioButton1.Checked)
                st.Gender = Gender.М;
            if (radioButton2.Checked)
                st.Gender = Gender.Ж;

            st.Birthday = dateTimePicker1.Value;

            Address main = new Address(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, (int)numericUpDown5.Value);

            string validateErrors = "";

            var results = new List<ValidationResult>();
            var context = new ValidationContext(st);
            // валидация студента и запись ошибок
            Validator.TryValidateObject(st, context, results, true);
            context = new ValidationContext(main);
            // валидация адреса и запись ошибок
            Validator.TryValidateObject(main, context, results, true);
            // переводим ошибки в норм формат
            foreach (var error in results)
            {
                validateErrors += $"{error.ErrorMessage}\n";
            }
            // пол почему-то валидатором не чекается. наверн, из-за того, что это перечисление и имеет стандартное значение
            // MessageBox.Show(st.Gender.ToString()); // выдает "М"(((
            if (!radioButton1.Checked && !radioButton2.Checked)
                validateErrors += "Не установлен пол!";
            if (validateErrors.Length != 0)
            {
                MessageBox.Show($"Обнаружены ошибки ввода:\n{validateErrors}", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            st.MainAddress = main;

            st.SecondAddress = new Address(textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, (int)numericUpDown6.Value);
            // work
            st.Work = new Work(textBox6.Text, textBox7.Text, (int)numericUpDown4.Value);
            // collection
            Students[table.SelectedRows[0].Index] = st;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON-файл|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(BindingList<Student>));
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                json.WriteObject(fs, Students);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON-файл|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(BindingList<Student>));
            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                Students = (BindingList<Student>)json.ReadObject(fs);

            table.DataSource = Students;
            studentCount.Text = $"Студентов: {Students.Count}";
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students.Clear();
            table.DataSource = Students;
            studentCount.Text = $"Студентов: {Students.Count}";

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
            numericUpDown2.Value = numericUpDown3.Value = numericUpDown5.Value = numericUpDown6.Value = 1;
            numericUpDown1.Value = 18;
            numericUpDown4.Value = 0;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void ФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchData = SearchData.Name;
             new Search().ShowDialog();
        }

        private void специальностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchData = SearchData.Specialty;
            new Search().ShowDialog();
        }

        private void курсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchData = SearchData.Course;
            new Search().ShowDialog();
        }

        private void среднийБаллToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchData = SearchData.AvScore;
            new Search().ShowDialog();
        }

        static bool dragFlag = false;
        static Point point = default(Point);

        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            dragFlag = true;
            point = e.Location;
        }

        private void toolStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragFlag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragFlag)
            {
                int dX = e.X - point.X;
                int dY = e.Y - point.Y;
                int newX = point.X + dX;
                int newY = point.Y + dY;
                toolStrip1.Location = new Point(newX, newY);
            }
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e) => новыйToolStripMenuItem_Click(null, null);

        private void открытьToolStripButton_Click(object sender, EventArgs e) => открытьToolStripMenuItem_Click(null, null);

        private void сохранитьToolStripButton_Click(object sender, EventArgs e) => сохранитьToolStripMenuItem_Click(null, null);

        private void оПрограммеToolStripButton_Click(object sender, EventArgs e) => оПрограммеToolStripMenuItem_Click(null, null);

        private void поискToolStripButton_Click(object sender, EventArgs e) => new Search().ShowDialog();

        // сортировки
        private void фамилииToolStripMenuItem_Click(object sender, EventArgs e) => Sort('ф');

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e) => Sort('с');

        private void возрастуToolStripMenuItem_Click(object sender, EventArgs e) => Sort('в');

        private void Sort(char ch)
        {
            List<Student> st = null;
            switch (ch)
            {
                case 'ф': st = (from i in Students orderby i.SurName select i).ToList(); action.Text = "Отсортировано по фамилии!"; break;
                case 'с': st = (from i in Students orderby i.Specialty select i).ToList(); action.Text = "Отсортировано по специальности!"; break;
                case 'в': st = (from i in Students orderby i.Age select i).ToList(); action.Text = "Отсортировано по возрасту!"; break;
            }

            Students.Clear();
            foreach (Student s in st)
                Students.Add(s);
        }

        byte sortMode = 0;
        private void сортировкаSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            switch(sortMode)
            {
                case 0: фамилииToolStripMenuItem_Click(null, null); sortMode++; break;
                case 1: специальностиToolStripMenuItem_Click(null, null); sortMode++; break;
                case 2: возрастуToolStripMenuItem_Click(null, null); sortMode = 0; break;
            }
        }
    }
}
