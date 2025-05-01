using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming.Models
{
    /// <summary>
    /// Фабрика для создания случайных прямоугольников.
    /// </summary>
    static class RectangleFactory
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private static Random Random = new Random();

        /// <summary>
        /// Создает случайный прямоугольник с заданными границами.
        /// </summary>
        /// <param name="Padding">Отступ от границ панели.</param>
        /// <param name="panel">Панель, в пределах которой создается прямоугольник.</param>
        /// <returns>Случайно сгенерированный прямоугольник.</returns>
        public static Rectangle Randomize(int Padding, Panel panel)
        {
            int width = Random.Next(10, 350);
            int height = Random.Next(10, 350);

            int x = Random.Next(Padding, panel.Width - width - Padding);
            int y = Random.Next(Padding, panel.Height - height - Padding);

            return new Rectangle(width, height, "red", new Point2D(x + width / 2, y + height / 2));
        }
    }
}