using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ItemList
{
    /// <summary>
    /// This class is used for implementing commands between View and ViewModel
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public class RelayCommand : ICommand
    {
        private Func<object, bool> canExecute;
        private Action<object> execute;

        //
        // Method defines can the command be executed.
        //
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        //
        // Method defines can the command be executed, when conditions have been changed.
        //
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //
        // Method executes a command.
        //
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
