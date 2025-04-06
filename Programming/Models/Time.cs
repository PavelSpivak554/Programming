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
                if (Validator.AssertValueInRange(value, 0, 23, nameof(Hour)))
                {
                    hour = value;
                }
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
                if(Validator.AssertValueInRange(value,0, 59,nameof(Second)))
                {
                    second = value;
                }
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
                if (Validator.AssertValueInRange(value, 0, 59, nameof(Minute)))
                {
                    minute = value;
                }
            }
        }
    }
}
