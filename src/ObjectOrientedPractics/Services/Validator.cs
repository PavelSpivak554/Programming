using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    public static class Validator

    /// <summary>
    /// Проверка определённых случаев.
    /// </summary>
    {
         
        /// <summary>
        /// Проверка строки на наличие недопустимых символов (допустимы только буквы английского алфавита)
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="NameOfProperty"></param>
        /// <returns>true при успехе</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool AssertStringContainsOnlyLetters(string value, string NameOfProperty)
        {
            if (value.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                return true;
            }
            throw new ArgumentException($"Некоректное значение в свойстве {NameOfProperty}");
        }
        /// <summary>
        /// Проверка строки на длину( превышвет ли она максимальное значение)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="propertyName"></param>
        /// <returns>true при успехе</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool AssertStringOnLength(string value,int maxLength, string propertyName)
        {
            if (value.All(c => (c > maxLength)))
            {
                return true;
            }
            throw new ArgumentException($"Некоректное значение в свойстве {propertyName}");
        }


        /// <summary>
        /// Проверка на положительное целочисленного значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertOnPositiveValue(int value, string NameOfProperty)
        {
            if (value > 0)
            {
                return true;
            }
            throw new ArgumentException($"Отрицательное значение в свойстве {NameOfProperty}");
        }

        /// <summary>
        /// Проверка на положительное вещественное значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertOnPositiveValue(double value, string NameOfProperty)
        {
            if (value > 0)
            {
                return true;
            }
            throw new ArgumentException($"Отрицательное значение в свойстве {NameOfProperty}");
        }


        /// <summary>
        /// Попадает ли целочисленное значение в диапазон.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="min">Начало.</param>
        /// <param name="max">Конец.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueInRange(int value, int min, int max, string NameOfProperty)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"Значение выходит за допустимые рамки в свойстве {NameOfProperty}");
            }
            return true;
        }

        /// <summary>
        /// Попадает ли вещественное значение в диапазон.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="min">Начало.</param>
        /// <param name="max">Конец.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueInRange(double value, double min, double max, string NameOfProperty)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"Значение выходит за допустимые рамки в свойстве {NameOfProperty}");
            }
            return true;
        }



        /// <summary>
        /// Является ли одно значение больше другого.
        /// </summary>
        /// <param name="value">Первое значение.</param>
        /// <param name="minValue">Второе значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueMore(int value, int minValue, string NameOfProperty)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }

        /// <summary>
        /// Является ли одно значение больше другого.
        /// </summary>
        /// <param name="value">Первое значение.</param>
        /// <param name="minValue">Второе значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueMore(double value, double minValue, string NameOfProperty)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }


        /// <summary>
        /// Является ли одно значение меньше другого.
        /// </summary>
        /// <param name="value">Первое значение.</param>
        /// <param name="minValue">Второе значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueLow(double value, double minValue, string NameOfProperty)
        {
            if (value > minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }
        /// <summary>
        /// Является ли одно значение меньше другого.
        /// </summary>
        /// <param name="value">Первое значение.</param>
        /// <param name="minValue">Второе значение.</param>
        /// <param name="NameOfProperty">Свойство передаваемого значения.</param>
        public static bool AssertValueLow(int value, int minValue, string NameOfProperty)
        {
            if (value > minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }
    }


}

