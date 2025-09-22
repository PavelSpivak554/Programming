using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет прямоугольник с заданными длиной, шириной, цветом и центром.
    /// </summary>
    internal class Rectangle
    {
        /// <summary>
        /// Длина прямоугольника.
        /// </summary>
        private double length;

        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        private double width;

        /// <summary>
        /// Цвет прямоугольника.
        /// </summary>
        private string color;

        /// <summary>
        /// Общее количество созданных прямоугольников.
        /// </summary>
        private static int _allRectanglesCount;

        /// <summary>
        /// Уникальный идентификатор прямоугольника.
        /// </summary>
        private int id;

        /// <summary>
        /// Центр прямоугольника.
        /// </summary>
        public Point2D Center { get; private set; }

        /// <summary>
        /// Возвращает идентификатор прямоугольника.
        /// </summary>
        public int Id => id;

        /// <summary>
        /// Создает экземпляр класса <see cref="Rectangle"/> со значениями по умолчанию.
        /// </summary>
        public Rectangle()
        {
            length = 0;
            width = 0;
            color = "Unknown";
            Center = new Point2D(0, 0);
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Rectangle"/> с заданными параметрами.
        /// </summary>
        /// <param name="length">Длина прямоугольника.</param>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="color">Цвет прямоугольника.</param>
        /// <param name="center">Центр прямоугольника.</param>
        public Rectangle(double length, double width, string color, Point2D center)
        {
            Length = length;
            Width = width;
            Color = color;
            Center = center;
            _allRectanglesCount++;
            id = _allRectanglesCount;
        }

        /// <summary>
        /// Возвращает или задает длину прямоугольника.
        /// </summary>
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(Length)))
                {
                    length = value;
                }
            }
        }

        /// <summary>
        /// Возвращает или задает ширину прямоугольника.
        /// </summary>
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(Width)))
                {
                    width = value;
                }
            }
        }

        /// <summary>
        /// Возвращает или задает цвет прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение цвета пустое или состоит из пробелов.</exception>
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                color = value;
            }
        }

        /// <summary>
        /// Возвращает общее количество созданных прямоугольников.
        /// </summary>
        /// <returns>Количество прямоугольников.</returns>
        public int AllRectanglesCount()
        {
            return _allRectanglesCount;
        }
    }
}