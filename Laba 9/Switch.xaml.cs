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

namespace Laba_9
{
    /// <summary>
    /// Логика взаимодействия для Switch.xaml
    /// </summary>
    public partial class Switch : UserControl
    {
        bool enabled = false;

        public Switch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!enabled)
            {
                button.Content = "ВЫКЛ";
                ellipse.Fill = new SolidColorBrush(Colors.Lime);
                enabled = !enabled;
                App.DarkTheme = true;
            }
            else
            {
                button.Content = "ВКЛ";
                ellipse.Fill = new SolidColorBrush(Colors.Red);
                enabled = !enabled;
                App.DarkTheme = false;
            }
        }
    }
}
