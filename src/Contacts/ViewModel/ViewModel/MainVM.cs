using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Model.Model;
using Model.Model.Services;
using ViewModel.ViewModel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace View.ViewModel;

/// <summary>
/// ViewModel для главного окна приложения.
/// </summary>
public partial class MainVM : ObservableObject
{
    #region Private Fields

    /// <summary>
    /// Коллекция контактов, хранящая актуальные данные.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<Contact> _contacts;

    /// <summary>
    /// Текущий выбранный контакт.
    /// </summary>
    private Contact _selectedContact;

    /// <summary>
    /// Редактируемый контакт для временного хранения данных.
    /// </summary>
    [ObservableProperty]
    private Contact _editableContact;

    /// <summary>
    /// Флаг, указывающий, что выполняется добавление нового контакта.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsReadOnly))]
    [NotifyPropertyChangedFor(nameof(IsApplyVisible))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(EditCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    private bool _isAdding;

    /// <summary>
    /// Флаг, указывающий, что выполняется редактирование существующего контакта.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsReadOnly))]
    [NotifyPropertyChangedFor(nameof(IsApplyVisible))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(EditCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    private bool _isEditing;

    /// <summary>
    /// Сервис сериализации контактов.
    /// </summary>
    private readonly ContactSerializer _serializer;

    /// <summary>
    /// Сервис для отображения сообщений пользователю.
    /// </summary>
    private readonly IMessageService _messageService;

    /// <summary>
    /// Контакт, на который подписаны обработчики для обновления <see cref="ApplyCommand"/>.
    /// </summary>
    private Contact? _editableContactSubscriptionsTarget;

    /// <summary>
    /// Представление коллекции контактов для фильтрации.
    /// </summary>
    private ICollectionView _contactsView;

    /// <summary>
    /// Текст поискового запроса.
    /// </summary>
    [ObservableProperty]
    private string _searchText = "";

    /// <summary>
    /// Имя редактируемого контакта.
    /// </summary>
    [ObservableProperty]
    private string _name;

    /// <summary>
    /// Номер телефона редактируемого контакта.
    /// </summary>
    [ObservableProperty]
    private string _phoneNumber;

    /// <summary>
    /// Email редактируемого контакта.
    /// </summary>
    [ObservableProperty]
    private string _email;

    #endregion

    #region Constructor

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="MainVM"/>.
    /// </summary>
    /// <param name="messageService">Сервис для отображения сообщений.</param>
    public MainVM(IMessageService messageService)
    {
        _contacts = new ObservableCollection<Contact>();
        _serializer = new ContactSerializer();
        _messageService = messageService;
        EditableContact = new Contact();

        try
        {
            var loadedContacts = _serializer.LoadContact();
            foreach (var c in loadedContacts)
                _contacts.Add(c);
        }
        catch (Exception ex)
        {
            _messageService.FailureMessage(ex);
        }

        CollectionView = CollectionViewSource.GetDefaultView(_contacts);
        CollectionView.Filter = item => FilteredContacts(item);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Получает или задает отфильтрованное представление коллекции контактов.
    /// </summary>
    public ICollectionView CollectionView
    {
        get => _contactsView;
        set
        {
            _contactsView = value;
            _contactsView?.Refresh();
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Получает или задает текущий выбранный контакт.
    /// </summary>
    public Contact SelectedContact
    {
        get => _selectedContact;
        set
        {
            if (_selectedContact == value) return;

            if (IsEditing || IsAdding)
            {
                CancelEditing();
            }

            _selectedContact = value;

            if (value != null && !IsAdding && !IsEditing)
            {
                EditableContact = new Contact
                {
                    Name = value.Name,
                    PhoneNumber = value.PhoneNumber,
                    Email = value.Email
                };
            }

            OnPropertyChanged();

            RemoveCommand.NotifyCanExecuteChanged();
            EditCommand.NotifyCanExecuteChanged();
        }
    }

    /// <summary>
    /// Получает значение, указывающее, находится ли интерфейс в режиме только для чтения.
    /// </summary>
    public bool IsReadOnly => !IsAdding && !IsEditing;

    /// <summary>
    /// Получает значение, указывающее, видима ли кнопка Apply.
    /// </summary>
    public bool IsApplyVisible => IsAdding || IsEditing;

    #endregion

    #region Partial Methods

    /// <summary>
    /// Вызывается при изменении свойства <see cref="SearchText"/>.
    /// Обновляет фильтрацию коллекции контактов.
    /// </summary>
    /// <param name="value">Новое значение поискового запроса.</param>
    partial void OnSearchTextChanged(string value)
    {
        _contactsView?.Refresh();
    }

    /// <summary>
    /// Вызывается при смене редактируемого контакта:
    /// подписка на ввод и валидацию для актуализации <see cref="ApplyCommand"/>.
    /// </summary>
    partial void OnEditableContactChanged(Contact value)
    {
        if (_editableContactSubscriptionsTarget != null)
        {
            _editableContactSubscriptionsTarget.PropertyChanged -= EditableContactOnPropertyChanged;
            _editableContactSubscriptionsTarget.ErrorsChanged -= EditableContactOnErrorsChanged;
        }

        _editableContactSubscriptionsTarget = value;

        if (_editableContactSubscriptionsTarget != null)
        {
            _editableContactSubscriptionsTarget.PropertyChanged += EditableContactOnPropertyChanged;
            _editableContactSubscriptionsTarget.ErrorsChanged += EditableContactOnErrorsChanged;
        }

        ApplyCommand.NotifyCanExecuteChanged();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Сохраняет текущую коллекцию контактов в файл.
    /// </summary>
    public void SaveContacts()
    {
        try
        {
            _serializer.SaveContact(Contacts);
        }
        catch (Exception ex)
        {
            _messageService.FailureMessage(ex);
        }
    }

    #endregion

    #region Commands

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void Add()
    {
        if (IsAdding || IsEditing) return;

        SelectedContact = null;
        IsAdding = true;
        EditableContact = new Contact();

        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(PhoneNumber));
        OnPropertyChanged(nameof(Email));
    }

    private bool CanAdd() => !IsAdding && !IsEditing;

    [RelayCommand(CanExecute = nameof(CanRemove))]
    private void Remove()
    {
        if (IsAdding || IsEditing) return;

        var removedContact = SelectedContact;
        int index = Contacts.IndexOf(removedContact);
        Contacts.Remove(removedContact);
        SaveContacts();

        if (Contacts.Count == 0)
        {
            EditableContact = new Contact();
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(Email));
        }
        else if (index < Contacts.Count)
        {
            SelectedContact = Contacts[index];
        }
        else
        {
            SelectedContact = Contacts[Contacts.Count - 1];
        }
    }

    private bool CanRemove() => SelectedContact != null && !IsAdding && !IsEditing;

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private void Edit()
    {
        if (IsAdding || IsEditing) return;

        IsEditing = true;
        IsAdding = false;

        EditableContact = new Contact
        {
            Name = SelectedContact.Name,
            PhoneNumber = SelectedContact.PhoneNumber,
            Email = SelectedContact.Email
        };

        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(PhoneNumber));
        OnPropertyChanged(nameof(Email));
    }

    private bool CanEdit() => SelectedContact != null && !IsAdding && !IsEditing;

    [RelayCommand(CanExecute = nameof(CanApply))]
    private void Apply()
    {
        if (IsEditing)
        {
            SelectedContact.Name = EditableContact.Name;
            SelectedContact.PhoneNumber = EditableContact.PhoneNumber;
            SelectedContact.Email = EditableContact.Email;

            IsEditing = false;
            SaveContacts();
        }
        else if (IsAdding)
        {
            var newContact = EditableContact;
            Contacts.Add(newContact);
            IsAdding = false;
            SelectedContact = newContact;
            SaveContacts();
        }

        OnPropertyChanged(nameof(IsReadOnly));
        OnPropertyChanged(nameof(IsApplyVisible));
        RefreshCommandStates();
    }

    private bool CanApply() =>
        (IsEditing || IsAdding)
        && EditableContact != null
        && !EditableContact.HasErrors
        && AreFieldsClear();

    #endregion

    #region Private Methods (Helpers)

    /// <summary>
    /// Обработчик события изменения свойства редактируемого контакта.
    /// Уведомляет команду Apply о необходимости перепроверки возможности выполнения.
    /// </summary>
    private void EditableContactOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        ApplyCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Обработчик события изменения ошибок валидации редактируемого контакта.
    /// Уведомляет команду Apply о необходимости перепроверки возможности выполнения.
    /// </summary>
    private void EditableContactOnErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
    {
        ApplyCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Обновляет доступность команд
    /// </summary>
    private void RefreshCommandStates()
    {
        AddCommand.NotifyCanExecuteChanged();
        RemoveCommand.NotifyCanExecuteChanged();
        EditCommand.NotifyCanExecuteChanged();
        ApplyCommand.NotifyCanExecuteChanged();
    }


    /// <summary>
    /// Проверяет, что все обязательные поля редактируемого контакта заполнены.
    /// </summary>
    /// <remarks>
    /// Обеспечивает корректное состояние кнопки Apply, так как валидатор допускает пустые поля как валидные.
    /// </remarks>
    /// <returns>true, если все поля заполнены; иначе false.</returns>
    private bool AreFieldsClear()
    {
        return !string.IsNullOrWhiteSpace(EditableContact.Name)
            && !string.IsNullOrWhiteSpace(EditableContact.PhoneNumber)
            && !string.IsNullOrWhiteSpace(EditableContact.Email);
    }

    /// <summary>
    /// Отменяет текущее редактирование или добавление контакта.
    /// </summary>
    private void CancelEditing()
    {
        if (IsEditing)
        {
            IsEditing = false;

            if (_selectedContact != null)
            {
                EditableContact = new Contact
                {
                    Name = _selectedContact.Name,
                    PhoneNumber = _selectedContact.PhoneNumber,
                    Email = _selectedContact.Email
                };
            }
            else
            {
                EditableContact = new Contact();
                _selectedContact = null;
            }
        }
        else if (IsAdding)
        {
            IsAdding = false;

            if (_selectedContact != null)
            {
                EditableContact = _selectedContact;
            }
            else
            {
                EditableContact = new Contact();
            }
        }

        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(PhoneNumber));
        OnPropertyChanged(nameof(Email));
        RefreshCommandStates();
    }

    /// <summary>
    /// Фильтрует контакты по поисковому запросу, проверяя совпадение по имени.
    /// </summary>
    /// <param name="item">Контакт для проверки.</param>
    /// <returns>true, если имя контакта содержит поисковый запрос; иначе false.</returns>
    /// <remarks>Сравнение выполняется без учета регистра.</remarks>
    private bool FilteredContacts(object item)
    {
        var contact = item as Contact;
        return contact?.Name.Contains(SearchText ?? "", StringComparison.OrdinalIgnoreCase) == true;
    }

    #endregion
}