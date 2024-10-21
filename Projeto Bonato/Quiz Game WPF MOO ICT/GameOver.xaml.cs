using System;
using System.Collections.Generic;
using System.IO;
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

namespace Quiz_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer(@"sounds\errou.wav");
            player.Load();
            player.Play();
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
