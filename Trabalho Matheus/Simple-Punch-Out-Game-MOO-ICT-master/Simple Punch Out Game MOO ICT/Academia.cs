using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simple_Punch_Out_Game_MOO_ICT.Classes;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Academia : Form
    {
        Player jogador = new Player();
        Enemy enemy = new Enemy();
        SoundPlayer Music = new SoundPlayer();
        public Academia()
        {
            InitializeComponent();
        }

        private void Academia_Lod(object sender, EventArgs e)
        {
            label1.Text = $"Coins: {Player.Coins} Vitorias: {Player.Victory}";
            string songPath = Path.Combine(Application.StartupPath, @"Musics\Shop.wav");
            Music.SoundLocation = songPath;
            Music.PlayLooping();
        }

        private void Hp_Click(object sender, EventArgs e)
        {
            if (Player.Coins >= 10)
            {
                Player.Coins -= 10;
                Enemy.HpDefault1 -= 3;
                Player.DanoExtra -= 1;
                MessageBox.Show("A Moral é importante Se lembre disso: -1 de dano.");
                label1.Text = $"Coins: {Player.Coins} Vitorias: {Player.Victory}";
            }
        }

        private void Vidas_Click(object sender, EventArgs e)
        {
            if (Player.Coins >= 100)
            {
                Player.Coins -= 100;
                Player.Vidas += 10;
                label1.Text = $"Coins: {Player.Coins} Vitorias: {Player.Victory}";
            }
        }

        private void Forca_Click(object sender, EventArgs e)
        {
            if (Player.Coins >= 30)
            {
                Player.Coins -= 30;
                Player.DanoExtra += 2;
                Player.DefaultHP -= 10;
                if (Player.DefaultHP < 0) { 
                    Player.DefaultHP = 10;
                }
                label1.Text = $"Coins: {Player.Coins} Vitorias: {Player.Victory}";
            }
        }

        private void Battle_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Close();
            Music.Stop();
            Form1.Refresh();
            Form1.Show();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
