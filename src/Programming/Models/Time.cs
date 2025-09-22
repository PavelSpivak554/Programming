using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет время с точностью до секунды
    /// </summary>
    internal class Time
    {
        /// <summary>
        /// Часы (0-23)
        /// </summary>
        private int hour;

        /// <summary>
        /// Минуты (0-59)
        /// </summary>
        private int minute;

        /// <summary>
        /// Секунды (0-59)
        /// </summary>
        private int second;

        /// <summary>
        /// Создает экземпляр времени с нулевыми значениями
        /// </summary>
        public Time() { }

        /// <summary>
        /// Создает экземпляр времени с заданными значениями
        /// </summary>
        /// <param name="hour">Часы (0-23)</param>
        /// <param name="minute">Минуты (0-59)</param>
        /// <param name="second">Секунды (0-59)</param>
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// Часы (допустимый диапазон: 0-23)
        /// </summary>
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 0, 23, nameof(Hour)))
                {
                    hour = value;
                }
            }
        }

        /// <summary>
        /// Секунды (допустимый диапазон: 0-59)
        /// </summary>
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 0, 59, nameof(Second)))
                {
                    second = value;
                }
            }
        }

        /// <summary>
        /// Минуты (допустимый диапазон: 0-59)
        /// </summary>
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 0, 59, nameof(Minute)))
                {
                    minute = value;
                }
            }
        }
    }
}