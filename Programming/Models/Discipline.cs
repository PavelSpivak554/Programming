using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Discipline
    {
        private string studentName;
        private string lectorName;
        private int mark;

        public Discipline() { }
        public Discipline(string studentName, string lectorName, int mark)
        {
            StudentName = studentName;
            LectorName = lectorName;
            Mark = mark;
        }

        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                studentName = value;
            }
        }
        public string LectorName
        {
            get
            {
                return lectorName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                lectorName = value;
            }

        }
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if(Validator.AssertValueInRange(value, 1,5,nameof(Mark)))
                {
                    mark = value;
                }
            }
        }
    }
}
