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
        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            if(txtSenha.Text == "" && txtUsuario.Text == "")
            {
                MessageBox.Show("Digite um usuário ou senha válidos", "Usuário ou Senha inválidos", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                string salt = getSalt();
                string HashPassword = CalcSaltedPass(salt, txtSenha.Text);
                string HashUsuario = CalcSaltedPass(salt, txtUsuario.Text);
                _login.Senha = HashPassword;
                _login.Nome = HashUsuario;
                _login.Permissao = cbPermissao.Text;
                MessageBox.Show(HashUsuario);
                MessageBox.Show(HashPassword);
            }
            

            try
            {
                var dao = new UsuarioDAO();
                if (_login.Id > 0)
                {
                    dao.Update(_login);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new Projeto_PDS.Views.WindowClienteList();
                    form.Show();
                }
                else
                {
                    dao.Insert(_login);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string getSalt()
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
        }

    }
}
