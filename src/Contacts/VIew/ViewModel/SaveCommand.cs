using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIew.Model;

namespace View.ViewModel
{
    /// <summary>
    /// Команда для сохранения контакта.
    /// </summary>
    class SaveCommand : ICommand
    {
        /// <summary>
        /// Приватное поле для хранения действия, которое нужно выполнить при сохранении
        /// </summary>
        private readonly Action<Contact> _saveAction;

        /// <summary>
        /// Создает новую команду сохранения.
        /// </summary>
        public SaveCommand(Action<Contact> saveAction)
        {
            _saveAction = saveAction;
        }
        /// <summary>
        /// Определяет, может ли выполнить команду сейчас. Кнопка всегда доступна
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;    
        }
        /// <summary>
        /// Выполняет сохранение контакта.
        /// </summary>
        public void Execute(object parameter)
        {
            if (parameter is Contact contact)
            {
                _saveAction(contact);
            }
        }
        /// <summary>
        /// Событие которое возникает при изменении возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
