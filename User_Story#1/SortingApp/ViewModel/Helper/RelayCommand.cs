﻿using System;
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
        /// Generic delegate to determine whether command can be executed.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param>Object for the command implementation.</param>
        /// <returns>The possibility of execution.</returns>
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// The implementation of the command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param>Object for the command implementation.</param>
        private readonly Action<object> execute;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param>Data used by the command.</param>
        /// <returns>If this command can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

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
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="execute">The execution method.</param>
        /// <param name="canExecute">The possibility of execution. Value is null by default.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
