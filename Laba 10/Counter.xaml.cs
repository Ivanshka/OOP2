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
    /// Логика взаимодействия для Counter.xaml
    /// </summary>
    public partial class Counter : UserControl
    {
        public static readonly DependencyProperty numProperty;
        public int Num { get { return (int)GetValue(numProperty); }
                         set { try { SetValue(numProperty, value); } catch { MessageBox.Show("Недействительное значение!", "Если валидация не пройдена, генерируется исключение!"); } } }

        public Counter()
        {
            InitializeComponent();
        }

        static Counter()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender);
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            numProperty = DependencyProperty.Register("Num",
                typeof(int),
                typeof(Counter),
                metadata,
                new ValidateValueCallback(ValidateValue));
        }

        // Методы валидации и коррекции
        private static bool ValidateValue(object value)
        {
            if ((int)value > -1)
                return true;
            return false;
        }

        private static object CorrectValue(DependencyObject d, object value)
        {
            if ((int)value > 10)
                return 10;
            return value;
        }

        // Обработчики событий
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Num++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Num--;
        }
    }
}
