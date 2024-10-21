using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Quiz_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para Venceu.xaml
    /// </summary>
    public partial class Venceu : Window
    {
        private DispatcherTimer temporizador;
        private string currentColor;

        public Venceu()
        {
            InitializeComponent();

            SoundPlayer player = new SoundPlayer(@"sounds\venceu.wav");
            player.Load();
            player.Play();

            LabelTitle.Foreground = Brushes.Blue;
            currentColor = "Blue";

            temporizador = new DispatcherTimer();
            temporizador.Interval = TimeSpan.FromSeconds(1);
            temporizador.Tick += trocaCor;
            temporizador.Start();

        }

        private void ButtonEndGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void trocaCor(object sender, EventArgs e)
        {
            if (currentColor == "Blue")
            {
                LabelTitle.Foreground = new SolidColorBrush(Colors.Green);
                currentColor = "Green";
            }
            else if (currentColor == "Green")
            {
                LabelTitle.Foreground = new SolidColorBrush(Colors.Red);
                currentColor = "Red";
            }
            else if (currentColor == "Red")
            {
                LabelTitle.Foreground = new SolidColorBrush(Colors.Yellow);
                currentColor = "Yellow";
            }
            else
            {
                LabelTitle.Foreground = new SolidColorBrush(Colors.Blue);
                currentColor = "Blue";
            }
        }
    }
}
