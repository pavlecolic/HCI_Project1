using System;
using System.Windows.Input;

namespace Casablanca.ViewModel
{
    /// <summary>
    /// A command that relays its functionality to other objects by invoking delegates.
    /// </summary>
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object?> _executeAction;
        private readonly Predicate<object?>? _canExecuteAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The action to execute when the command is invoked.</param>
        public ViewModelCommand(Action<object?> executeAction)
            : this(executeAction, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The action to execute when the command is invoked.</param>
        /// <param name="canExecuteAction">The predicate to determine if the command can execute.</param>
        public ViewModelCommand(Action<object?> executeAction, Predicate<object?>? canExecuteAction)
        {
            _executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            _canExecuteAction = canExecuteAction;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
