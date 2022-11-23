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
using System.Security.Cryptography;
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowUsuario.xaml
    /// </summary>
    public partial class WindowUsuario : Window
    {
        public Usuario _usuario = new Usuario();
        public WindowUsuario()
        {
            InitializeComponent();
            Loaded += WindowUsuario_Loaded;
        }
        public WindowUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Loaded += WindowUsuario_Loaded;
        }
        private void WindowUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _usuario.Nome;
            cbFuncionario.SelectedItem = _usuario.Funcionario;
            LoadFuncionario();
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            string HashPassword = getHashSha256(txtSenha.Password.ToString());
            _usuario.Senha = HashPassword;
            _usuario.Nome = txtNome.Text;
            _usuario.Permissao = cbPermissao.Text;
            if (cbFuncionario.SelectedItem != null)
                _usuario.Funcionario = cbFuncionario.SelectedItem as Funcionario;

            try
            {
                var dao = new UsuarioDAO();
                if (_usuario.Id > 0)
                {
                    if (_usuario.Nome == "admin")
                    {
                        var messageError = new WindowMessageBoxError("Não é possivel atualizar o usuário Admin" , "Erro");
                        messageError.ShowDialog();
                    }
                    else
                    {
                        dao.Update(_usuario);
                        var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                        messageUp.ShowDialog();
                    }
                }
                else
                {
                    dao.Insert(_usuario);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                }

                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                //var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro");
                //messageError.ShowDialog();
                var messageError = new WindowMessageBoxError("Não é possivel atualizar o usuário Admin e " + ex.Message, "Erro");
                messageError.ShowDialog();
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbFuncionario.SelectedIndex = -1;
            cbPermissao.SelectedIndex = -1;
            txtNome.Clear();
            txtSenha.Clear();
        }
        private void LoadFuncionario()
        {
            try
            {
                cbFuncionario.ItemsSource = new FuncionarioDAO().List(null);
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
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
