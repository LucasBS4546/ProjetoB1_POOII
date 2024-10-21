using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizGame
{
    public partial class Form2 : Form
    {
        private SoundPlayer player;
        public Form2()
        {
            player = new SoundPlayer(@"Resources/MusicaTema.wav");
            player.Load();
            player.Play();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.Stop();
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
