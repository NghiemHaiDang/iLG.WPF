using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace iLG.WPF.Presentation.Commands.Generic
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object? parameter)
        {
            try
            {
                return _canExecute?.Invoke(parameter ?? throw new ArgumentNullException(nameof(parameter))) ?? false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Execute(object? parameter)
        {
            try
            {
                _execute(parameter ?? throw new ArgumentNullException(nameof(parameter)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
