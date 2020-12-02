using System;
using System.Windows.Input;

namespace ViewModel
{
    /// <summary>
    /// Implements commands between View and ViewModel.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public sealed class RelayCommand : ICommand
    {
		/// <summary>
		/// The can execute function.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly Func<object, bool> canExecute;

		/// <summary>
		/// The execute command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly Action<object> execute;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null />.</param>
        /// <returns>True if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param>Data used by the command.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="execute">The execution method.</param>
        /// <param name="canExecute">The possibility of execution. Value is null by default.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}