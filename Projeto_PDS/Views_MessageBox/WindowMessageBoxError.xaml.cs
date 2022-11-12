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

namespace Projeto_PDS.Views_MessageBox
{
    /// <summary>
    /// Lógica interna para WindowMessageBoxError.xaml
    /// </summary>
    public partial class WindowMessageBoxError : Window
    {
        private string _Titulo;
        private string _Mensagem;
        public WindowMessageBoxError(string Mensagem, string Titulo)
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

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
