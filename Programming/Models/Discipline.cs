using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет учебную дисциплину с информацией о студенте, преподавателе и оценке
    /// </summary>
    internal class Discipline
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        private string studentName;

        /// <summary>
        /// Имя преподавателя
        /// </summary>
        private string lectorName;

        /// <summary>
        /// Оценка по дисциплине
        /// </summary>
        private int mark;

        /// <summary>
        /// Создает экземпляр класса <see cref="Discipline"/> с пустыми значениями
        /// </summary>
        public Discipline() { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Discipline"/> с заданными параметрами
        /// </summary>
        /// <param name="studentName">Имя студента</param>
        /// <param name="lectorName">Имя преподавателя</param>
        /// <param name="mark">Оценка по дисциплине (от 1 до 5)</param>
        public Discipline(string studentName, string lectorName, int mark)
        {
            StudentName = studentName;
            LectorName = lectorName;
            Mark = mark;
        }

        /// <summary>
        /// Возвращает или задает имя студента
        /// </summary>

        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))  
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                studentName = value;
            }
        }

        /// <summary>
        /// Возвращает или задает имя преподавателя
        /// </summary>

        public string LectorName
        {
            get
            {
                return lectorName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))  
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                lectorName = value;
            }
        }

        /// <summary>
        /// Возвращает или задает оценку по дисциплине
        /// </summary>
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 1, 5, nameof(Mark)))
                {
                    mark = value;
                }
            }
        }
    }
}