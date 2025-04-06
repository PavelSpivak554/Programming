using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    public static class Validator
    {
        public static bool AssertStringContainsOnlyLetters(string value, string NameOfProperty)
        {
            if (value.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                return true;
            }
            throw new ArgumentException($"Некоректное значение в свойстве {NameOfProperty}");
        }

        public static bool AssertOnPositiveValue(int value, string NameOfProperty)
        {
            if (value > 0)
            {
                return true;
            }
            throw new ArgumentException($"Отрицательное значение в свойстве {NameOfProperty}");
        }
        public static bool AssertOnPositiveValue(double value, string NameOfProperty)
        {
            if (value > 0)
            {
                return true;
            }
            throw new ArgumentException($"Отрицательное значение в свойстве {NameOfProperty}");
        }

        public static bool AssertValueInRange(int value, int min, int max, string NameOfProperty)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"Значение выходит за допустимые рамки в свойстве {NameOfProperty}");
            }
            return true;
        }
        public static bool AssertValueInRange(double value, double min, double max, string NameOfProperty)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentException($"Значение выходит за допустимые рамки в свойстве {NameOfProperty}");
            }
            return true;
        }

        public static bool AssertValueMore(int value, int minValue, string NameOfProperty)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }
        public static bool AssertValueMore(double value, double minValue, string NameOfProperty)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }
        public static bool AssertValueLow(double value, double minValue, string NameOfProperty)
        {
            if (value > minValue)
            {
                throw new ArgumentException($"недопустимое значние в свойстве {NameOfProperty}");
            }
            return true;
        }
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

