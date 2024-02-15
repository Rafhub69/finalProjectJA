namespace FinalProgramJA
{
    partial class Labirynt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Maze sizes
        /// </summary>
        private string[] tableSize = { "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37" };

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labirynt));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            heightBox = new ComboBox();
            widthBox = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label5 = new Label();
            hScrollBar1 = new HScrollBar();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Wysokość:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 33);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Szerokość:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 9);
            label3.Name = "label3";
            label3.Size = new Size(144, 15);
            label3.TabIndex = 2;
            label3.Text = "Czas wykonania labiryntu:";
            // 
            // heightBox
            // 
            heightBox.FormattingEnabled = true;
            heightBox.Location = new Point(80, 6);
            heightBox.Name = "heightBox";
            heightBox.Size = new Size(54, 23);
            heightBox.TabIndex = 3;
            heightBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // widthBox
            // 
            widthBox.FormattingEnabled = true;
            widthBox.Location = new Point(80, 30);
            widthBox.Name = "widthBox";
            widthBox.Size = new Size(54, 23);
            widthBox.TabIndex = 4;
            widthBox.SelectedIndexChanged += widthBox_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(25, 59);
            button1.Name = "button1";
            button1.Size = new Size(109, 23);
            button1.TabIndex = 5;
            button1.Text = "Stwórz labirynt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(155, 59);
            button2.Name = "button2";
            button2.Size = new Size(152, 23);
            button2.TabIndex = 6;
            button2.Text = "Rozwiąż labirynt";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(25, 88);
            button3.Name = "button3";
            button3.Size = new Size(109, 23);
            button3.TabIndex = 7;
            button3.Text = "Zapisz labirynt";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(155, 88);
            button4.Name = "button4";
            button4.Size = new Size(152, 23);
            button4.TabIndex = 8;
            button4.Text = "Zapisz rozwiązany labirynt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 117);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1880, 762);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 897);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 10;
            label4.Text = "Biblioteka:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(13, 924);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(49, 19);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "C++";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(12, 949);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(75, 19);
            radioButton2.TabIndex = 12;
            radioButton2.Text = "Asembler";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 992);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 13;
            label5.Text = "Ilość rdzeni:";
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(109, 990);
            hScrollBar1.Maximum = 64;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(1783, 17);
            hScrollBar1.TabIndex = 14;
            hScrollBar1.Value = 1;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(87, 990);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 15;
            label6.Text = "1";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(144, 33);
            label7.Name = "label7";
            label7.Size = new Size(148, 15);
            label7.TabIndex = 16;
            label7.Text = "Czas rozwiązania labiryntu:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(294, 9);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 17;
            label8.Text = "1";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(294, 33);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 18;
            label9.Text = "1";
            label9.Click += label9_Click;
            // 
            // Labirynt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(hScrollBar1);
            Controls.Add(label5);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(widthBox);
            Controls.Add(heightBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Labirynt";
            Text = "Labirynt";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox heightBox;
        private ComboBox widthBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private Label label4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label5;
        private HScrollBar hScrollBar1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private SaveFileDialog saveFileDialog1;
    }
}
