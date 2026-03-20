using System.Windows.Input;
using View.Model;


namespace View.ViewModel;

internal class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Определяет можно ли выполнить команду сейчас. Кнопка всегда доступна.
    /// </summary>
    /// <returns>всегда true</returns>
    public bool CanExecute(object parameter)
    {
        return true;
    }

    /// <summary>
    /// Определяет, что происходит при выполнении команды.
    /// </summary>
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    /// <summary>
    ///Событие которое возникает при изменении возможности выполнения команды.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}
