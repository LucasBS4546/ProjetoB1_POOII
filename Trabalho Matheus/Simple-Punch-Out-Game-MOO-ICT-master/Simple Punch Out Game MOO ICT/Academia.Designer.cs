using DocumentFormat.OpenXml.Presentation;
using System;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    partial class Academia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Academia));
            Hp = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            Sair = new Button();
            SuspendLayout();
            // 
            // Hp
            // 
            Hp.BackColor = Color.Transparent;
            Hp.Location = new Point(265, 129);
            Hp.Name = "Hp";
            Hp.Size = new Size(146, 23);
            Hp.TabIndex = 0;
            Hp.Text = "Chingar Inimigo = 10$";
            Hp.UseVisualStyleBackColor = false;
            Hp.Click += Hp_Click;
            // 
            // button2
            // 
            button2.Location = new Point(334, 312);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 1;
            button2.Text = "Vidas = 100$";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Vidas_Click;
            // 
            // button3
            // 
            button3.Location = new Point(162, 205);
            button3.Name = "button3";
            button3.Size = new Size(98, 23);
            button3.TabIndex = 2;
            button3.Text = "Força =  30$";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Forca_Click;
            // 
            // button4
            // 
            button4.Location = new Point(599, 129);
            button4.Name = "button4";
            button4.Size = new Size(112, 23);
            button4.TabIndex = 3;
            button4.Text = "Proxima Batalha";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Battle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("SF Fedora Titles Shadow", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(327, 62);
            label1.Name = "label1";
            label1.Size = new Size(104, 33);
            label1.TabIndex = 4;
            label1.Text = "Coins:";
            // 
            // Sair
            // 
            Sair.Location = new Point(710, 226);
            Sair.Name = "Sair";
            Sair.Size = new Size(94, 41);
            Sair.TabIndex = 5;
            Sair.Text = "Sair Para Beber";
            Sair.UseVisualStyleBackColor = true;
            Sair.Click += Sair_Click;
            // 
            // Academia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(Sair);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Hp);
            Name = "Academia";
            Text = "Academia";
            Load += Academia_Lod;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Hp;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button Sair;
    }
}