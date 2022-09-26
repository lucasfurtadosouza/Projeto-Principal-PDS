﻿using System;
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
            if (txtSenha.Text == "" && txtUsuario.Text == "")
            {
                MessageBox.Show("Digite um usuário ou senha válidos", "Usuário ou Senha inválidos", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                //string salt = getSalt();
                //string HashPassword = CalcSaltedPass(salt, txtSenha.Text);
                //string HashUsuario = CalcSaltedPass(salt, txtUsuario.Text);
                string HashUsuario = getHashSha256(txtUsuario.Text);
                string HashPassword = getHashSha256(txtSenha.Text);

                MessageBox.Show(HashUsuario);
                MessageBox.Show(HashPassword);
                if (HashUsuario == _login.Nome && HashPassword == _login.Senha)
                {
                    var form = new MainWindow();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Digite um usuário ou senha válidos", "Usuário ou Senha inválidos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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