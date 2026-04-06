using System.ComponentModel;
namespace View.Model;
using System.Linq;
using View.Model.Services;
using System.Diagnostics;

/// <summary>
/// Класс, представляющий контактную информацию.
/// </summary>
public class Contact : INotifyPropertyChanged, IDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new();
    public Dictionary<string, List<string>> Errors => _errors;
    public bool HasErrors => _errors.Any();

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    private readonly ContactValidator _validator = new();

    string IDataErrorInfo.Error => null;
    string IDataErrorInfo.this[string columnName]
    {
        get
        {
            var result = _validator.Validate(this);
            return result.IsValid ? null : result.Errors.FirstOrDefault(e => e.PropertyName == columnName)?.ErrorMessage;
        }
    }

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
    /// Событие, возникающее при изменении свойства.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

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
    /// Метод для вызова события PropertyChanged.
    /// </summary>
    /// <param name="propertyName">Имя изменившегося свойства.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void UpdateErrors(string propertyName)
    {
        _errors.Clear();
        var result = _validator.Validate(this);

        Debug.WriteLine($"Errors: {result.IsValid}");


        foreach (var error in result.Errors)
        {
            Debug.WriteLine($"Error {error.PropertyName}: {error.ErrorMessage}");
            _errors[error.PropertyName] = new() { error.ErrorMessage };

        }
            
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public void ValidateAll()
    {
        Debug.WriteLine("ValidateAll called");
        UpdateErrors(string.Empty);
    }
}
