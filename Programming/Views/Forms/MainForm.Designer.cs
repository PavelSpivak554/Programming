namespace Programming.Views.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.enumerationsControl1 = new Programming.Views.UserControls.EnumerationsControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ParsingBox = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.moviesControl1 = new Programming.Views.UserControls.MoviesControl();
            this.RectanglesGroupBox = new System.Windows.Forms.GroupBox();
            this.rectanglesControl1 = new Programming.Views.UserControls.RectanglesControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rectanglesCollisionControl1 = new Programming.Views.UserControls.RectanglesCollisionControl();
            this.weekdayParsingControl1 = new Programming.Views.UserControls.WeekdayParsingControl();
            this.seasonControl1 = new Programming.Views.UserControls.SeasonControl();
            this.weekdayParsingControl2 = new Programming.Views.UserControls.WeekdayParsingControl();
            this.seasonControl2 = new Programming.Views.UserControls.SeasonControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ParsingBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.RectanglesGroupBox.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.enumerationsControl1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ParsingBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enums";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // enumerationsControl1
            // 
            this.enumerationsControl1.Location = new System.Drawing.Point(3, 6);
            this.enumerationsControl1.Name = "enumerationsControl1";
            this.enumerationsControl1.Size = new System.Drawing.Size(459, 230);
            this.enumerationsControl1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seasonControl2);
            this.groupBox1.Location = new System.Drawing.Point(380, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // ParsingBox
            // 
            this.ParsingBox.Controls.Add(this.weekdayParsingControl2);
            this.ParsingBox.Location = new System.Drawing.Point(11, 253);
            this.ParsingBox.Name = "ParsingBox";
            this.ParsingBox.Size = new System.Drawing.Size(363, 160);
            this.ParsingBox.TabIndex = 1;
            this.ParsingBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.RectanglesGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Classes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.moviesControl1);
            this.groupBox3.Location = new System.Drawing.Point(397, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 292);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movies";
            // 
            // moviesControl1
            // 
            this.moviesControl1.Location = new System.Drawing.Point(7, 22);
            this.moviesControl1.Name = "moviesControl1";
            this.moviesControl1.Size = new System.Drawing.Size(308, 249);
            this.moviesControl1.TabIndex = 0;
            // 
            // RectanglesGroupBox
            // 
            this.RectanglesGroupBox.Controls.Add(this.rectanglesControl1);
            this.RectanglesGroupBox.Location = new System.Drawing.Point(8, 6);
            this.RectanglesGroupBox.Name = "RectanglesGroupBox";
            this.RectanglesGroupBox.Size = new System.Drawing.Size(383, 292);
            this.RectanglesGroupBox.TabIndex = 0;
            this.RectanglesGroupBox.TabStop = false;
            this.RectanglesGroupBox.Text = "Rectangles";
            // 
            // rectanglesControl1
            // 
            this.rectanglesControl1.Location = new System.Drawing.Point(0, 15);
            this.rectanglesControl1.Name = "rectanglesControl1";
            this.rectanglesControl1.Size = new System.Drawing.Size(377, 271);
            this.rectanglesControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rectanglesCollisionControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rectangles";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rectanglesCollisionControl1
            // 
            this.rectanglesCollisionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectanglesCollisionControl1.Location = new System.Drawing.Point(3, 3);
            this.rectanglesCollisionControl1.Name = "rectanglesCollisionControl1";
            this.rectanglesCollisionControl1.Size = new System.Drawing.Size(786, 415);
            this.rectanglesCollisionControl1.TabIndex = 0;
            // 
            // weekdayParsingControl1
            // 
            this.weekdayParsingControl1.Location = new System.Drawing.Point(6, 27);
            this.weekdayParsingControl1.Name = "weekdayParsingControl1";
            this.weekdayParsingControl1.Size = new System.Drawing.Size(346, 107);
            this.weekdayParsingControl1.TabIndex = 0;
            // 
            // seasonControl1
            // 
            this.seasonControl1.Location = new System.Drawing.Point(0, 21);
            this.seasonControl1.Name = "seasonControl1";
            this.seasonControl1.Size = new System.Drawing.Size(228, 72);
            this.seasonControl1.TabIndex = 0;
            // 
            // weekdayParsingControl2
            // 
            this.weekdayParsingControl2.Location = new System.Drawing.Point(7, 22);
            this.weekdayParsingControl2.Name = "weekdayParsingControl2";
            this.weekdayParsingControl2.Size = new System.Drawing.Size(346, 107);
            this.weekdayParsingControl2.TabIndex = 0;
            // 
            // seasonControl2
            // 
            this.seasonControl2.Location = new System.Drawing.Point(7, 22);
            this.seasonControl2.Name = "seasonControl2";
            this.seasonControl2.Size = new System.Drawing.Size(228, 72);
            this.seasonControl2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ParsingBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.RectanglesGroupBox.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox RectanglesGroupBox;
        private System.Windows.Forms.TabPage tabPage4;
        private UserControls.RectanglesCollisionControl rectanglesCollisionControl1;
        private UserControls.RectanglesControl rectanglesControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UserControls.EnumerationsControl enumerationsControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ParsingBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.MoviesControl moviesControl1;
        private UserControls.WeekdayParsingControl weekdayParsingControl1;
        private UserControls.SeasonControl seasonControl1;
        private UserControls.SeasonControl seasonControl2;
        private UserControls.WeekdayParsingControl weekdayParsingControl2;
    }
}