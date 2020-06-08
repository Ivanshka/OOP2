using System;
using System.Windows.Input;

// HELP: https://metanit.com/sharp/wpf/22.3.php

namespace Laba_14
{
    /// <summary>
    /// WPF имеет в качестве реализации этого интерфейса имеет класс System.Windows.Input.RoutedCommand,
    /// который ограничен по функциональности. Поэтому, как правило, придется реализовывать свои собственные
    /// команды с помощью реализации ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);
    }
}
