using System;
using System.Windows;

namespace Laba_14
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e) { MessageBox.Show("При инициализации произошла критическая ошибка! Приложение будет закрыто.\nПодробности:\n" + e.Message, "Критическая ошибка инициализации!", MessageBoxButton.OK, MessageBoxImage.Stop); Application.Current.Shutdown(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).AddCommand.Execute(null);
        }
    }
}
