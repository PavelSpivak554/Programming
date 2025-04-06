using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Movie
    {
        private string nameOfMovie;
        private int duration;
        private int year;
        private string genre;
        private double rating;

        public Movie() { }
        public Movie(string nameOfMovie, int duration, int year, string genre, double rating)
        {
            NameOfMovie = nameOfMovie;
            Duration = duration;
            Year = year;
            Genre = genre;
            Rating = rating;
        }

        public string NameOfMovie
        {
            get
            {
                return nameOfMovie;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                nameOfMovie = value;
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
                if (Validator.AssertOnPositiveValue(value, nameof(Duration)))
                {
                    duration = value;
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value,nameof(Year)))
                {
                    year = value;
                }
            }
        }
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                genre = value;
            }
        }
        public double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (Validator.AssertValueInRange(value, 0, 10, nameof(Rating)))
                {
                    rating = value;
                }
            }
        }

    }
}