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
using Projeto_PDS.Models;
using Projeto_PDS.Views;
using System.Security.Cryptography;
using Projeto_PDS.Helpers;

namespace Projeto_PDS
{
    /// <summary>
    /// Lógica interna para WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            Loaded += WindowLogin_Loaded;
        }
        private Usuario _login = new Usuario();
        private void WindowLogin_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new UsuarioDAO();
                List<Usuario> listaUsuario = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUsuario.Text;
            string senha = txtSenha.Password.ToString();

            if (SessionHelper.Login(email, senha))
            {
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                _ = txtUsuario.Focus();
            }
        }
    }
}
