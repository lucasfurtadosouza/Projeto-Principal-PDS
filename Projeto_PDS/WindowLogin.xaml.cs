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
using Projeto_PDS.Views_MessageBox;

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
            this.WindowStyle = WindowStyle.None;


        }
        private Usuario _usuario = new Usuario();
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
         
            string senha;
            string usuario;
            string HashPassword = getHashSha256(txtSenha.Password.ToString());
            usuario = txtUsuario.Text;
            _usuario.buscar = usuario; 
            
            senha = HashPassword;
          
                    try
                    {
                        string busca = txtUsuario.Text;
                        var dao = new UsuarioDAO();
                        List<Usuario> listaUsuario = dao.List3(busca);
                        dao.GetByControle();
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            if (_usuario.Nome != usuario && _usuario.Senha != senha)
            {
                var form = new MainWindow();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro");
            }




        }
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
