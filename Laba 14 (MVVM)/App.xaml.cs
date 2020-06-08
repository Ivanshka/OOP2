using System.Windows;

namespace Laba_14
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            MainView view = new MainView(); // View. Он уже связан с Model
            //MainViewModel viewModel = new MainViewModel(); // ViewModel
            //view.DataContext = viewModel;
            view.Show(); // запускаем
        }
    }
}
