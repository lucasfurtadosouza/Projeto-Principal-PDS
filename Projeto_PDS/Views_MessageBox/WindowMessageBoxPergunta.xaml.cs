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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projeto_PDS.Views_MessageBox
{
    /// <summary>
    /// Lógica interna para WindowMessageBoxPergunta.xaml
    /// </summary>
    public partial class WindowMessageBoxPergunta : Window
    {
        public bool retorno;
        private string _Titulo;
        private string _Mensagem;
        public WindowMessageBoxPergunta(string Mensagem, string Titulo)
        {
            InitializeComponent();
            _Titulo = Titulo;
            _Mensagem = Mensagem;
            Loaded += WindowMessageBox_Loaded;
        }
        private void WindowMessageBox_Loaded(object sender, RoutedEventArgs e)
        {
            txtTitulo.Text = _Titulo;
            txtMensagem.Text = _Mensagem;
        }

        private void btnYES_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            retorno = true;
            
        }
        private void btnNO_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            retorno = false;
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            retorno = false;

        }
    }
}
