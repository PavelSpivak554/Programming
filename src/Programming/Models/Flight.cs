using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет информацию о рейсе
    /// </summary>
    internal class Flight
    {
        /// <summary>
        /// Пункт отправления
        /// </summary>
        private string departure;

        /// <summary>
        /// Пункт назначения
        /// </summary>
        private string destination;

        /// <summary>
        /// Длительность полета в минутах
        /// </summary>
        private int duration;

        /// <summary>
        /// Создает экземпляр класса Flight с пустыми значениями
        /// </summary>
        public Flight() { }

        /// <summary>
        /// Создает экземпляр класса Flight с заданными параметрами
        /// </summary>
        /// <param name="departure">Пункт отправления</param>
        /// <param name="destination">Пункт назначения</param>
        /// <param name="duration">Длительность полета в минутах</param>
        public Flight(string departure, string destination, int duration)
        {
            Departure = departure;
            Destination = destination;
            Duration = duration;
        }

        /// <summary>
        /// Пункт отправления (не может быть пустым)
        /// </summary>
        public string Departure
        {
            get
            {
                return departure;
            }
            set
            {
                if (string.IsNullOrEmpty(value))  
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                departure = value;
            }
        }

        /// <summary>
        /// Пункт назначения (не может быть пустым)
        /// </summary>
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                destination = value;
            }
        }

        /// <summary>
        /// Длительность полета в минутах (должна быть положительной)
        /// </summary>
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(Duration)))
                {
                    duration = value;
                }
            }
        }
    }
}