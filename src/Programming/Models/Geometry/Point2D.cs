using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Хранит точку в пространстве
    /// </summary>
    internal class Point2D
    {
        
        public int X { get; private set; }
        public int Y { get; private set; }
        /// <summary>
        /// Создает экземпляр класса
        /// </summary>
        public Point2D()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// Создает экземпляр класса на определенном промежутке
        /// </summary>
        /// <param name="x">Значение по х</param>
        /// <param name="y">Значение по у</param>
        public Point2D(int x, int y)
        {
            Validator.AssertValueInRange(x, 0, 500, nameof(X));
            Validator.AssertValueInRange(y, 0, 500, nameof(Y));

            X = x;
            Y = y;
        }       

    }
}
