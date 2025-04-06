using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Rectangle
    {
        private double length;
        private double width;
        private string color;
        private static int _allRectanglesCount;
        private int id;
        public Point2D Center { get; private set; }
        public int Id => id; // Свойство только для чтения

        public Rectangle()
        {
            length = 0;
            width = 0;
            color = "Unknown";
            Center = new Point2D(0, 0);
        }
        // Конструктор (инициализация объекта)

        public Rectangle(double length, double width, string color, Point2D center)
        {
            Length = length;
            Width = width;
            Color = color;
            Center = center;
            _allRectanglesCount++;
            id = _allRectanglesCount;
        }
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
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                color = value;  
            }
        }
        public int AllRectanglesCount()
        {
            return _allRectanglesCount;
        }
    }
}
