using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    internal class ValueValidator
    {
        /// <summary>
        /// Проверка строки на наличие недопустимых символов
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="NameOfProperty"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertStringContainsOnlyLetters(string value, string propertyName)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    throw new ArgumentException($"В свойстве {propertyName} можно использовать только буквы");
                }
            }

        }
        /// <summary>
        /// Проверка строки на длину(превышaет ли она максимальное значение)
        /// </summary>
        /// <param name="value">название предмета для валидации</param>
        /// <param name="maxLength">максимальная длинна</param>
        /// <param name="propertyName">возврат свойства</param>
        /// <exception cref="ArgumentException"></exception>
        internal static void AssertStringOnLength(string value, int maxLength, string propertyName)
        {

            if (value != null && value.Length > maxLength)
            {
                throw new ArgumentException($"{propertyName} должен быть меньше {maxLength} символов. " +
                    $"Текущая длина: {value.Length} символов");
            }
        }

        /// <summary>
        /// Попадает ли вещественное значение в диапазон.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="min">Начало.</param>
        /// <param name="max">Конец.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueInRange(double value, double min, double max, string propertyName)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"{propertyName} должен быть меньше {max} или больше {min}");
            }
            return true;
        }




    }

}
