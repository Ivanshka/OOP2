using System;
using System.Collections.Generic;
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
using System.Data.Entity;

namespace Laba_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Концентратор репозиториев с единым контекстом
        /// </summary>
        UnitOfWork db;

        public MainWindow()
        {
            InitializeComponent();
            db = new UnitOfWork();
            InfoBox infoBox = new InfoBox("Подключение к базе данных...", 200, 50, true); // плюшка с окном чисто для себя
            infoBox.Show();
            Button_Click(null, null); // "нажимаем" кнопку обновления
            infoBox.Close();
        }

        // обновить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // обновляем репозитории, синхронизируем их с серваком
            db.Owners.Refresh();
            db.Cars.Refresh();
            // ставим источники данных
            dgUser.ItemsSource = db.Owners.GetAllObjects().ToList();
            dgCar.ItemsSource = db.Cars.GetAllObjects().ToList();
        }

        // добавить чела
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Owners.Create(new Owner() { Age = Convert.ToInt32(userAge.Text), Name = userName.Text });
            }
            catch { MessageBox.Show("Проверьте входные данные!", "Ошибка!"); return; }
            db.Save();
            dgUser.ItemsSource = db.Owners.GetAllObjects().ToList();
        }

        // добавить машину
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите владельца!");
                return;
            }
            db.Cars.Create(new Car() { Color = carColor.Text, Model = carModel.Text, Owner = db.Owners.GetObject((dgUser.SelectedItem as Owner).ID) }); // ищем по первичному ключу, т.е. по ID, а он считается с 1 => id = index + 1
            SaveAndReload();
        }

        // удалить чела
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
                db.Owners.Delete((dgUser.SelectedItem as Owner).ID);
            SaveAndReload();
        }

        // удалить машину
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
                db.Cars.Delete((dgCar.SelectedItem as Car).ID);
            SaveAndReload();
        }

        // сохраняет изменения и перекачивает данные
        private void SaveAndReload()
        {
            db.Save();
            dgUser.ItemsSource = db.Owners.GetAllObjects().ToList();
            dgCar.ItemsSource = db.Cars.GetAllObjects().ToList();
        }

        // выделение в таблицах изменено
        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
            {
                var t = db.Owners.GetObject((dgUser.SelectedItem as Owner).ID);
                userName.Text = t.Name;
                userAge.Text = t.Age.ToString();
            }
        }

        private void dgCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
            {
                var t = db.Cars.GetObject((dgCar.SelectedItem as Car).ID);
                carColor.Text = t.Color;
                carModel.Text = t.Model;
                if (t.Owner != null)
                    carOwner.Text = t.Owner.ToString();
            }
        }

        // изменить чела
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
            {
                var t = db.Owners.GetObject((dgUser.SelectedItem as Owner).ID);
                t.Age = Convert.ToInt32(userAge.Text);
                t.Name = userName.Text;
                SaveAndReload();
            }
        }

        // изменить тачку
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
            {
                var t = db.Cars.GetObject((dgCar.SelectedItem as Car).ID);
                t.Color = carColor.Text;
                t.Model = carModel.Text;
                t.Owner = db.Owners.GetObject(Convert.ToInt32(carOwner.Text));
                SaveAndReload();
            }
        }

        // сортировка машин по id владельца
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            dgCar.ItemsSource = (from c in db.Cars.GetAllObjects()
                                 orderby c.Owner.ID
                                 select c).ToList();
        }
    }
}
