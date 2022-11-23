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
using Projeto_PDS.Views;
using System.Windows.Navigation;
using System.Windows.Threading;
using Projeto_PDS;
using Projeto_PDS.Models;

namespace Projeto_PDS
{
    /// <summary>
    /// Lógica interna para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window

    {
        Usuario _login = new Usuario();
        public SplashScreen()
        {
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("Projeto_PDS")) + @"Projeto_PDS\Imagens_Videos\VideoLogo1.mp4");
            Loading();
        }
        DispatcherTimer timer = new DispatcherTimer();
        public int chave;
        public bool verdade;
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {

        }
        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            UsuarioDAO verificar = new UsuarioDAO();
            _login.Id = verificar.Verificar();
            chave = _login.Id;
            if (chave > 0)
            {
                verdade = true;
                var form = new WindowLogin();
                form.Show();
                this.Close();
            }
            else
            {
                verdade = false;
                var form = new WindowTermos();
                form.Show();
                this.Close();
            }
        }
        void Loading()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Start();
        }
    }
}
