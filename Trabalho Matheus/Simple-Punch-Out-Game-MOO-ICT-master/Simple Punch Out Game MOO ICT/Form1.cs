using DocumentFormat.OpenXml.Presentation;
using System;
using System.IO;
using System.Media;
using System.Drawing;
using Simple_Punch_Out_Game_MOO_ICT.Classes;
using System.Reflection.Metadata.Ecma335;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        Player jogador = new Player();
        Enemy Enemy = new Enemy();
        Random random = new Random();
        int lutadorDaRodada = 0;
        int index = 0;
        string musicPath;
        List<string> enemyAttack = new List<string> { "left", "right", "block" };
        SoundPlayer soundKO = new SoundPlayer();
        SoundPlayer Music = new SoundPlayer();
        private bool attackPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BoxerAttackTimer.Start();
            BoxerMoveTimer.Start();
            Player.PlayerHealth = Player.DefaultHP;
            Enemy.PlayerHealth = Enemy.HpDefault1;
            boxer.Left = 400;
            lutadorDaRodada = random.Next(0, 2);

            if (lutadorDaRodada == 0)
            {
                musicPath = Path.Combine(Application.StartupPath, @"Musics\Battle.wav");
            }
            else {
                musicPath = Path.Combine(Application.StartupPath, @"Musics\Battle2.wav");
                boxer.Image = Properties.Resources.enemy2_stand;
                label2.Text = "king-hippo   "; 
            }
            string KOPath = Path.Combine(Application.StartupPath, @"Musics\K.O-Sound-Effect.wav");
            Music.SoundLocation = musicPath;
            Music.Load();
            Music.PlayLooping();
            soundKO.SoundLocation = KOPath;
            soundKO.Load();
        }

        private void BoxerAttackTImerEvent(object sender, EventArgs e)
        {
            index = random.Next(0, enemyAttack.Count);
            if (lutadorDaRodada == 0)
            {
                switch (enemyAttack[index].ToString())
                {
                    case "left":
                        boxer.Image = Properties.Resources.enemy_punch1;
                        Enemy.PlayerBlock = false;

                        if (boxer.Bounds.IntersectsWith(player.Bounds) && Player.PlayerBlock == false)
                        {
                            Player.PlayerHealth -= 5;
                        }

                        break;

                    case "right":

                        boxer.Image = Properties.Resources.enemy_punch2;
                        Enemy.PlayerBlock = false;

                        if (boxer.Bounds.IntersectsWith(player.Bounds) && Player.PlayerBlock == false)
                        {
                            Player.PlayerHealth -= 5;
                        }
                        break;

                    case "block":

                        boxer.Image = Properties.Resources.enemy_block;
                        Enemy.PlayerBlock = true;
                        break;
                }
            }
            else {
                switch (enemyAttack[index].ToString())
                {
                    case "left":
                        boxer.Image = Properties.Resources.enemy2_punch;
                        Enemy.PlayerBlock = false;

                        if (boxer.Bounds.IntersectsWith(player.Bounds) && Player.PlayerBlock == false)
                        {
                            Player.PlayerHealth -=(5 + (Player.DanoExtra/2));
                        }

                        break;

                    case "right":

                        boxer.Image = Properties.Resources.enemy2_punch1;
                        Enemy.PlayerBlock = false;

                        if (boxer.Bounds.IntersectsWith(player.Bounds) && Player.PlayerBlock == false)
                        {
                            Player.PlayerHealth -=(5 + (Player.DanoExtra / 2));
                        }
                        break;

                    case "block":

                        boxer.Image = Properties.Resources.enemy2_block;
                        Enemy.PlayerBlock = true;
                        break;
                }
            }
        }

        private void BoxerMoveTimerEvent(object sender, EventArgs e)
        {
            // set up both health bars
            if (Player.PlayerHealth > 1)
            {
                playerHealthBar.Value = Player.PlayerHealth;
            }
            if (Enemy.PlayerHealth > 1)
            {
                if (Enemy.PlayerHealth > 100) { 
                    Enemy.PlayerHealth = 100;
                }
                boxerHealthBar.Value = Enemy.PlayerHealth;
            }
            // move the boxer

            boxer.Left += Enemy.EnemySpeed;

            if (boxer.Left > 430)
            {
                Enemy.EnemySpeed = -5;
            }
            if (boxer.Left < 220)
            {
                Enemy.EnemySpeed = 5;
            }

            EndTheGame();
        }

        private void EndTheGame() {
            // check for the end of game scenario

            if (Enemy.PlayerHealth < 1)
            {
                if (lutadorDaRodada == 0)
                {
                    boxer.Image = Properties.Resources.enemy_death;
                }
                else {
                    boxer.Image = Properties.Resources.enemy2_deach;
                }
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();
                soundKO.Play();
                Mario.BackgroundImage = Properties.Resources.Mario_Win;
                Player.Coins += Player.PlayerHealth;
                Player.Victory += 1;
                MessageBox.Show("You Win!!!!");
                if (Player.Victory < 5)
                {
                    ResetGame();
                }
                else { 
                    Vitoria vitoria = new Vitoria();
                    Close();
                    vitoria.Show();
                }
            }
            if (Player.PlayerHealth < 1 && Player.Vidas == 0)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();
                soundKO.Play();
                Mario.BackgroundImage = Properties.Resources.Mario_Win;
                MessageBox.Show("You Lose");
                Player.Victory -= 1;
                Application.Exit();
            }else if(Player.PlayerHealth < 1){
                Player.PlayerHealth = Player.DefaultHP;
                Player.Vidas -= 1;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (attackPerformed == false) 
            {
                if (e.KeyCode == Keys.Left)
                {
                    player.Image = Properties.Resources.boxer_left_punch;
                    Player.PlayerBlock = false;
                    if (player.Bounds.IntersectsWith(boxer.Bounds) && Enemy.PlayerBlock == false)
                    {
                        if (lutadorDaRodada == 0)
                        {
                            boxer.Image = Properties.Resources.enemy_hit;
                            Enemy.PlayerHealth -= 5 + Player.DanoExtra;
                        }
                        else {
                            boxer.Image = Properties.Resources.enemy2_hit;
                            Enemy.PlayerHealth -= 5 + Player.DanoExtra;
                        }
                    }
                    attackPerformed = true; 
                }
                if (e.KeyCode == Keys.Right)
                {
                    player.Image = Properties.Resources.boxer_right_punch;
                    Player.PlayerBlock = false;

                    if (player.Bounds.IntersectsWith(boxer.Bounds) && Enemy.PlayerBlock == false)
                    {
                        if (lutadorDaRodada == 0)
                        {
                            boxer.Image = Properties.Resources.enemy_hit;
                            Enemy.PlayerHealth -= 5 + Player.DanoExtra;
                        }
                        else
                        {
                            boxer.Image = Properties.Resources.enemy2_hit;
                            Enemy.PlayerHealth -= 5 + Player.DanoExtra;
                        }
                    }
                    attackPerformed = true; 
                }
                if (e.KeyCode == Keys.Down)
                {
                    player.Image = Properties.Resources.boxer_block;
                    Player.PlayerBlock = true;
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            player.Image = Properties.Resources.boxer_stand;
            Player.PlayerBlock = false;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                attackPerformed = false; // Reseta a flag quando a tecla é solta
            }
        }

        private void CloseFormAndOpenAcademia()
        {
            this.Close(); // Fecha o Form1 (a luta)
            Academia academia = new Academia(); // Cria a academia
            academia.Show(); // Abre a academia
        }

        private void ResetGame()
        {

            Close();
            CloseFormAndOpenAcademia();
        }
    }
}