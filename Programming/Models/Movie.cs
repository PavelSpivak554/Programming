using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет фильм с названием, продолжительностью, годом выпуска, жанром и рейтингом
    /// </summary>
    internal class Movie
    {
        /// <summary>
        /// Название фильма
        /// </summary>
        private string nameOfMovie;

        /// <summary>
        /// Продолжительность фильма в минутах
        /// </summary>
        private int duration;

        /// <summary>
        /// Год выпуска фильма
        /// </summary>
        private int year;

        /// <summary>
        /// Жанр фильма
        /// </summary>
        private string genre;

        /// <summary>
        /// Рейтинг фильма (от 0 до 10)
        /// </summary>
        private double rating;

        /// <summary>
        /// Создает экземпляр класса Movie с пустыми значениями
        /// </summary>
        public Movie() { }

        /// <summary>
        /// Создает экземпляр класса Movie с заданными параметрами
        /// </summary>
        /// <param name="nameOfMovie">Название фильма</param>
        /// <param name="duration">Продолжительность в минутах</param>
        /// <param name="year">Год выпуска</param>
        /// <param name="genre">Жанр фильма</param>
        /// <param name="rating">Рейтинг (от 0 до 10)</param>
        public Movie(string nameOfMovie, int duration, int year, string genre, double rating)
        {
            NameOfMovie = nameOfMovie;
            Duration = duration;
            Year = year;
            Genre = genre;
            Rating = rating;
        }

        /// <summary>
        /// Название фильма (не может быть пустым)
        /// </summary>
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

        /// <summary>
        /// Продолжительность фильма в минутах (должна быть положительной)
        /// </summary>
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

        /// <summary>
        /// Год выпуска фильма (должен быть положительным)
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(Year)))
                {
                    year = value;
                }
            }
        }

        /// <summary>
        /// Жанр фильма (не может быть пустым)
        /// </summary>
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

        /// <summary>
        /// Рейтинг фильма (от 0 до 10)
        /// </summary>
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