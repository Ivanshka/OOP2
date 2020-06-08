using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Laba_14
{
    /// <summary>
    /// ViewModel-часть MVVM. Она является контекстом данных (источником данных) для представления.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private Record selectedRecord;

        public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>(new System.Collections.Generic.List<Record>() { new Record() { Date = System.DateTime.Now, IntervalEndTime = "15:25", IntervalStartTime= "13:50", Name = "ФИО", Subject = "Предмет" }, new Record() { Date = System.DateTime.Now, IntervalEndTime = "15:25", IntervalStartTime = "13:50", Name = "ФИО", Subject = "Предмет" } });
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

        public MainViewModel()
        {
            AddCommand = new RelayCommand((a) => Add());
            RemoveCommand = new RelayCommand((a) => Remove());
        }

        // команды
        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }

        void Add()
        {
            Record r = new Record();
            Records.Insert(0, r);
            SelectedRecord = r;
        }
        private void Remove() => Records.Remove(SelectedRecord);
    }
}
