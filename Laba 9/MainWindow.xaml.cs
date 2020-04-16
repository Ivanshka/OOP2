using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Laba_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static BindingList<Task> list = new BindingList<Task>();
        static BindingList<Task> searchResultList = new BindingList<Task>();

        public MainWindow()
        {
            InitializeComponent();
            table.ItemsSource = list;

            // Loading cursor
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("pack://application:,,,/Resources/pointer.ani"));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
            // Loading icon
            //sri = Application.GetResourceStream(new Uri("pack://application:,,,/Resources/icon.ico"));
            //var conv = new ImageSourceConverter();
            //conv.ConvertFrom(sri.Stream);

            // Hot keys
            //ApplicationCommands.New.InputGestures.Add(new KeyBinding(ApplicationCommands.New, Key.N, ModifierKeys.Control).Gesture);

            // Multilanguage support
            Properties.Settings.Default.Reload();
            App.LanguageChanged += LanguageChanged;

            App.Language = Properties.Settings.Default.DefaultLanguage;
            
            // Menu for changing language
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(App.Language);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }

        // === MULTILANGUAGE SUPPORT ===

        private void LanguageChanged(object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
                Properties.Settings.Default.DefaultLanguage = lang;
                Properties.Settings.Default.Save();
                MessageBox.Show((string)FindResource("LangChangingMessage"), (string)FindResource("Warning"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // === COMMANDS HANDLERS ===
        private void Add_Executed(object sender, ExecutedRoutedEventArgs e){
            Task t = new Task()
            {
                Category = tbCategory.Text,
                Description = tbDescription.Text,
                End = dpEndDate.SelectedDate,
                Start = dpStartDate.SelectedDate,
                Name = tbName.Text,
                PriorityIndex = (TaskPriority)cbPriority.SelectedIndex,
                PeriodicityIndex = (Periodicity)cbPeriodicity.SelectedIndex
            };

            if (t.Name.Length == 0 || t.Start == null)
            {
                MessageBox.Show((string)FindResource("NoMinimalData"), (string)FindResource("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            switch (t.PriorityIndex)
            {
                case TaskPriority.High: t.Priority = (string)FindResource("HighPriority"); break;
                case TaskPriority.Middle: t.Priority = (string)FindResource("MiddlePriority"); break;
                case TaskPriority.Low: t.Priority = (string)FindResource("LowPriority"); break;
                default: t.Priority = (string)FindResource("MiddlePriority"); break;
            }

            switch (t.PeriodicityIndex)
            {
                case Periodicity.Annual: t.Periodicity = (string)FindResource("AnnualPeriodicity"); break;
                case Periodicity.Daily: t.Periodicity = (string)FindResource("DailyPeriodicity"); break;
                case Periodicity.Monthly: t.Periodicity = (string)FindResource("MonthlyPeriodicity"); break;
                case Periodicity.Single: t.Periodicity = (string)FindResource("SinglePeriodicity"); break;
                case Periodicity.Weekly: t.Periodicity = (string)FindResource("WeeklyPeriodicity"); break;
                default: t.Periodicity = (string)FindResource("SinglePeriodicity"); break;
            }

            list.Add(t);
        }

        private void Remove_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (table.SelectedItem != null)
                list.RemoveAt(table.SelectedIndex);
        }

        private void Change_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (table.SelectedItem == null)
                return;

            Task t = new Task()
            {
                Category = tbCategory.Text,
                Description = tbDescription.Text,
                End = dpEndDate.SelectedDate,
                Start = dpStartDate.SelectedDate,
                Name = tbName.Text,
                PriorityIndex = (TaskPriority)cbPriority.SelectedIndex,
                PeriodicityIndex = (Periodicity)cbPeriodicity.SelectedIndex
            };

            if (t.Name.Length == 0 || t.Start == null)
            {
                MessageBox.Show((string)FindResource("NoMinimalData"), (string)FindResource("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            switch (t.PriorityIndex)
            {
                case TaskPriority.High: t.Priority = (string)FindResource("HighPriority"); break;
                case TaskPriority.Middle: t.Priority = (string)FindResource("MiddlePriority"); break;
                case TaskPriority.Low: t.Priority = (string)FindResource("LowPriority"); break;
                default: t.Priority = (string)FindResource("MiddlePriority"); break;
            }

            switch (t.PeriodicityIndex)
            {
                case Periodicity.Annual: t.Periodicity = (string)FindResource("AnnualPeriodicity"); break;
                case Periodicity.Daily: t.Periodicity = (string)FindResource("DailyPeriodicity"); break;
                case Periodicity.Monthly: t.Periodicity = (string)FindResource("MonthlyPeriodicity"); break;
                case Periodicity.Single: t.Periodicity = (string)FindResource("SinglePeriodicity"); break;
                case Periodicity.Weekly: t.Periodicity = (string)FindResource("WeeklyPeriodicity"); break;
                default: t.Periodicity = (string)FindResource("SinglePeriodicity"); break;
            }

            list[table.SelectedIndex] = t;
        }
        
        private void New_Executed(object sender, ExecutedRoutedEventArgs e) => list.Clear();

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON-файл|*.json";
            bool? answer = openFileDialog.ShowDialog();
            if (answer.Value == false)
                return;

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(BindingList<Task>));
            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                list = (BindingList<Task>)json.ReadObject(fs);

            // adding info for current localization
            for (int i = 0; i < list.Count; i++)
            {
                switch (list[i].PriorityIndex)
                {
                    case TaskPriority.High: list[i].Priority = (string)FindResource("HighPriority"); break;
                    case TaskPriority.Middle: list[i].Priority = (string)FindResource("MiddlePriority"); break;
                    case TaskPriority.Low: list[i].Priority = (string)FindResource("LowPriority"); break;
                    default: list[i].Priority = (string)FindResource("MiddlePriority"); break;
                }

                switch (list[i].PeriodicityIndex)
                {
                    case Periodicity.Annual: list[i].Periodicity = (string)FindResource("AnnualPeriodicity"); break;
                    case Periodicity.Daily: list[i].Periodicity = (string)FindResource("DailyPeriodicity"); break;
                    case Periodicity.Monthly: list[i].Periodicity = (string)FindResource("MonthlyPeriodicity"); break;
                    case Periodicity.Single: list[i].Periodicity = (string)FindResource("SinglePeriodicity"); break;
                    case Periodicity.Weekly: list[i].Periodicity = (string)FindResource("WeeklyPeriodicity"); break;
                    default: list[i].Periodicity = (string)FindResource("SinglePeriodicity"); break;
                }
            }

            table.ItemsSource = list;
        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON-файл|*.json";
            bool? answer = saveFileDialog.ShowDialog();
            if (answer.Value == false)
                return;

            MessageBox.Show(saveFileDialog.FileName);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(BindingList<Task>));
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                json.WriteObject(fs, list);
        }

        private void Sort_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == WindowCommands.SortName)
                list = new BindingList<Task>((from l in list orderby l.Name select l).ToList());
            else if (e.Command == WindowCommands.SortDescr)
                list = new BindingList<Task>((from l in list orderby l.Description select l).ToList());
            else if (e.Command == WindowCommands.SortCategory)
                list = new BindingList<Task>((from l in list orderby l.Category select l).ToList());
            
            table.ItemsSource = list; // without it he doesn't update table(
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (temp.Text == "")
            {
                table.ItemsSource = list;
                searchResultList.Clear();
            }
            else
            {
                searchResultList = new BindingList<Task>();
                Regex regex = new Regex($@"(\w*){temp.Text}(\w*)", RegexOptions.IgnoreCase);
                foreach (Task t in list)
                {
                    Match m = regex.Match($"{t.Name} {t.Description} {t.Start} {t.End}");
                    if (m.Success)
                        searchResultList.Add(t);
                }
                table.ItemsSource = searchResultList;
            }
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table.SelectedIndex < 0) // without it program will crash when searching
                return;
            List<Task> list = new List<Task>((IEnumerable<Task>)table.ItemsSource);
            tbName.Text = list[table.SelectedIndex].Name;
            tbCategory.Text = list[table.SelectedIndex].Category;
            tbDescription.Text = list[table.SelectedIndex].Description;
            dpEndDate.SelectedDate = list[table.SelectedIndex].End;
            cbPeriodicity.SelectedIndex = (int)list[table.SelectedIndex].PeriodicityIndex;
            cbPriority.SelectedIndex = (int)list[table.SelectedIndex].PriorityIndex;
            dpStartDate.SelectedDate = list[table.SelectedIndex].Start;
        }
    }
}
