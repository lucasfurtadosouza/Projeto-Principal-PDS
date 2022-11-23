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

            string HashPassword = getHashSha256(txtSenha.Password.ToString());
            _usuario.Senha = HashPassword;
            _usuario.Nome = txtUsuario.Text;
            try
            {
                var dao = new UsuarioDAO();
                if (HashPassword != "")
                {
                    if(dao.Login(_usuario))
                    {

                        MainWindow window = new MainWindow(_usuario);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        var message = new WindowMessageBoxError("Usuário ou senha incorreto.", "Erro");
                        message.Show();
                    }
                }
                else
                {
                    var message = new WindowMessageBoxCerto("Deu ruim", "Ferrou");
                    message.Show();
                    //MessageBox.Show(HashPassword);
                }
            }catch (Exception ex) 
            {
                var message = new WindowMessageBoxError(ex.Message, "Erro");
                message.Show();
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
