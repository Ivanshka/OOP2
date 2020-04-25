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

namespace Laba_10
{
    /// <summary>
    /// Логика взаимодействия для Switch.xaml
    /// </summary>
    public partial class Switch : UserControl
    {
        // Свойства зависимостей. Чтобы все работало, ставим {Binding *обертка*, ElementName=*x:Name контрола*}
        public static readonly DependencyProperty SwitchEnabledProperty;
        public static new readonly DependencyProperty BackgroundProperty;
        public static readonly DependencyProperty EnTextProperty;
        public static readonly DependencyProperty DisTextProperty;

        // Их обертки
        public bool SwitchEnabled { get { return (bool)GetValue(SwitchEnabledProperty); } set { SetValue(SwitchEnabledProperty, value); } }
        public new Brush Background { get { return (Brush)GetValue(BackgroundProperty); } set { SetValue(BackgroundProperty, value); } }
        public string EnText { get { return (string)GetValue(EnTextProperty); } set { SetValue(EnTextProperty, value); } }
        public string DisText { get { return (string)GetValue(DisTextProperty); } set { SetValue(DisTextProperty, value); } }

        // Событие нажатия и его обертка
        public static readonly RoutedEvent ClickEvent; // добавление обработчика                // удаление обработчика
        public event RoutedEventHandler Click { add { AddHandler(ClickEvent, value); } remove { RemoveHandler(ClickEvent, value); } }

        static Switch()
        {
            SwitchEnabledProperty = DependencyProperty.Register("SwitchEnabled", typeof(bool), typeof(Switch), new PropertyMetadata(false));
            BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(Switch), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));
            EnTextProperty = DependencyProperty.Register("EnText", typeof(string), typeof(Switch));
            DisTextProperty = DependencyProperty.Register("DisText", typeof(string), typeof(Switch));

            ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Switch));
        }

        public Switch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!SwitchEnabled)
            {
                button.Content = DisText;
                ellipse.Fill = new SolidColorBrush(Colors.Lime);
                SwitchEnabled = !SwitchEnabled;
            }
            else
            {
                button.Content = EnText;
                ellipse.Fill = new SolidColorBrush(Colors.Red);
                SwitchEnabled = !SwitchEnabled;
            }

            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
    }
}
