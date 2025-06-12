using Notes.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    /// <summary>
    /// Представляет заметку с заголовком, текстом, временем создания и категорией.
    /// </summary>
    internal class Note
    {
        private string _title;
        private string _text;
        private DateTime _lastEditTime;

        /// <summary>
        /// Получает или задает заголовок заметки.
        /// </summary>
        /// <value>
        /// Заголовок заметки. Не может быть пустым или превышать 100 символов.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если заголовок пустой или превышает 100 символов.
        /// </exception>
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым");
                if (value.Length > 100)
                    throw new ArgumentException("Название не может превышать 100 символов");

                _title = value;
                UpdateLastEditTime(); // Обновляем время редактирования
            }
        }

        /// <summary>
        /// Получает или задает текст заметки.
        /// </summary>
        /// <value>
        /// Текст заметки. При установке значения обновляется время последнего редактирования.
        /// </value>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                UpdateLastEditTime(); // Обновляем время редактирования
            }
        }

        /// <summary>
        /// Получает время создания заметки.
        /// </summary>
        /// <value>
        /// Время создания заметки. Доступно только для чтения.
        /// </value>
        public DateTime CreationTime { get; }

        /// <summary>
        /// Получает время последнего редактирования заметки.
        /// </summary>
        /// <value>
        /// Время последнего изменения заголовка или текста заметки.
        /// </value>
        public DateTime LastEditTime => _lastEditTime;

        /// <summary>
        /// Получает или задает категорию заметки.
        /// </summary>
        /// <value>
        /// Категория заметки, определяемая перечислением <see cref="KindOfNote"/>.
        /// </value>
        public KindOfNote Kind { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Note"/> с указанными параметрами.
        /// </summary>
        /// <param name="title">Заголовок заметки.</param>
        /// <param name="text">Текст заметки.</param>
        /// <param name="kind">Категория заметки.</param>
        /// <param name="time">Время создания заметки.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если заголовок не соответствует требованиям.
        /// </exception>
        public Note(string title, string text, KindOfNote kind, DateTime time)
        {
            CreationTime = DateTime.Now;
            _lastEditTime = CreationTime;
            Title = title;
            Text = text;
            Kind = kind;
        }

        /// <summary>
        /// Обновляет время последнего редактирования заметки текущим временем.
        /// </summary>
        private void UpdateLastEditTime()
        {
            _lastEditTime = DateTime.Now;
        }

        /// <summary>
        /// Сравнивает текущую заметку с другой заметкой для сортировки по времени последнего редактирования.
        /// </summary>
        /// <param name="other">Заметка для сравнения.</param>
        /// <returns>
        /// Целое число, которое указывает на относительный порядок сравниваемых объектов.
        /// Возвращает 1, если other равен null. В противном случае возвращает результат сравнения времени редактирования.
        /// </returns>
        public int CompareTo(Note other)
        {
            if (other == null) return 1;
            return other.LastEditTime.CompareTo(LastEditTime); // Сортировка по убыванию
        }

        /// <summary>
        /// Возвращает строковое представление заметки (ее заголовок).
        /// </summary>
        /// <returns>Заголовок заметки.</returns>
        public override string ToString()
        {
            return Title;
        }
    }
}