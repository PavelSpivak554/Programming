namespace Notes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            NameOfNoteListBox = new ListBox();
            notifyIcon1 = new NotifyIcon(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            statusStrip1 = new StatusStrip();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TextNoteTextbox = new TextBox();
            NoteCategoryComboBox = new ComboBox();
            NoteTimePicker = new DateTimePicker();
            NoteNameTextBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // NameOfNoteListBox
            // 
            NameOfNoteListBox.FormattingEnabled = true;
            NameOfNoteListBox.Location = new Point(12, 14);
            NameOfNoteListBox.Name = "NameOfNoteListBox";
            NameOfNoteListBox.Size = new Size(228, 384);
            NameOfNoteListBox.TabIndex = 0;
            NameOfNoteListBox.SelectedIndexChanged += NameOfNoteListBox_SelectedIndexChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // button1
            // 
            button1.Location = new Point(24, 404);
            button1.Name = "button1";
            button1.Size = new Size(38, 29);
            button1.TabIndex = 12;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(68, 404);
            button2.Name = "button2";
            button2.Size = new Size(38, 29);
            button2.TabIndex = 13;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(112, 404);
            button3.Name = "button3";
            button3.Size = new Size(38, 29);
            button3.TabIndex = 14;
            button3.Text = "edt";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 67);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 15;
            label1.Text = "Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(273, 138);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 16;
            label2.Text = "Time";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(273, 182);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 17;
            label3.Text = "Category";
            // 
            // TextNoteTextbox
            // 
            TextNoteTextbox.Location = new Point(348, 64);
            TextNoteTextbox.Multiline = true;
            TextNoteTextbox.Name = "TextNoteTextbox";
            TextNoteTextbox.Size = new Size(388, 68);
            TextNoteTextbox.TabIndex = 18;
            // 
            // NoteCategoryComboBox
            // 
            NoteCategoryComboBox.FormattingEnabled = true;
            NoteCategoryComboBox.Location = new Point(348, 174);
            NoteCategoryComboBox.Name = "NoteCategoryComboBox";
            NoteCategoryComboBox.Size = new Size(388, 28);
            NoteCategoryComboBox.TabIndex = 20;
            // 
            // NoteTimePicker
            // 
            NoteTimePicker.Format = DateTimePickerFormat.Time;
            NoteTimePicker.Location = new Point(348, 138);
            NoteTimePicker.Name = "NoteTimePicker";
            NoteTimePicker.Size = new Size(388, 27);
            NoteTimePicker.TabIndex = 21;
            // 
            // NoteNameTextBox
            // 
            NoteNameTextBox.Location = new Point(348, 31);
            NoteNameTextBox.Name = "NoteNameTextBox";
            NoteNameTextBox.Size = new Size(388, 27);
            NoteNameTextBox.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(273, 34);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 22;
            label4.Text = "Name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NoteNameTextBox);
            Controls.Add(label4);
            Controls.Add(NoteTimePicker);
            Controls.Add(NoteCategoryComboBox);
            Controls.Add(TextNoteTextbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(statusStrip1);
            Controls.Add(NameOfNoteListBox);
            Name = "MainForm";
            Text = "NotesApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox NameOfNoteListBox;
        private NotifyIcon notifyIcon1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TextNoteTextbox;
        private ComboBox NoteCategoryComboBox;
        private DateTimePicker NoteTimePicker;
        private TextBox NoteNameTextBox;
        private Label label4;
    }
}
