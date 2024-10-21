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

namespace Quiz_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para Introducao.xaml
    /// </summary>
    public partial class Introducao : Window
    {
        public Introducao()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
