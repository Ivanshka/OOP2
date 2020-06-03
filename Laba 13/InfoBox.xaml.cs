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
using System.Windows.Shapes;

namespace Laba_13
{
    /// <summary>
    /// Логика взаимодействия для InfoBox.xaml
    /// </summary>
    public partial class InfoBox : Window
    {
        public InfoBox(string info, int winWidth = 200, int winHeight = 50, bool topmost = false, bool showInTaskbar = false)
        {
            InitializeComponent();
            Info.Content = info;
            Width = winWidth;
            Height = winHeight;
            Topmost = topmost;
            ShowInTaskbar = showInTaskbar;
        }
    }
}
