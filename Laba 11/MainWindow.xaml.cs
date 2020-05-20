using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Справка по БД: https://metanit.com/sharp/adonet/2.2.php

namespace Laba_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // хранилища
        DataSet dsStudents; // для студентов
        DataSet dsGroups; // для групп

        // адаптер для работы с наборами данных
        SqlDataAdapter adapterStudents;
        SqlDataAdapter adapterGroups;

        // команды для получения данных
        string selectGroups = "set implicit_transactions on; select * from [group]";
        string selectStudents = "select * from student";

        public MainWindow()
        {
            InitializeComponent();
            
            // подключаемся и заполняем хранилища (наборы данных)
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                }
                catch { MessageBox.Show("БД недоступна!) :-)"); }

                // передаем адаптеру запрос для получения данных и подключение
                adapterGroups = new SqlDataAdapter(selectGroups, cn);
                dsGroups = new DataSet();
                // и говорим, какой набор данных заполнить
                adapterGroups.Fill(dsGroups);
                // показываем полученные данные в datagrid для списка групп
                dgGr.ItemsSource = dsGroups.Tables[0].DefaultView;

                adapterStudents = new SqlDataAdapter(selectStudents, cn);
                dsStudents = new DataSet();
                adapterStudents.Fill(dsStudents);
                // показываем полученные данные в datagrid
                dgDatabase.ItemsSource = dsStudents.Tables[0].DefaultView;

                cn.Close();
            }




        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dgDatabase.Items.Count; i++)
            {
                if (dgDatabase.SelectedItems.Contains(dgDatabase.Items[i]))
                {
                    dsStudents.Tables[0].DefaultView.Delete(i);
                    i--;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                adapterStudents = new SqlDataAdapter(selectStudents, connection); // пересоздаем адаптер

                adapterStudents.InsertCommand = new SqlCommand("sp_AddStudent", connection); // создаем команду вставки на случай, если придется добавлять строки в бд
                adapterStudents.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterStudents.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name"));
                adapterStudents.InsertCommand.Parameters.Add(new SqlParameter("@Course", SqlDbType.Int, 0, "Course"));
                adapterStudents.InsertCommand.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.Int, 0, "GroupID"));

                adapterStudents.UpdateCommand = new SqlCommand("sp_UpdStudent", connection); // создаем команду обновления на случай, если...
                adapterStudents.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapterStudents.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name"));
                adapterStudents.UpdateCommand.Parameters.Add(new SqlParameter("@Course", SqlDbType.Int, 0, "Course"));
                adapterStudents.UpdateCommand.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.Int, 0, "GroupID"));
                adapterStudents.UpdateCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, "StudentID"));

                adapterStudents.DeleteCommand = new SqlCommand("sp_DelStudent", connection); // создаем команду удаления...
                adapterStudents.DeleteCommand.CommandType = CommandType.StoredProcedure;
                adapterStudents.DeleteCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, "StudentID"));

                // обновляем БД
                adapterStudents.Update(dsStudents);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = dsStudents.Tables[0].NewRow();
            dsStudents.Tables[0].Rows.Add(row);
        }

        private void Sort_Click(object sender, RoutedEventArgs e) => dsStudents.Tables[0].DefaultView.Sort = "StudentID DESC";

        /*
         * private void SetPicture_Click(object sender, RoutedEventArgs e)
        {
            if (dgSt.SelectedIndex == -1)
                return;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true)
                return;

            FileStream stream = new FileStream(ofd.FileName, FileMode.Open);

        }*/
    }
}