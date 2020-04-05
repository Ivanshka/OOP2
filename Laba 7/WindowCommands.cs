using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba_7
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
        }
        public static RoutedCommand Add { get; set; }
        public static RoutedCommand Remove { get; set; }
        public static RoutedCommand Change { get; set; }
        public static RoutedCommand SortName { get; set; }
        public static RoutedCommand SortDescr { get; set; }
        public static RoutedCommand SortCategory { get; set; }
    }
}
