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
using System.Xml.Linq;
using Notes.Models;
using Notes.Models.Enums;

namespace Notes
{
    /// <summary>
    /// Главная форма приложения для работы с заметками
    /// </summary>
    public partial class MainForm : Form
    {
        private BindingList<Note> _notes = new BindingList<Note>();
        private readonly string _dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "notes_data.txt");

        /// <summary>
        /// Инициализирует новый экземпляр главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
            LoadData();
        }

        /// <summary>
        /// Загружает данные заметок из файла или создает тестовые данные, если файл не существует
        /// </summary>
        private void LoadData()
        {
            if (File.Exists(_dataFilePath))
            {
                try
                {
                    var lines = File.ReadAllLines(_dataFilePath);
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            _notes.Add(new Note(
                                parts[0], // Title
                                parts[1], // Text
                                (KindOfNote)Enum.Parse(typeof(KindOfNote), parts[2]), // Kind
                                DateTime.Parse(parts[3]), // CreationTime
                                DateTime.Parse(parts[4])  // LastEditTime
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadSampleData();
                }
            }
            else
            {
                LoadSampleData();
            }
        }

        /// <summary>
        /// Сохраняет все заметки в файл данных
        /// </summary>
        private void SaveData()
        {
            try
            {
                var lines = new List<string>();
                foreach (var note in _notes)
                {
                    lines.Add($"{note.Title}|{note.Text}|{note.Kind}|{note.CreationTime}|{note.LastEditTime}");
                }
                File.WriteAllLines(_dataFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Инициализирует элементы управления формы
        /// </summary>
        private void InitializeControls()
        {
            // Настройка ListBox
            NameOfNoteListBox.DataSource = _notes;
            NameOfNoteListBox.DisplayMember = "Name";

            // Настройка ComboBox категорий
            NoteCategoryComboBox.DataSource = Enum.GetValues(typeof(KindOfNote));

            // Начальная сортировка
            SortNotes();
        }

        /// <summary>
        /// Загружает тестовые данные заметок
        /// </summary>
        private void LoadSampleData()
        {
            DateTime now = DateTime.Now;
            _notes.Add(new Note("Покупки", "Молоко, хлеб, яйца", KindOfNote.House, now, now));
            _notes.Add(new Note("Встреча", "Совещание в 15:00", KindOfNote.Work, now, now));
            _notes.Add(new Note("Тренировка", "Бег 5 км", KindOfNote.Sport, now, now));
        }

        /// <summary>
        /// Сортирует заметки по времени последнего редактирования (от новых к старым)
        /// </summary>
        private void SortNotes()
        {
            var sortedList = new BindingList<Note>(
                _notes.OrderByDescending(n => n.LastEditTime).ToList()
            );

            _notes = sortedList;
            NameOfNoteListBox.DataSource = _notes;
            NameOfNoteListBox.DisplayMember = "Title";
        }

        /// <summary>
        /// Обновляет текстовые поля формы данными выбранной заметки
        /// </summary>
        /// <param name="i">Индекс заметки в списке</param>
        private void UpdateTextData(int i)
        {
            var title = _notes[i].Title;
            var text = _notes[i].Text;
            var category = _notes[i].Kind;
            DateTime time = _notes[i].LastEditTime;

            NoteNameTextBox.Text = title;
            TextNoteTextbox.Text = text;
            NoteCategoryComboBox.SelectedItem = category;
            NoteTimePicker.Value = time;
        }

        /// <summary>
        /// Обработчик события изменения выбранной заметки в списке
        /// </summary>
        private void NameOfNoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextData(NameOfNoteListBox.SelectedIndex);
        }

        /// <summary>
        /// Обработчик нажатия кнопки добавления новой заметки
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                var note = new Note(
                    NoteNameTextBox.Text,
                    TextNoteTextbox.Text,
                    (KindOfNote)NoteCategoryComboBox.SelectedItem,
                    now, // CreationTime
                    now  // LastEditTime
                );

                _notes.Add(note);
                SortNotes();
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки удаления заметки
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            int index = NameOfNoteListBox.SelectedIndex;
            _notes.RemoveAt(index);
            SortNotes();
            SaveData();
        }

        /// <summary>
        /// Обработчик нажатия кнопки редактирования заметки
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            int index = NameOfNoteListBox.SelectedIndex;
            if (NameOfNoteListBox.SelectedItem is Note selectedNote)
            {
                try
                {
                    selectedNote.Title = NoteNameTextBox.Text;
                    selectedNote.Text = TextNoteTextbox.Text;
                    selectedNote.Kind = (KindOfNote)NoteCategoryComboBox.SelectedItem;

                    // Время редактирования обновляется автоматически через свойства
                    SortNotes();
                    SaveData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveData();
        }
    }
}