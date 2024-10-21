namespace quizGame
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            lblQuestion = new Label();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Yellow;
            pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
            pictureBox1.Location = new Point(26, 15);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(894, 351);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(8, 493);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(414, 58);
            button1.TabIndex = 1;
            button1.Tag = "1";
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ClickAnswerEvent;
            // 
            // button2
            // 
            button2.Location = new Point(505, 493);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(414, 58);
            button2.TabIndex = 1;
            button2.Tag = "2";
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ClickAnswerEvent;
            // 
            // button3
            // 
            button3.Location = new Point(8, 590);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(414, 58);
            button3.TabIndex = 1;
            button3.Tag = "3";
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ClickAnswerEvent;
            // 
            // button4
            // 
            button4.Location = new Point(505, 590);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(414, 58);
            button4.TabIndex = 1;
            button4.Tag = "4";
            button4.Text = "button1";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ClickAnswerEvent;
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(109, 384);
            lblQuestion.Margin = new Padding(4, 0, 4, 0);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(714, 85);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Question";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.Location = new Point(829, 398);
            button5.Name = "button5";
            button5.Size = new Size(90, 61);
            button5.TabIndex = 3;
            button5.Tag = "100";
            button5.Text = "Passar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ClickAnswerEvent;
            // 
            // button6
            // 
            button6.Location = new Point(12, 398);
            button6.Name = "button6";
            button6.Size = new Size(90, 61);
            button6.TabIndex = 4;
            button6.Text = "Ajuda";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(933, 665);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(lblQuestion);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Show do milhão!";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblQuestion;
        private Button button5;
        private Button button6;
    }
}
