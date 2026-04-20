using System.ComponentModel;
using View.Model.Services;

namespace View.Model;

/// <summary>
/// Класс, представляющий контактную информацию с поддержкой валидации и уведомлений об изменениях.
/// </summary>
/// <remarks>
/// Реализует интерфейсы:
/// - INotifyPropertyChanged — для уведомления UI об изменениях свойств
/// - IDataErrorInfo — для интеграции с WPF валидацией
/// Валидация выполняется через ContactValidator. Ошибки кэшируются в словаре _errors
/// и не пересчитываются при каждом обращении к индексатору.
/// </remarks>
public class Contact : INotifyPropertyChanged, IDataErrorInfo
{
    /// <summary>
    /// Поле для хранения имени контакта
    /// </summary>
    private string _name;

    /// <summary>
    /// Поле для хранения номера контакта
    /// </summary>
    private string _phoneNumber;

    /// <summary>
    /// Поле для хранения почты контакта
    /// </summary>
    private string _email;

    /// <summary>
    /// Поле для хранения валидатора
    /// </summary>
    private readonly ContactValidator _validator = new();

    /// <summary>
    /// Поле для хранения списка ошибок валидации
    /// </summary>
    private readonly Dictionary<string, List<string>> _errors = new();

    /// <summary>
    /// Событие, возникающее при изменении свойства.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Событие возниющее при изменении ошибок
    /// </summary>
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Contact()
    {
        _name = string.Empty;
        _phoneNumber = string.Empty;
        _email = string.Empty;
    }

    /// <summary>
    /// Конструктор для инициализации контакта с параметрами.
    /// </summary>
    /// <param name="name">Имя контакта.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="email">Адрес электронной почты.</param>
    public Contact(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber; 
        Email = email;
        ValidateAll();
    }

    /// <summary>
    /// Имя контакта
    /// </summary>
    public string Name
    {
        get { return _name; }
        set
        {
            if(_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                UpdateErrors(nameof(Name));
            }
        }
    }

    /// <summary>
    /// Номер контакта
    /// </summary>
    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            if (_phoneNumber != value)
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
                UpdateErrors(nameof(PhoneNumber));
            }
        }
    }

    /// <summary>
    /// Почта контакта
    /// </summary>
    public string Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                UpdateErrors(nameof(Email));
            }
        }
    }

    /// <summary>
    /// Словарь ошибок валидации по названиям свойств.
    /// </summary>
    /// <remarks>
    /// Возвращает IReadOnlyDictionary для защиты от внешних изменений.
    /// </remarks>
    public IReadOnlyDictionary<string, List<string>> Errors => _errors;

    /// <summary>
    /// Указывает, есть ли хотя бы одна ошибка валидации.
    /// </summary>
    public bool HasErrors => _errors.Any();

    /// <summary>
    /// Возвращает общую ошибку для объекта (не используется).
    /// </summary>
    string IDataErrorInfo.Error => null!;

    /// <summary>
    /// Возвращает ошибку валидации для указанного свойства.
    /// </summary>
    /// <param name="columnName">Имя свойства.</param>
    /// <returns>Текст ошибки или null, если ошибок нет.</returns>
    /// <remarks>
    /// Данные берутся из кэшированного словаря _errors, который обновляется
    /// через UpdateErrors при каждом изменении свойства.
    /// </remarks>
    string IDataErrorInfo.this[string columnName]
    {
        get
        {
            if (_errors.TryGetValue(columnName, out List<string>? errors) && errors.Count > 0)
            {
                return errors[0];
            }
            return null!;
        }
    }

    /// <summary>
    /// Метод для вызова события PropertyChanged.
    /// </summary>
    /// <param name="propertyName">Имя изменившегося свойства.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Обновляет коллекцию ошибок валидации и уведомляет UI об изменениях.
    /// Выполняет полную валидацию объекта через FluentValidation и заполняет словарь ошибок.
    /// </summary>
    /// <param name="propertyName">
    /// Имя свойства, для которого выполняется обновление ошибок.
    /// </param>
    private void UpdateErrors(string propertyName)
    {
        _errors.Clear();
        var result = _validator.Validate(this);
        foreach (var error in result.Errors)
        {
            _errors[error.PropertyName] = new() { error.ErrorMessage };

        }
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Принудительно запускает полную валидацию всех полей.
    /// </summary>
    public void ValidateAll()
    {
        UpdateErrors(string.Empty);
    }
}
