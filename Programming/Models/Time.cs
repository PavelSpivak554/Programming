using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time() { }
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 0 || value>23)
                {
                    throw new ArgumentException("Недопустимое значение");
                }
                hour = value;
            }
        }
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Недопустимое значение");
                }
                second = value;
            }
        }
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Недопустимое значение");
                }
                minute = value;
            }
        }
    }
}
