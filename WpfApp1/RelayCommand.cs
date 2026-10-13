using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        private Action _execute;
        private Func<bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public void Execute(object? parameter)
        {
            _execute();
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
    }
}
