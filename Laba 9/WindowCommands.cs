using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba_9
{
    class WindowCommands
    {
        static WindowCommands()
        {
            Add = new RoutedCommand("Add", typeof(MainWindow));
            Remove = new RoutedCommand("Remove", typeof(MainWindow));
            Change = new RoutedCommand("Change", typeof(MainWindow));
            SortName = new RoutedCommand("SortName", typeof(MainWindow));
            SortDescr = new RoutedCommand("SortDescr", typeof(MainWindow));
            SortCategory = new RoutedCommand("SortCategory", typeof(MainWindow));
            Undo = new RoutedCommand("Undo", typeof(MainWindow));
            Redo = new RoutedCommand("Redo", typeof(MainWindow));
        }
        public static RoutedCommand Add { get; set; }
        public static RoutedCommand Remove { get; set; }
        public static RoutedCommand Change { get; set; }
        public static RoutedCommand SortName { get; set; }
        public static RoutedCommand SortDescr { get; set; }
        public static RoutedCommand SortCategory { get; set; }
        public static RoutedCommand Undo { get; set; }
        public static RoutedCommand Redo { get; set; }
    }

    interface ICommand
    {
        void Action();
        void Undo();
    }

    class AddTask : ICommand
    {
        int taskIndex; // индекс добавленной задачи. при отмене будем удалять по этому индексу
        Task task; // задача, которую будем добавлять в случае "отмены отмены"

        public void Action()
        {
            MainWindow.list.Add(task);
        }

        public void Undo()
        {
            MainWindow.list.RemoveAt(taskIndex);
        }

        public AddTask(int index, Task task)
        {
            taskIndex = index;
            this.task = task;
        }
    }

    class RemoveTask : ICommand
    {
        int taskIndex; // индекс добавленной задачи. при отмене будем удалять по этому индексу
        Task task; // задача, которую будем добавлять в случае "отмены отмены"

        public void Action()
        {
            MainWindow.list.RemoveAt(taskIndex);
        }

        public void Undo()
        {
            MainWindow.list.Insert(taskIndex, task);
        }

        public RemoveTask(int index, Task task)
        {
            taskIndex = index;
            this.task = task;
        }
    }

    class ChangeTask : ICommand
    {
        int changingIndex;
        Task taskBeforeChanging;
        Task taskAfterChanging;

        public void Action()
        {
            MainWindow.list[changingIndex] = taskAfterChanging;
        }

        public void Undo()
        {
            MainWindow.list[changingIndex] = taskBeforeChanging;
        }

        public ChangeTask(int index, Task tBeforeCh, Task tAfterCh)
        {
            changingIndex = index; taskBeforeChanging = tBeforeCh; taskAfterChanging = tAfterCh;
        }
    }
}
