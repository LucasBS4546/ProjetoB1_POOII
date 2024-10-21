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

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Vitoria : Form
    {

        SoundPlayer Win = new SoundPlayer();

        public Vitoria()
        {
            InitializeComponent();
        }

        private void Vitoria_Loud(object sender, EventArgs e) {
            string musicPath = Path.Combine(Application.StartupPath, @"Musics\Win.wav");
            Win.SoundLocation = musicPath;
            Win.Load();
            Win.PlayLooping();
        }
    }
}
