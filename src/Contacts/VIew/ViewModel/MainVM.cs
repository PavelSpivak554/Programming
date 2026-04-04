using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using View.Model;
using View.Model.Services;
using View.ViewModel.Services;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel для главного окна приложения.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле коллекции контактов, хранящее актуальные данные.
        /// </summary>
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Поле хранящее текущий контакт
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Редактируемый контакт для временного хранения
        /// </summary>
        private Contact _editableContact;

        /// <summary>
        /// Флаг для режима добавления
        /// </summary>
        private bool _isAdding;

        /// <summary>
        /// Флаг для режима добавления
        /// </summary>
        private bool _isEditing;

        /// <summary>
        /// Поле для сериализатора
        /// </summary>
        private readonly ContactSerializer _serializer;

        /// <summary>
        /// Поле для интерфейса сообщений
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        /// Свойство для команды сохранения
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Свойство для команды загрузки
        /// </summary>
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Свойство для команды добавления
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// Свойство для команды удаления
        /// </summary>
        public ICommand RemoveCommand { get; }

        /// <summary>
        /// Свойство для команды изменения
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Свойство для команды применения
        /// </summary>
        public ICommand ApplyCommand { get; }

        /// <summary>
        /// Событие для уведомления об изменениях свойств.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор по умолчанию.
        /// Инициализирует сериализатор, создает тестовый контакт и команду сохранения.
        /// </summary>
        public MainVM(IMessageService messageService)
        {
            _contacts = new ObservableCollection<Contact>();
            _serializer = new ContactSerializer();
            _messageService = messageService;
            _editableContact = new Contact();
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
            SaveCommand = new RelayCommand(
                _ =>
            {
                try
                {
                    _serializer.SaveContact(_contacts);
                }
                catch (Exception ex)
                {
                    _messageService.FailureMessage(ex);
                }
            });

            LoadCommand = new RelayCommand(
                _ =>
            {
                try
                {
                    _contacts.Clear();
                    var loadedContacts = _serializer.LoadContact();
                    foreach (var c in loadedContacts)
                        _contacts.Add(c);
                }
                catch (Exception ex)
                {
                    _messageService.FailureMessage(ex);
                }
            });

            AddCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;

                    SelectedContact = null;
                    IsAdding = true;
                    EditableContact = new Contact();
                    

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));

                },
                canExecute: _ =>
                {
                    return !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });

            RemoveCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;

                    var removedContact = SelectedContact;
                    int index = _contacts.IndexOf(removedContact);
                    _contacts.Remove(removedContact);
                    SaveContacts();

                    if (_contacts.Count == 0)
                    {
                        EditableContact = new Contact();

                        OnPropertyChanged(nameof(Name));
                        OnPropertyChanged(nameof(PhoneNumber));
                        OnPropertyChanged(nameof(Email));
                        
                    }
                    else if (index < _contacts.Count)
                    {
                        SelectedContact = _contacts[index];
                    }
                    else
                    {
                        SelectedContact = _contacts[_contacts.Count - 1];
                    }
                },
                canExecute: _ =>
                {
                    return SelectedContact != null && !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });

            EditCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;
                    IsEditing = true;
                    IsAdding = false;

                    EditableContact = new Contact()
                    {
                        Name = SelectedContact.Name,
                        PhoneNumber = SelectedContact.PhoneNumber,
                        Email = SelectedContact.Email
                    };

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                },
                canExecute: _ =>
                {
                    return SelectedContact != null &&   !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });

            ApplyCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isEditing)
                    {
                        SelectedContact.Name = EditableContact.Name;
                        SelectedContact.PhoneNumber = EditableContact.PhoneNumber;
                        SelectedContact.Email = EditableContact.Email;

                        IsEditing = false;
                        SaveContacts();
                    }
                    else if (_isAdding)
                    {
                        var newContact = EditableContact;
                        _contacts.Add(newContact);
                        IsAdding = false;
                        SelectedContact = newContact;
                        SaveContacts();
                    }
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                    
                },
                canExecute: _ => (_isEditing || _isAdding) && EditableContact != null);

        }


        /// <summary>
        /// Свойство для доступа к имени
        /// </summary>
        public string Name
        {
            get { return _editableContact.Name; }
            set
            {
                if (_editableContact.Name != value)
                {
                    _editableContact.Name = value;
                    OnPropertyChanged();
                }
            }
        }

       /// <summary>
       /// Свойство для доступа к номеру телефона
       /// </summary>
        public string PhoneNumber
        {
            get { return _editableContact.PhoneNumber; }
            set
            {
                if (_editableContact.PhoneNumber != value)
                {
                    _editableContact.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к почте
        /// </summary>
        public string Email
        {
            get { return _editableContact.Email; }
            set
            {
                if (_editableContact.Email != value)
                {
                    _editableContact.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к коллекции контактов
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Метод для вызова события PropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Свойство для доступа к текущему контакту
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact == value) return;
                if (_isEditing || _isAdding)
                {
                    CancelEditing();
                }

                _selectedContact = value;
                if (value != null && !_isAdding && !_isEditing)
                {
                    EditableContact = new Contact
                    {
                        Name = value.Name,
                        PhoneNumber = value.PhoneNumber,
                        Email = value.Email
                    };
                    //OnPropertyChanged(nameof(Name));
                    //OnPropertyChanged(nameof(PhoneNumber));
                    //OnPropertyChanged(nameof(Email));
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство для доступа к изменяемому контакту
        /// </summary>
        public Contact EditableContact
        {
            get => _editableContact;
            set
            {
                if (_editableContact == value) return;
                _editableContact = value;

                if (value != null)
                {
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Метод отмены изменений
        /// </summary>
        private void CancelEditing()
        {
            if (_isEditing)
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
            else if (_isAdding)
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
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Свойство для доступа к флагу доступа кнопок только на чтение
        /// </summary>
        public bool IsReadOnly => !_isAdding && !_isEditing;

        /// <summary>
        /// Свойство для доступа к флагу видимости кнопки Apply
        /// </summary>
        public bool IsApplyVisible => _isAdding || _isEditing;

        /// <summary>
        /// Свойство для доступа к флагу добавления контакта
        /// </summary>
        public bool IsAdding
        {
            get => _isAdding;
            set
            {
                if (_isAdding != value)
                {
                    _isAdding = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к флагу изменения контакта
        /// </summary>
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Метод сохранения контактов (автосохранение в файл)
        /// </summary>
        public void SaveContacts()
        {
            try
            {
                _serializer.SaveContact(_contacts);
            }
            catch (Exception ex)
            {
                _messageService.FailureMessage(ex);
            }
        }
    }
}
    
