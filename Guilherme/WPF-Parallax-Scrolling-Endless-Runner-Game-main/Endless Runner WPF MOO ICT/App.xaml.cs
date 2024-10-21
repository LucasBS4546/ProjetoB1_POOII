using System.Configuration;
using System.Data;
using System.Windows;

namespace Endless_Runner_WPF_MOO_ICT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            StartWindow startWindow = new StartWindow();
            startWindow.Show();

        }
    }

}
