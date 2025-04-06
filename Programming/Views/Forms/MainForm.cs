using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programming.Models;
using Programming.Models.Enums;
using static Programming.Models.Rectangle;

namespace Programming.Views.Forms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            WidthTextBox.Enter += TextBox_Enter;
            LengthTextBox.Enter += TextBox_Enter;
            ColorTextBox.Enter += TextBox_Enter;

            WidthTextBox.Leave += TextBox_Leave;
            LengthTextBox.Leave += TextBox_Leave;
            ColorTextBox.Leave += TextBox_Leave;
        }
        private Models.Rectangle[] _rectangles;
        private Models.Rectangle _currentRectangle;
        bool _isUserInput = false;

        private Models.Movie[] _movies;
        private Models.Movie _currentMovie;



        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isUserInput = true; // Пользователь начал ввод
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isUserInput = false; // Пользователь завершил ввод
        }
        private void EnumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ListBox).SelectedIndex)
            {
                case 0:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Models.Enums.Color));
                    break;
                case 1:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Education));
                    break;
                case 2:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Genre));
                    break;
                case 3:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Season));
                    break;
                case 4:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(SmartManufacturers));
                    break;
                case 5:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Weekday));
                    break;
            }
        }

        private void ValuesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ValueTextBox.Text = Convert.ToInt32(ValuesListBox.SelectedValue).ToString();

        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            string input = ParsingTextBox.Text;
            if (Enum.TryParse<Weekday>(input, true, out Weekday weekday))
            {
                ParsingTextBox2.Text = $"Это день недели {weekday} = {(int)weekday}";
            }
            else
            {
                ParsingTextBox2.Text = "Нет такого дня недели";

            }
        }

        private void SeasonButton_Click(object sender, EventArgs e)
        {
            switch (SeasonComboBox.SelectedItem)
            {
                case "Winter":
                    MessageBox.Show("Бррр! Холодно!", "Зима", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case "Spring":
                    this.tabPage1.BackColor = System.Drawing.Color.Green;
                    MessageBox.Show("Все зеленое!", "Весна", MessageBoxButtons.YesNo);
                    break;
                case "Summer":
                    MessageBox.Show("Ура! Солнце!", "Лето", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "Autumn":
                    this.tabPage1.BackColor = System.Drawing.Color.Orange;
                    MessageBox.Show("Листья Падают", "Осень");
                    break;

            }
        }

        private void CreateRectangleButton_Click(object sender, EventArgs e)
        {
            _rectangles = new Models.Rectangle[5];
            Random random = new Random();
            for (int i = 0; i < _rectangles.Length; i++)
            {
                int length = random.Next(1, 100); // Случайная длина
                int width = random.Next(1, 100);  // Случайная ширина
                string color = "Color" + i;       // Пример цвета
                var center = new Point2D(length / 2, width/2);
                var id = 0;
                _rectangles[i] = new Models.Rectangle(length, width, color,center);
            }
            _currentRectangle = _rectangles[0];
            WidthTextBox.BackColor = System.Drawing.Color.White;
            LengthTextBox.BackColor = System.Drawing.Color.White;
            ColorTextBox.BackColor = System.Drawing.Color.White;
                
        }

        private void RectangleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RectangleTextChange(RectangleListBox.SelectedIndex);
        }
        private void RectangleTextChange(int i)
        {
            var Width = _rectangles[i].Width;
            var Length = _rectangles[i].Length;
            var Color = _rectangles[i].Color;
            var CenterX = _rectangles[i].Length / 2;
            var CenterY = _rectangles[i].Width / 2;
            var Id = _rectangles[i].Id;

            // Обновляем текстовые поля значениями ширины, высоты и цвета
            WidthTextBox.Text = Width.ToString();
            LengthTextBox.Text = Length.ToString();
            ColorTextBox.Text = Color.ToString();
            CenterXtextBox.Text = CenterX.ToString();
            CenterYtextBox.Text = CenterY.ToString();
            IDTextBox.Text = Id.ToString();
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Length = 0;
            try
            {
                if (Int32.TryParse(LengthTextBox.Text, out Length))
                {
                    var rect = _rectangles[RectangleListBox.SelectedIndex];
                    rect.Length = Length;
                }
                else
                {
                    MessageBox.Show("Недопустимое значение:");
                    LengthTextBox.BackColor = System.Drawing.Color.Red;
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Недопустимое значение:");
                LengthTextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Width = 0;
            try
            {
                if (Int32.TryParse(WidthTextBox.Text, out Width))
                {
                    var rect = _rectangles[RectangleListBox.SelectedIndex];
                    rect.Width = Width;
                }
                else
                {
                    MessageBox.Show("Недопустимое значение:");
                    WidthTextBox.BackColor = System.Drawing.Color.Red;
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Недопустимое значение:");
                WidthTextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            var Color = ColorTextBox.Text;
            var rect = _rectangles[RectangleListBox.SelectedIndex];
            rect.Color = Color;
        }

        int FindRectangleWithMaxWidth(Models.Rectangle[] rectangle)
        {
            double maxWidth = 0;
            int maxIndex = 0;
            for (int i = 0; i < rectangle.Length; i++)
            {
                if (rectangle[i].Width > maxWidth)
                {
                    maxWidth = rectangle[i].Width;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            int index = FindRectangleWithMaxWidth(_rectangles);
            RectangleListBox.SelectedIndex = index;
        }

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

        private void MovieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovieTextChange(MovieListBox.SelectedIndex);
        }

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

        private void FindMovieButton_Click(object sender, EventArgs e)
        {
            int index = FindMovieWithMaxRating(_movies);
            MovieListBox.SelectedIndex = index;
        }

        private void MovieYearTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IntersectionButton_Click(object sender, EventArgs e)
        {
            // Проверка первого числа
            if (!int.TryParse(InterTextBox1.Text, out int firstRect))
            {
                MessageBox.Show("Первый прямоугольник: введите корректное число", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterTextBox1.Focus();
                return;
            }

            // Проверка второго числа
            if (!int.TryParse(InterTextBox2.Text, out int secondRect))
            {
                MessageBox.Show("Второй прямоугольник: введите корректное число", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterTextBox2.Focus();
                return;
            }

            // Проверка диапазона (1-5)
            if (firstRect < 1 || firstRect > 5 || secondRect < 1 || secondRect > 5)
            {
                MessageBox.Show("Номера прямоугольников должны быть от 1 до 5", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Проверка пересечения
            bool isColliding = CollisionManager.IsCollision(_rectangles[firstRect - 1], _rectangles[secondRect - 1]);

            MessageBox.Show(isColliding ? "Прямоугольники пересекаются" : "Прямоугольники не пересекаются",
                           "Результат проверки",
                           MessageBoxButtons.OK,
                           isColliding ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
