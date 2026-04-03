using System.Windows.Input;

namespace View.ViewModel;

/// <summary>
/// Представляет универсальную команду, реализующую интерфейс <see cref="ICommand"/>.
/// </summary>
internal class RelayCommand : ICommand
{
    /// <summary>
    /// Поле хранящее ссылку на метод который показывает, выполнимо ли действие в данный момент
    /// </summary>
    private readonly Func<object,bool> _canExecute;

    /// <summary>
    /// Поле хранящее ссылку на метод который необходимо выполнить
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
    /// Инициализирует новый экземпляр класса <see cref="RelayCommand"/>.
    /// </summary>
    /// <param name="execute">Делегат, содержащий логику выполнения команды.</param>
    /// <param name="canExecute">Делегат, содержащий логику проверки доступности команды.</param>
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Определяет, можно ли выполнить команду.
    /// </summary>
    /// <returns>Если не передан 2 параметр true, или результат переданного параметра</returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
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
