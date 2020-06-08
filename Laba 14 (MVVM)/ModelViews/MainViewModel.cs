using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Laba_14
{
    /// <summary>
    /// ViewModel-часть MVVM. Она является контекстом данных (источником данных) для представления.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        DatabaseContext dbContext;
        private Record selectedRecord;

        public MainViewModel()
        {
            // инициализация команд
            AddCommand = new RelayCommand((a) => Add());
            RemoveCommand = new RelayCommand((a) => Remove());
            SaveCommand = new RelayCommand((a) => Save());

            // скачивание данных из БД
            InfoBox info = new InfoBox("Подключение к базе данных...", 200, 50, true);
            info.Show();
            try
            {
                dbContext = new DatabaseContext();
                dbContext.Records.Load();
            }
            catch (Exception e) { MessageBox.Show("Произошла критическая ошибка. Приложение будет закрыто.\nПодробнее:\n" + e.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Stop); info.Close(); Application.Current.Shutdown(); }
            info.Close();
            Records = dbContext.Records.Local;
        }

        public ObservableCollection<Record> Records { get; set; }
        public Record SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                selectedRecord = value;
                OnPropertyChanged("SelectedRecord");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        
        // команды
        public RelayCommand AddCommand { get; }
        public RelayCommand RemoveCommand { get; }
        public RelayCommand SaveCommand { get; }

        void Add()
        {
            dbContext.Records.Add(new Record() { Date = DateTime.Now });
            SelectedRecord = Records[0];
            Save();
        }
        private void Remove()
        {
            dbContext.Records.Remove(SelectedRecord);
            Save();
        }
        void Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e) { MessageBox.Show("Не удалось завершить операцию!\nПодробности:\n" + e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
