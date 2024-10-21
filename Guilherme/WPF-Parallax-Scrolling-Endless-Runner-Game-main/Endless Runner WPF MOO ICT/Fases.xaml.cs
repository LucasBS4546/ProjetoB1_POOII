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

    public partial class Fases : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        Rect playerHitBox;
        Rect groundHitBox;
        Rect obstacleHitBox;

        bool jumping;
        bool deslizando = false;

        bool faseCompletada = false; 

        bool pausado = false;

        int force = 20;
        int speed = 5;

        Random rnd = new Random();

        bool gameOver;
        bool gameWon; 

        double spriteIndex = 0;

        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush obstacleSprite = new ImageBrush();

        int[] obstaclePosition = { 320, 310, 300, 305, 315 };

        int score = 0;

        string proxObstaculo = "normal"; 

        int faseAtual = 1; 

        public Fases()
        {
            InitializeComponent();

            MyCanvasF.Focus();

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.gif"));

            backgroundF.Fill = backgroundSprite;
            background2F.Fill = backgroundSprite;

            StartGame();
        }

        private void GameEngine(object sender, EventArgs e)
        {
            if (pausado)
            {
                return;
            }
            
            Canvas.SetLeft(backgroundF, Canvas.GetLeft(backgroundF) - 3);
            Canvas.SetLeft(background2F, Canvas.GetLeft(background2F) - 3);

            if (Canvas.GetLeft(backgroundF) < -1262)
            {
                Canvas.SetLeft(backgroundF, Canvas.GetLeft(background2F) + background2F.Width);
            }

            if (Canvas.GetLeft(background2F) < -1262)
            {
                Canvas.SetLeft(background2F, Canvas.GetLeft(backgroundF) + backgroundF.Width);
            }

            Canvas.SetTop(playerF, Canvas.GetTop(playerF) + speed);
            Canvas.SetLeft(obstacleF, Canvas.GetLeft(obstacleF) - 12);
            scoreTextF.Content = $"Score: {score}";

            playerHitBox = new Rect(Canvas.GetLeft(playerF), Canvas.GetTop(playerF), playerF.Width - 15, playerF.Height);
            obstacleHitBox = new Rect(Canvas.GetLeft(obstacleF), Canvas.GetTop(obstacleF), obstacleF.Width, obstacleF.Height);
            groundHitBox = new Rect(Canvas.GetLeft(groundF), Canvas.GetTop(groundF), groundF.Width, groundF.Height);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                speed = 0; 
                Canvas.SetTop(playerF, Canvas.GetTop(groundF) - playerF.Height); 
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

            if (Canvas.GetLeft(obstacleF) < -50)
            {
               
                if (proxObstaculo == "normal")
                {
                    obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
                    obstacleF.Height = 178;
                    obstacleF.Width = 50;
                    Canvas.SetTop(obstacleF, 310); 
                    proxObstaculo = "top"; 
                }
                else
                {
                    obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle2.png"));
                    obstacleF.Height = 310;
                    obstacleF.Width = 70;
                    Canvas.SetTop(obstacleF, 0); 
                    proxObstaculo = "normal"; 
                }

                Canvas.SetLeft(obstacleF, 950); 
                score += 1;

                ConferirFase(); 
            }

            if (playerHitBox.IntersectsWith(obstacleHitBox))
            {
                gameOver = true;
                gameTimer.Stop();
            }

            if (gameOver)
            {
                obstacleF.Stroke = Brushes.Black;
                obstacleF.StrokeThickness = 1;

                playerF.Stroke = Brushes.Red;
                playerF.StrokeThickness = 1;

                playerF.Height = 99;
                playerF.Width = 67;

                scoreTextF.Content = $"Score: {score} Pressione Enter para jogar novamente!!";
            }
            else if (gameWon)
            {
                scoreTextF.Content = $"Você venceu! Pressione Enter para jogar novamente!!";
            }
            else
            {
                playerF.StrokeThickness = 0;
                obstacleF.StrokeThickness = 0;
            }
        }

        private void ConferirFase()
        {
            if (faseAtual == 1 && score >= 5)
            {
                gameTimer.Stop();
                faseCompletada = true;
                scoreTextF.Content = $"Fase 1 completa! Enter para proxima fase!";
                score = 0;
            }
            else if (faseAtual == 2 && score >= 10)
            {
                gameTimer.Stop();
                faseCompletada = true;
                scoreTextF.Content = $"Fase 2 completa! Enter para para proxima fase!";
                score = 0;
            }
            else if (faseAtual == 3 && score >= 20)
            {
                gameWon = true;
                gameTimer.Stop();
                scoreTextF.Content = $"Você venceu! Pressione Enter para jogar novamente!!"; 
            }
        }
        
        private void KeyIsDownF(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && (gameOver == true || gameWon == true))
            {
                StartGame();
            }

            if (e.Key == Key.Enter && faseCompletada)
            {
                faseCompletada = false; 
                gameTimer.Start(); 
                faseAtual += 1; 
            }

            if (e.Key == Key.Down && !deslizando && jumping == false) 
            {
                deslizando = true;
                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_12.gif")); 
                playerF.Height = 67;
                playerF.Width = 99;
                Canvas.SetTop(playerF, Canvas.GetTop(playerF) + (99 - 67)); 
            }

            if (e.Key == Key.P)
            {
                if (pausado)
                {
                    pausado = false;
                    gameTimer.Start(); 
                    scoreTextF.Content = $"Score: {score}";
                }
                else if (gameOver)
                {
                    return;
                }
                else
                {
                    pausado = true; 
                    gameTimer.Stop(); 
                    scoreTextF.Content = $"Jogo Pausado! Pressione P para despausar."; 
                }
            }
        }

        private void KeyIsUpF(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space || e.Key == Key.Up) && jumping == false && Canvas.GetTop(playerF) > 260)
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
                Canvas.SetTop(playerF, Canvas.GetTop(playerF) - (99 - 67));
                playerF.Height = 99; 
                playerF.Width = 67;
            }
        }

        private void StartGame()
        {
            Canvas.SetLeft(backgroundF, 0);
            Canvas.SetLeft(background2F, 1262);

            Canvas.SetLeft(playerF, 110);
            Canvas.SetTop(playerF, 140);

            Canvas.SetLeft(obstacleF, 950);
            Canvas.SetTop(obstacleF, 310);

            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            proxObstaculo = "normal";
            obstacleF.Height = 178;
            obstacleF.Width = 50;

            RunSprite(1);

            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obstacleF.Fill = obstacleSprite;

            jumping = false;
            deslizando = false; 
            gameOver = false;
            gameWon = false; 
            score = 0;

            faseAtual = 1; 

            scoreTextF.Content = $"Score: {score}";

            gameTimer.Start();

            score = 0;
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

            playerF.Fill = playerSprite;
        }
    }


}