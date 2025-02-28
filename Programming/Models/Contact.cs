using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Contact
    {
        private string name;
        private string surname;
        private string number;
        public Contact() { }  
        public Contact(string name, string surname, string number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                name = value;
            }

        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                name = value;
            }
        
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) || value.Length!=11)
                {
                    throw new ArgumentException($"Невозмозможное значение номера телефона");
                }
                number = value;
            }
        }
    }
}