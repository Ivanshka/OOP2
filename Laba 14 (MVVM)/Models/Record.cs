using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Laba_14
{
    /// <summary>
    /// Model-часть MVVM
    /// </summary>
    public class Record : INotifyPropertyChanged
    {
        // поля
        string name;
        string subject;
        DateTime date;
        string intervalStartTime;
        string intervalEndTime;

        // свойства
        [Key] // первичный ключ таблицы
        public int ID { get; set; }
        public string Name
        {
            get {return name;}
            set { name = value; OnPropertyChanged("Name"); }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; OnPropertyChanged("Subject"); }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        public string IntervalStartTime
        {
            get { return intervalStartTime; }
            set { intervalStartTime = value; OnPropertyChanged("IntervalStartTime"); }
        }

        public string IntervalEndTime
        {
            get { return intervalEndTime; }
            set { intervalEndTime = value; OnPropertyChanged("IntervalEndTime"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
