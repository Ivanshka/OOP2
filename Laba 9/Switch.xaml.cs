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
        /*public static new readonly DependencyProperty BackgroundProperty;
        public new Color Background
        {
            get
            {

                return (Color)GetValue(BackgroundProperty);

            }
            set
            {
                SetValue(BackgroundProperty, value);
            }
        }*/

        bool enabled = false;

        /// <summary>
        /// Событие, возникающее при переключении выключателя.
        /// </summary>
        public event SwitchClickedDelegate SwitchClicked;
        public delegate void SwitchClickedDelegate(bool Enabled);

        static Switch()
        {
            //BackgroundProperty = DependencyProperty.Register("Background", typeof(Color), typeof(Switch), new PropertyMetadata(Colors.Gray));
        }

        public Switch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SwitchClicked?.Invoke(enabled);

            if (!enabled)
            {
                button.Content = "ВЫКЛ";
                ellipse.Fill = new SolidColorBrush(Colors.Lime);
                enabled = !enabled;
            }
            else
            {
                button.Content = "ВКЛ";
                ellipse.Fill = new SolidColorBrush(Colors.Red);
                enabled = !enabled;
            }
        }
    }
}
