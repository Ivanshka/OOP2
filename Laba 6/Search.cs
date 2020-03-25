using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_6
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();

            switch(MainWindow.SearchData)
            {
                case SearchData.Course: radioCourse.Checked = true; break;
                case SearchData.AvScore: radioAvScore.Checked = true; break;
                case SearchData.Name: radioName.Checked = true; break;
                case SearchData.Specialty: radioSpecialty.Checked = true; break;
            }
            switch(MainWindow.SearchMode)
            {
                case SearchMode.Full: radioAccurate.Checked = true; break;
                case SearchMode.Part: radioRegular.Checked = true; break;
            }
        }

        private void radioName_Click(object sender, EventArgs e) => MainWindow.SearchData = SearchData.Name;
        private void radioSpecialty_CheckedChanged(object sender, EventArgs e) => MainWindow.SearchData = SearchData.Specialty;
        private void radioCourse_CheckedChanged(object sender, EventArgs e) => MainWindow.SearchData = SearchData.Course;
        private void radioAvScore_CheckedChanged(object sender, EventArgs e) => MainWindow.SearchData = SearchData.AvScore;

        private void radioAccurate_CheckedChanged(object sender, EventArgs e) => MainWindow.SearchMode = SearchMode.Full;
        private void radioRegular_CheckedChanged(object sender, EventArgs e) => MainWindow.SearchMode = SearchMode.Part;

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            resultList.Items.Clear();

            switch (MainWindow.SearchData)
            {
                case SearchData.Course:
                    int course;
                    if (int.TryParse(SearchBox.Text, out course))
                        foreach (Student st in MainWindow.Students)
                            if (st.Course == course)
                                resultList.Items.Add(st.ToString());
                    break;
                case SearchData.AvScore:
                    int score;
                    if (int.TryParse(SearchBox.Text, out score))
                        foreach (Student st in MainWindow.Students)
                            if (st.Course == score)
                                resultList.Items.Add(st.ToString());
                    break;
                case SearchData.Name:
                    if (MainWindow.SearchMode == SearchMode.Full)
                    {
                        foreach (Student st in MainWindow.Students)
                            if ($"{st.SurName} {st.Name}" == SearchBox.Text)
                                resultList.Items.Add(st.ToString());
                    }
                    else
                    {
                        Regex regex = new Regex($@"(\w*){SearchBox.Text}(\w*)", RegexOptions.IgnoreCase);
                        foreach(Student st in MainWindow.Students)
                        {
                            Match m = regex.Match($"{st.SurName} {st.Name}");
                            if (m.Success)
                                resultList.Items.Add(st);
                        }
                    }
                    break;
                case SearchData.Specialty:
                    if (MainWindow.SearchMode == SearchMode.Full)
                    {
                        foreach (Student st in MainWindow.Students)
                            if (st.Specialty == SearchBox.Text)
                                resultList.Items.Add(st.ToString());
                    }
                    else
                    {
                        Regex regex = new Regex($@"(\w*){SearchBox.Text}(\w*)", RegexOptions.IgnoreCase);
                        foreach (Student st in MainWindow.Students)
                        {
                            Match m = regex.Match($"{st.Specialty}");
                            if (m.Success)
                                resultList.Items.Add(st);
                        }
                    }
                    break;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON-файл|*.json";
            DialogResult sfdRes = sfd.ShowDialog();
            
            if (sfdRes != DialogResult.OK)
                return;

            string[] result = new string[resultList.Items.Count];
            for (int i = 0; i < resultList.Items.Count; i++)
                result[i] = resultList.Items[i].ToString();
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(string[]));
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    js.WriteObject(fs, result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
