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
    /// <summary>
    /// Пользовательский элемент управления для работы с прямоугольниками.
    /// Предоставляет функционал создания, редактирования и проверки пересечения прямоугольников.
    /// </summary>
    public partial class RectanglesControl : UserControl
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RectanglesControl"/>.
        /// </summary>
        public RectanglesControl()
        {
            InitializeComponent();
            WidthTextBox.Enter += TextBox_Enter;
            LengthTextBox.Enter += TextBox_Enter;
            ColorTextBox.Enter += TextBox_Enter;

            WidthTextBox.Leave += TextBox_Leave;
            LengthTextBox.Leave += TextBox_Leave;
            ColorTextBox.Leave += TextBox_Leave;
        }

        private Models.Rectangle[] rectangles;
        private Models.Rectangle _currentRectangle;
        bool _isUserInput = false;

        /// <summary>
        /// Обрабатывает событие входа в текстовое поле.
        /// Устанавливает флаг пользовательского ввода.
        /// </summary>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isUserInput = true;
        }

        /// <summary>
        /// Обрабатывает событие выхода из текстового поля.
        /// Сбрасывает флаг пользовательского ввода.
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isUserInput = false;
        }

        /// <summary>
        /// Создает массив из 5 прямоугольников со случайными параметрами.
        /// </summary>
        private void CreateRectangleButton_Click(object sender, EventArgs e)
        {
            rectangles = new Models.Rectangle[5];
            Random random = new Random();
            for (int i = 0; i < rectangles.Length; i++)
            {
                int length = random.Next(1, 100);
                int width = random.Next(1, 100);
                string color = "Color" + i;
                var center = new Point2D(length / 2, width / 2);
                var id = 0;
                rectangles[i] = new Models.Rectangle(length, width, color, center);
            }
            _currentRectangle = rectangles[0];
            WidthTextBox.BackColor = System.Drawing.Color.White;
            LengthTextBox.BackColor = System.Drawing.Color.White;
            ColorTextBox.BackColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// Обрабатывает изменение выбранного элемента в списке прямоугольников.
        /// Обновляет отображаемые параметры прямоугольника.
        /// </summary>
        private void RectangleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RectangleTextChange(RectangleListBox.SelectedIndex);
        }

        /// <summary>
        /// Обновляет текстовые поля значениями выбранного прямоугольника.
        /// </summary>
        /// <param name="i">Индекс выбранного прямоугольника в массиве.</param>
        private void RectangleTextChange(int i)
        {
            var Width = rectangles[i].Width;
            var Length = rectangles[i].Length;
            var Color = rectangles[i].Color;
            var CenterX = rectangles[i].Length / 2;
            var CenterY = rectangles[i].Width / 2;
            var Id = rectangles[i].Id;

            WidthTextBox.Text = Width.ToString();
            LengthTextBox.Text = Length.ToString();
            ColorTextBox.Text = Color.ToString();
            CenterXtextBox.Text = CenterX.ToString();
            CenterYtextBox.Text = CenterY.ToString();
            IDTextBox.Text = Id.ToString();
        }

        /// <summary>
        /// Обрабатывает изменение текста в поле длины прямоугольника.
        /// Проверяет и применяет новое значение длины.
        /// </summary>
        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Length = 0;
            try
            {
                if (Int32.TryParse(LengthTextBox.Text, out Length))
                {
                    var rect = rectangles[RectangleListBox.SelectedIndex];
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

        /// <summary>
        /// Обрабатывает изменение текста в поле ширины прямоугольника.
        /// Проверяет и применяет новое значение ширины.
        /// </summary>
        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Width = 0;
            try
            {
                if (Int32.TryParse(WidthTextBox.Text, out Width))
                {
                    var rect = rectangles[RectangleListBox.SelectedIndex];
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

        /// <summary>
        /// Обрабатывает изменение текста в поле цвета прямоугольника.
        /// Применяет новое значение цвета.
        /// </summary>
        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            var Color = ColorTextBox.Text;
            var rect = rectangles[RectangleListBox.SelectedIndex];
            rect.Color = Color;
        }

        /// <summary>
        /// Находит прямоугольник с максимальной шириной в массиве.
        /// </summary>
        /// <param name="rectangle">Массив прямоугольников для поиска.</param>
        /// <returns>Индекс прямоугольника с максимальной шириной.</returns>
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

        /// <summary>
        /// Выделяет найденный прямоугольник в списке.
        /// </summary>
        private void FindButton_Click(object sender, EventArgs e)
        {
            int index = FindRectangleWithMaxWidth(rectangles);
            RectangleListBox.SelectedIndex = index;
        }

        /// <summary>
        /// Проверяет пересечение между двумя выбранными прямоугольниками.
        /// </summary>
        private void IntersectionButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(InterTextBox1.Text, out int firstRect))
            {
                MessageBox.Show("Первый прямоугольник: введите корректное число", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterTextBox1.Focus();
                return;
            }

            if (!int.TryParse(InterTextBox2.Text, out int secondRect))
            {
                MessageBox.Show("Второй прямоугольник: введите корректное число", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                InterTextBox2.Focus();
                return;
            }

            if (firstRect < 1 || firstRect > 5 || secondRect < 1 || secondRect > 5)
            {
                MessageBox.Show("Номера прямоугольников должны быть от 1 до 5", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isColliding = CollisionManager.IsCollision(rectangles[firstRect - 1], rectangles[secondRect - 1]);

            MessageBox.Show(isColliding ? "Прямоугольники пересекаются" : "Прямоугольники не пересекаются",
                           "Результат проверки",
                           MessageBoxButtons.OK,
                           isColliding ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}