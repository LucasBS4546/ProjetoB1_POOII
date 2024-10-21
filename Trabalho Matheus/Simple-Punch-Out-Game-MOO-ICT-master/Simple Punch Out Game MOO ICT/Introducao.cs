using System.Media;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Introducao : Form
    {

        SoundPlayer player = new SoundPlayer();
        bool tocando = true;

        public Introducao()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string musicPath = Path.Combine(Application.StartupPath, @"Musics\videoplayback_1.wav");
            player.SoundLocation = musicPath;
            player.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tocando)
            {
                tocando = false;
                player.Stop();
            }
            else
            {
                tocando = true;
                player.PlayLooping();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            player.Stop();
            form1.ShowDialog();
        }
    }
}
