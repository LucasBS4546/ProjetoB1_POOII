using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Endless_Runner_WPF_MOO_ICT
{
    
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        //MediaPlayer music = new MediaPlayer();
        
        Rect playerHitBox;
        Rect groundHitBox;
        Rect obstacleHitBox;

        bool jumping;
        bool deslizando = false;

        int force = 20;
        int speed = 5;

        bool pausado = false;

        bool gameOver;

        double spriteIndex = 0;

        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush obstacleSprite = new ImageBrush();

        int score = 0;

        string proxObstaculo = "normal";

        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus();

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.gif"));

            background.Fill = backgroundSprite;
            background2.Fill = backgroundSprite;

            StartGame();
        }

        private void GameEngine(object sender, EventArgs e)
        {

            if (pausado)
            {
                return; 
            }

            Canvas.SetLeft(background, Canvas.GetLeft(background) - 3);
            Canvas.SetLeft(background2, Canvas.GetLeft(background2) - 3);

            if (Canvas.GetLeft(background) < -1262)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background2) + background2.Width);
            }

            if (Canvas.GetLeft(background2) < -1262)
            {
                Canvas.SetLeft(background2, Canvas.GetLeft(background) + background.Width);
            }
                        
            Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            Canvas.SetLeft(obstacle, Canvas.GetLeft(obstacle) - 12);
            scoreText.Content = $"Score: {score}";

            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width - 15, player.Height);
            obstacleHitBox = new Rect(Canvas.GetLeft(obstacle), Canvas.GetTop(obstacle), obstacle.Width, obstacle.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                speed = 0;
                Canvas.SetTop(player, Canvas.GetTop(ground) - player.Height);
                jumping = false;

                spriteIndex += .5;

                if (spriteIndex > 8)
                {
                    spriteIndex = 1;
                }

                if (!deslizando)
                {
                    RunSprite(spriteIndex);
                }
            }
            else
            {
                if (jumping)
                {
                    speed = -9;
                    force -= 1;

                    if (force < 0)
                    {
                        jumping = false;
                        speed = 12;
                    }
                }
                else
                {
                    speed = 12;
                }
            }

            if (Canvas.GetLeft(obstacle) < -50)
            {
                if (proxObstaculo == "normal")
                {
                    obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
                    obstacle.Height = 178;
                    obstacle.Width = 50;
                    Canvas.SetTop(obstacle, 310);
                    proxObstaculo = "top"; 
                }
                else
                {
                    obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle2.png"));
                    obstacle.Height = 310;
                    obstacle.Width = 70;
                    Canvas.SetTop(obstacle, 0); 
                    proxObstaculo = "normal"; 
                }

                Canvas.SetLeft(obstacle, 950);
                score += 1; 
            }

            if (playerHitBox.IntersectsWith(obstacleHitBox))
            {
                gameOver = true;
                gameTimer.Stop();
            }

            if (gameOver)
            {
                obstacle.Stroke = Brushes.Black;
                obstacle.StrokeThickness = 1;

                player.Stroke = Brushes.Red;
                player.StrokeThickness = 1;

                player.Height = 99;
                player.Width = 67;
                scoreText.Content = $"Score: {score} Pressione Enter para jogar novamente!!";
            }
            else
            {
                player.StrokeThickness = 0;
                obstacle.StrokeThickness = 0;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && gameOver == true)
            {
                StartGame();
            }

            if (e.Key == Key.Down && !deslizando && jumping == false) 
            {
                deslizando = true;
                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_12.gif"));
                player.Height = 67;
                player.Width = 99;
                Canvas.SetTop(player, Canvas.GetTop(player) + (99 - 67));
            }

            if (e.Key == Key.P)
            {
                if (pausado)
                {
                    pausado = false;
                    gameTimer.Start();
                    scoreText.Content = $"Score: {score}";
                }
                else if (gameOver) 
                {
                    return;
                }
                else
                {
                    pausado = true; 
                    gameTimer.Stop();
                    scoreText.Content = $"Jogo Pausado! Pressione P para despausar.";
                }
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space || e.Key == Key.Up) && jumping == false && Canvas.GetTop(player) > 260)
            {
                jumping = true;
                force = 15;
                speed = -12;

                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
            }

            if (e.Key == Key.Down && deslizando)
            {
                deslizando = false;
                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_01.gif"));
                Canvas.SetTop(player, Canvas.GetTop(player) - (99 - 67)); 
                player.Height = 99; 
                player.Width = 67;
            }
        }


        private void StartGame()
        {

            //music.Open(new Uri("pack://application:,,,/music/music.mp3"));
            //music.Volume = 0.5; // Ajusta o volume (0.0 a 1.0)
            //music.Play();

            Canvas.SetLeft(background, 0);
            Canvas.SetLeft(background2, 1262);

            Canvas.SetLeft(player, 110);
            Canvas.SetTop(player, 140);

            Canvas.SetLeft(obstacle, 950);
            Canvas.SetTop(obstacle, 310);

            proxObstaculo = "normal";
            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obstacle.Height = 178;
            obstacle.Width = 50;
            
            RunSprite(1);

            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obstacle.Fill = obstacleSprite;

            jumping = false;
            deslizando = false;
            gameOver = false;
            score = 0;

            scoreText.Content = $"Score: {score}";

            gameTimer.Start();
        }

        private void RunSprite(double i)
        {
            switch (i)
            {
                case 1:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_01.gif"));
                    break;
                case 2:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
                    break;
                case 3:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_03.gif"));
                    break;
                case 4:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_04.gif"));
                    break;
                case 5:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 6:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_06.gif"));
                    break;
                case 7:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_07.gif"));
                    break;
                case 8:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_08.gif"));
                    break;
            }

            player.Fill = playerSprite;
        }
    }
}