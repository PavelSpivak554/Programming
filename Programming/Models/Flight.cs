using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Flight
    {
        private string departure;
        private string destination;
        private int duration;

        public Flight() { }
        public Flight(string departure, string destination, int duration)
        {
            Departure = departure;
            Destination = destination;
            Duration = duration;
        }

        public string Departure
        {
            get
            {
                return departure;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                departure = value;
            }
        }
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                destination = value;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {

               if( Validator.AssertOnPositiveValue(value,nameof(Duration)))
               {
                   duration = value;
               }

            }
        }
    }
}
