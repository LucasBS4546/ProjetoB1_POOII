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
    public partial class Form4 : Form
    {
        public SoundPlayer tchau;
        public Form4()
        {
            tchau = new SoundPlayer(@"Resources/tchau.wav");
            InitializeComponent();
            tchau.Load();
            tchau.Play();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
