using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Endless_Runner_WPF_MOO_ICT
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void modoInfinito_Click(object sender, RoutedEventArgs e)
        {
            MainWindow modoInfinito = new MainWindow();
            modoInfinito.Show();

            this.Close();
        }

        private void modoFases_Click(object sender, RoutedEventArgs e)
        {
            Fases modoFases = new Fases();
            modoFases.Show();

            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Ajuda tutorialModos = new Ajuda();
            tutorialModos.ShowDialog();

        }
    }
}
