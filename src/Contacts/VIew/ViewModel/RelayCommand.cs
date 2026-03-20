using System.Windows.Input;
using View.Model;


namespace View.ViewModel;

/// <summary>
/// Представляет универсальную команду, реализующую интерфейс <see cref="ICommand"/>.
/// </summary>
internal class RelayCommand : ICommand
{
    /// <summary>
    /// Поле хранящее ссылку на метод которое необходимо выполнить
    /// </summary>
    private readonly Action<object> _execute;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RelayCommand"/>.
    /// </summary>
    /// <param name="execute">Делегат, содержащий логику выполнения команды.</param>
    public RelayCommand(Action<object> execute)
    {
        _execute = execute;
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
