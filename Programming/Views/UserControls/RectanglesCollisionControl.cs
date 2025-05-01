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
    public partial class RectanglesCollisionControl : UserControl
    {
        public RectanglesCollisionControl()
        {
            InitializeComponent();
        }

        private List<Models.Rectangle> _rectangles = new List<Models.Rectangle>();
        private Models.Rectangle _currentRectangle;
        private List<Panel> _rectanglePanels = new List<Panel>();
        /// <summary>
        /// Добавление нового прямоугольника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRectButton_Click(object sender, EventArgs e)
        {
            {
                Random random = new Random();
                Models.Rectangle _currentRectangle = new Models.Rectangle(
                    random.Next(1, 300),
                    random.Next(1, 300),
                    "Red",
                    new Point2D(
                        random.Next(1, 300),
                        random.Next(1, 300)));
                _rectangles.Add(_currentRectangle);
                RectListBox.Items.Add($"{_currentRectangle.Id}:" +
                    $"( X={_currentRectangle.Center.X}," +
                    $" Y={_currentRectangle.Center.Y}" +
                    $" W={_currentRectangle.Width}" +
                    $" L={_currentRectangle.Length})");


                RectIDTextBox.Text = _currentRectangle.Id.ToString();
                RectXTextBox.Text = _currentRectangle.Center.X.ToString();
                RectYTextBox.Text = _currentRectangle.Center.Y.ToString();
                RectLengthTextBox.Text = _currentRectangle.Length.ToString();
                RectWidthTextBox.Text = _currentRectangle.Width.ToString();


                Panel panel = new Panel
                {
                    // Задаем положение и размеры на основе прямоугольника
                    Location = new Point(
               (int)_currentRectangle.Center.X,
               (int)_currentRectangle.Center.Y),
                    Width = (int)_currentRectangle.Width,
                    Height = (int)_currentRectangle.Length,
                    BackColor = System.Drawing.Color.FromArgb(127, 127, 255, 127),
                };
                RectanglesPanel.Controls.Add(panel);
                _rectanglePanels.Add(panel);
                FindCollisions();
            }
        }
        /// <summary>
        /// Удаление прямоугольника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRectButton_Click(object sender, EventArgs e)
        {
            int index = RectListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Не выбран прямоугольник для удаления");
                return;
            }

            // Удаляем из всех коллекций
            if (index < _rectangles.Count) _rectangles.RemoveAt(index);
            if (index < RectListBox.Items.Count) RectListBox.Items.RemoveAt(index);
            if (index < RectanglesPanel.Controls.Count) RectanglesPanel.Controls.RemoveAt(index);
            if (index < _rectanglePanels.Count)
            {
                _rectanglePanels[index].Dispose();
                _rectanglePanels.RemoveAt(index);
            }

            FindCollisions();
        }

        private void RectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RectanglesTextChange(RectListBox.SelectedIndex);

        }
        /// <summary>
        /// Очистка текста для дальнейшей работы.
        /// </summary>
        private void ClearTextBoxes()
        {
            RectWidthTextBox.Clear();
            RectLengthTextBox.Clear();
            RectXTextBox.Clear();
            RectYTextBox.Clear();
            RectIDTextBox.Clear();
        }

        /// <summary>
        /// Изменение данных в тексте.
        /// </summary>
        /// <param name="index"></param>
        private void RectanglesTextChange(int index)
        {
            if (index < 0 || index >= _rectangles.Count)
            {
                ClearTextBoxes();
                _currentRectangle = null;
                return;
            }

            _currentRectangle = _rectangles[index];
            UpdateTextBoxes(_currentRectangle);
        }
        /// <summary>
        /// Обновление данных о прямоугольниках в TextBox.
        /// </summary>
        /// <param name="rectangle"></param>
        private void UpdateTextBoxes(Models.Rectangle rectangle)
        {
            if (rectangle == null)
            {
                ClearTextBoxes();
                return;
            }

            RectIDTextBox.Text = rectangle.Id.ToString();
            RectXTextBox.Text = rectangle.Center.X.ToString();
            RectYTextBox.Text = rectangle.Center.Y.ToString();
            RectLengthTextBox.Text = rectangle.Length.ToString();
            RectWidthTextBox.Text = rectangle.Width.ToString();
        }

        /// <summary>
        /// Проверка прямоугольников на пересечение и изменение цвета.
        /// </summary>
        private void FindCollisions()
        {
            // 1. Сначала сбрасываем цвета всех панелей
            foreach (var panel in _rectanglePanels)
            {
                panel.BackColor = System.Drawing.Color.FromArgb(127, 127, 255, 127);
            }

            // 2. Проверяем все возможные пары прямоугольников
            for (int i = 0; i < _rectangles.Count; i++)
            {
                // Проверяем, чтобы индекс i не выходил за границы списка панелей
                if (i >= _rectanglePanels.Count) continue;

                for (int j = i + 1; j < _rectangles.Count; j++)
                {
                    // Проверяем, чтобы индекс j не выходил за границы списка панелей
                    if (j >= _rectanglePanels.Count) continue;

                    if (CollisionManager.IsCollision(_rectangles[i], _rectangles[j]))
                    {
                        // Перекрашиваем пересекающиеся прямоугольники
                        _rectanglePanels[i].BackColor = System.Drawing.Color.FromArgb(127, 255, 127, 127);
                        _rectanglePanels[j].BackColor = System.Drawing.Color.FromArgb(127, 255, 127, 127);
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение изменений в тексте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RectListBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите прямоугольник для редактирования");
                    return;
                }

                // Валидация ввода
                if (!double.TryParse(RectWidthTextBox.Text, out double width) || width <= 0)
                    throw new ArgumentException("Некорректная ширина");

                if (!double.TryParse(RectLengthTextBox.Text, out double length) || length <= 0)
                    throw new ArgumentException("Некорректная длина");

                if (!double.TryParse(RectXTextBox.Text, out double x))
                    throw new ArgumentException("Некорректная координата X");

                if (!double.TryParse(RectYTextBox.Text, out double y))
                    throw new ArgumentException("Некорректная координата Y");

                // Получаем индекс выбранного прямоугольника
                int index = RectListBox.SelectedIndex;

                // Создаем новый прямоугольник с обновленными параметрами
                var updatedRect = new Models.Rectangle(
                    width,
                    length,
                    _rectangles[index].Color, // Сохраняем исходный цвет
                    new Point2D((int)x, (int)y));

                // Заменяем в коллекции
                _rectangles[index] = updatedRect;

                // Обновляем панель
                UpdateRectanglePanel(index);

                // Проверяем коллизии
                FindCollisions();

                MessageBox.Show("Изменения сохранены успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка сохранения",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновление панели.
        /// </summary>
        /// <param name="index"></param>
        private void UpdateRectanglePanel(int index)
        {
            if (index < 0 || index >= _rectangles.Count || index >= _rectanglePanels.Count)
                return;

            var rect = _rectangles[index];
            var panel = _rectanglePanels[index];

            // Обновляем размер и положение
            panel.Size = new Size((int)rect.Width, (int)rect.Length);
            panel.Location = new Point(
                (int)(rect.Center.X - rect.Width / 2),
                (int)(rect.Center.Y - rect.Length / 2));

            // Обновляем ListBox
            UpdateListBoxItem(index);


        }
        /// <summary>
        /// Обновление данных о прямоугольниках
        /// </summary>
        /// <param name="index"></param>
        private void UpdateListBoxItem(int index)
        {
            if (index < 0 || index >= _rectangles.Count) return;

            var rect = _rectangles[index];
            string itemText = $"{rect.Id}: (X={rect.Center.X:F1}; Y={rect.Center.Y:F1}; W={rect.Width:F1}; L={rect.Length:F1})";

            if (index < RectListBox.Items.Count)
                RectListBox.Items[index] = itemText;
        }

    }
}

