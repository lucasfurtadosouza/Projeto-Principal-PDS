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
using Projeto_PDS.Helpers;
using Projeto_PDS.Models;
using System.Security.Cryptography;
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowNovoUsuario.xaml
    /// </summary>
    public partial class WindowNovoUsuario : Window
    {
        public WindowNovoUsuario()
        {
            InitializeComponent();
        }
        private Usuario _login = new Usuario();
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtSenha.Password.ToString() == "" && txtUsuario.Text == "")
            {
                MessageBox.Show("Digite um usuário ou senha válidos", "Usuário ou Senha inválidos", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                string HashPassword = getHashSha256(txtSenha.Password.ToString());
                _login.Senha = HashPassword;
                _login.Nome = txtUsuario.Text;
                
                _login.Permissao = cbPermissao.Text;
            }

            try
            {
                var dao = new UsuarioDAO();
                var daof = new FuncionarioDAO();

                if (_login.Id > 0)
                {
                    dao.Update(_login);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                    var form = new WindowLogin();
                    form.Show();
                    this.Close();

                }
                else
                {
                    dao.InsertPrimeiro(_login);
                    //daof.Insert2(_func);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                    var form = new WindowLogin();
                    form.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        /*public static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
        public static string SHA256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public static string CalcSaltedPass(string salt, string password)
        {
            return SHA256(salt + password);
        }*/
    }
}
