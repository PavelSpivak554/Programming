using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Rectangle
    {
        private double length;
        private double width;
        private string color;

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value < 0)
                {
                   throw new ArgumentException("Недопустимое значение");
                }
                length = value;
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
                if (value < 0 || value>length)
                {
                    throw new ArgumentException("Недопустимое значение");
                }
                width = value;
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
                if(!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                color = value;  
            }
        }
    }
}
