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

namespace Laba_12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserContext db;
        public MainWindow()
        {
            InitializeComponent();
            Button_Click(null, null); // "нажимаем" на кнопку обновления
        }

        // обновить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new UserContext();
            try
            {
                db.Owners.Load();
                db.Cars.Load();
            }
            catch { MessageBox.Show("Спасибо этому дому, пойду к другому!\nКонтекст базы данных не соответствует базе на сервере!", "Ошибка!"); }
            dgUser.ItemsSource = db.Owners.Local;
            dgCar.ItemsSource = db.Cars.Local;
        }

        // добавить чела                 ТРАНЗАКЦИЯ ТУТ
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Owners.Add(new Owner() { Age = Convert.ToInt32(userAge.Text), Name = userName.Text });
                    db.SaveChanges();
                    dgUser.ItemsSource = db.Owners.Local;
                    transaction.Commit();
                }
                catch { MessageBox.Show("Что-то пошло не по плану! Отменяем транзакцию!"); transaction.Rollback(); }
            }
        }

        // добавить машину
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите владельца!");
                return;
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Cars.Add(new Car() { Color = carColor.Text, Model = carModel.Text, Owner = db.Owners.Find(dgUser.SelectedIndex + 1) }); // ищем по первичному ключу, т.е. по ID, а он считается с 1 => id = index + 1
                    db.SaveChanges();
                    dgCar.ItemsSource = db.Cars.Local;
                    transaction.Commit();
                }
                catch { MessageBox.Show("Что-то пошло не по плану! Отменяем транзакцию!"); transaction.Rollback(); }
            }
        }

        // удалить чела
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
                db.Owners.Remove(db.Owners.Local[dgUser.SelectedIndex]);
            SaveAndReload();
        }

        // удалить машину
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
                db.Cars.Remove(db.Cars.Local[dgCar.SelectedIndex]);
            SaveAndReload();
        }

        // сохраняет изменения и перекачивает данные
        private void SaveAndReload()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch { MessageBox.Show("Что-то пошло не по плану! Отменяем транзакцию!"); transaction.Rollback(); }
            }
            db.Owners.Load();
            db.Cars.Load();

            dgUser.ItemsSource = db.Owners.Local;
            dgCar.ItemsSource = db.Cars.Local;
        }

        // выделение в таблицах изменено
        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
            {
                userName.Text = db.Owners.Local[dgUser.SelectedIndex].Name;
                userAge.Text = db.Owners.Local[dgUser.SelectedIndex].Age.ToString();
            }
        }

        private void dgCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
            {
                carColor.Text = db.Cars.Local[dgCar.SelectedIndex].Color;
                carModel.Text = db.Cars.Local[dgCar.SelectedIndex].Model;
                if (db.Cars.Local[dgCar.SelectedIndex].Owner != null)
                    carOwner.Text = db.Cars.Local[dgCar.SelectedIndex].Owner.ID.ToString();
            }
        }

        // изменить чела
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedIndex != -1)
            {
                var temp = db.Owners.Find(dgUser.SelectedIndex + 1); // ищем по первичному ключу, т.е. по ID, а он считается с 1 => id = index + 1
                temp.Age = Convert.ToInt32(userAge.Text);
                temp.Name = userName.Text;
                SaveAndReload();
            }
        }

        // изменить тачку
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (dgCar.SelectedIndex != -1)
            {
                var temp = db.Cars.Find(dgCar.SelectedIndex + 1); // ищем по первичному ключу, т.е. по ID, а он считается с 1 => id = index + 1
                temp.Color = carColor.Text;
                temp.Model = carModel.Text;
                temp.Owner = db.Owners.Find(Convert.ToInt32(carOwner.Text));
                SaveAndReload();
            }
        }

        // сортировка машин по id владельца
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            dgCar.ItemsSource = (from c in db.Cars
                                 orderby c.Owner.ID
                                 select c).ToList();
        }
    }
}
