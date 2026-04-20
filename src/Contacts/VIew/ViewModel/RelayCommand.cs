using System.Windows.Input;

namespace View.ViewModel;

/// <summary>
/// Представляет универсальную команду, реализующую интерфейс <see cref="ICommand"/>.
/// </summary>
/// <remarks>
/// Используется для связывания логики выполнения с UI-элементами (кнопки, меню и т.д.).
/// Поддерживает автоматическое обновление состояния через CommandManager.RequerySuggested.
/// </remarks>
internal class RelayCommand : ICommand
{
    /// <summary>
    /// Делегат, определяющий, можно ли выполнить команду в текущий момент.
    /// </summary>
    private readonly Func<object, bool> _canExecute;

    /// <summary>
    /// Делегат, содержащий логику выполнения команды.
    /// </summary>
    private readonly Action<object> _execute;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RelayCommand"/> 
    /// с указанием только логики выполнения (команда всегда доступна).
    /// </summary>
    /// <param name="execute">Делегат, содержащий логику выполнения команды.</param>
    public RelayCommand(Action<object> execute)
    {
        _execute = execute;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RelayCommand"/> 
    /// с указанием логики выполнения и проверки доступности.
    /// </summary>
    /// <param name="execute">Делегат, содержащий логику выполнения команды.</param>
    /// <param name="canExecute">Делегат, содержащий логику проверки доступности команды.</param>
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Определяет, можно ли выполнить команду в текущем состоянии.
    /// </summary>
    /// <param name="parameter">Параметр команды (может быть null).</param>
    /// <returns>
    /// true — если команда может быть выполнена;
    /// false — если выполнение запрещено.
    /// </returns>
    /// <remarks>
    /// Если делегат canExecute не был передан в конструктор, метод всегда возвращает true.
    /// </remarks>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Выполняет команду.
    /// </summary>
    /// <param name="parameter">Параметр команды (может быть null).</param>
    public void Execute(object parameter)
    {
        _execute(parameter);
    }

    /// <summary>
    /// Событие, возникающее при изменении возможности выполнения команды.
    /// </summary>
    /// <remarks>
    /// Использует CommandManager.RequerySuggested для автоматического обновления состояния UI.
    /// </remarks>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}