using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba_10
{
    public class Commands
    {
        // создание
        private static RoutedUICommand find;

        static Commands()
        {
            // инициализация
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.F, ModifierKeys.Control, "Ctrl + F"));
            find = new RoutedUICommand("Find", "Find", typeof(Commands), inputs);
        }

        public static RoutedUICommand Find { get { return find; } }
    }
}

/*
В чем отличие RoutedCommand от RoutedUICommand?
RoutedUICommand происходит из RoutedCommand и добавляет текстовое поле,
используемое для предоставления описания команды. Это полезно, когда
команда должна быть доступна из пользовательского интерфейса.
https://qarchive.ru/362358_v_chem_raznitsa_mezhdu_routedcommand_i_routeduicommand_
     
*/
