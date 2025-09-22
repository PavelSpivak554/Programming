using Programming.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming.Views.UserControls
{
    public partial class MoviesControl : UserControl
    {
        public MoviesControl()
        {
            InitializeComponent();
        }
        private Models.Movie[] _movies;
        private Models.Movie _currentMovie;
        /// <summary>
        /// Создание фильмов при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMovieButton_Click(object sender, EventArgs e)
        {
            _movies = new Models.Movie[5];
            Random random = new Random();
            for (int i = 0; i < _movies.Length; i++)
            {
                int year = random.Next(1950, 2025); // Случайная длина
                int duration = random.Next(10, 200);  // Случайная ширина
                string name = "Name" + i;       // Пример цвета
                string genre = "Неизвестен";
                double rating = random.Next(1, 10);
                _movies[i] = new Models.Movie(name, duration, year, genre, rating);
            }
            _currentMovie = _movies[0];
            MovieNameTextBox.BackColor = System.Drawing.Color.White;
            MovieDurationTextBox.BackColor = System.Drawing.Color.White;
            MovieYearTextBox.BackColor = System.Drawing.Color.White;
            MovieGenreTextBox.BackColor = System.Drawing.Color.White;
            MovieRatingTextBox.BackColor = System.Drawing.Color.White;
        }
        /// <summary>
        /// Изменение текста
        /// </summary>
        /// <param name="i"></param>
        private void MovieTextChange(int i)
        {
            var Year = _movies[i].Year;
            var duration = _movies[i].Duration;
            var Name = _movies[i].NameOfMovie;
            var genre = _movies[i].Genre;
            var Rating = _movies[i].Rating;


            // Обновляем текстовые поля значениями ширины, высоты и цвета

            MovieNameTextBox.Text = Name.ToString();
            MovieDurationTextBox.Text = Name.ToString();
            MovieYearTextBox.Text = Year.ToString();
            MovieGenreTextBox.Text = "Неизвестен";
            MovieRatingTextBox.Text = Rating.ToString();
        }
        /// <summary>
        /// Вызов метода изменения текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovieTextChange(MovieListBox.SelectedIndex);
        }
        /// <summary>
        /// Найти фильм с максимальным рейтингом.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        int FindMovieWithMaxRating(Models.Movie[] movie)
        {
            int maxRating = 0;
            int maxIndex = 0;
            for (int i = 0; i < movie.Length; i++)
            {
                if (movie[i].Rating > maxRating)
                {
                    maxRating = (int)movie[i].Rating;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        /// <summary>
        /// Вызов метода по нахождению самого рейтингового.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindMovieButton_Click(object sender, EventArgs e)
        {
            int index = FindMovieWithMaxRating(_movies);
            MovieListBox.SelectedIndex = index;
        }
    }
}
