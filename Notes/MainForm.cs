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
    public partial class MainForm : Form
    {
        private BindingList<Note> _notes = new BindingList<Note>();
        private readonly string _dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "notes_data.txt");
        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
            LoadData();

        }

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
                        if (parts.Length == 4)
                        {
                            _notes.Add(new Note(
                                parts[0], // Title
                                parts[1], // Text
                                (KindOfNote)Enum.Parse(typeof(KindOfNote), parts[2]), // Kind
                                DateTime.Parse(parts[3]) // LastEditTime
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
        private void SaveData()
        {
            try
            {
                var lines = new List<string>();
                foreach (var note in _notes)
                {
                    lines.Add($"{note.Title}|{note.Text}|{note.Kind}|{note.LastEditTime}");
                }
                File.WriteAllLines(_dataFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        private void LoadSampleData()
        {
            _notes.Add(new Note("Покупки", "Молоко, хлеб, яйца", KindOfNote.House, DateTime.Now));
            _notes.Add(new Note("Встреча", "Совещание в 15:00", KindOfNote.Work, DateTime.Now));
            _notes.Add(new Note("Тренировка", "Бег 5 км", KindOfNote.Sport, DateTime.Now));
        }
        private void SortNotes()
        {
            var sortedList = new BindingList<Note>(
                _notes.OrderByDescending(n => n.LastEditTime).ToList()
            );

            _notes = sortedList;
            NameOfNoteListBox.DataSource = _notes;
            NameOfNoteListBox.DisplayMember = "Title";
        }

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

        private void NameOfNoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextData(NameOfNoteListBox.SelectedIndex);
        }





        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var note = new Note(
                    NoteNameTextBox.Text,
                    TextNoteTextbox.Text,
                    (KindOfNote)NoteCategoryComboBox.SelectedItem,
                    DateTime.Now

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

        private void button2_Click(object sender, EventArgs e)
        {
            int index = NameOfNoteListBox.SelectedIndex;
            _notes.RemoveAt(index);
            SortNotes();
            SaveData();
        }

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveData();
        }
    }
}