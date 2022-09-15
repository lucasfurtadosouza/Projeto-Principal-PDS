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
            _login.Nome = txtUsuario.Text;
            _login.Senha = txtSenha.Text;
            try
            {
                var dao = new UsuarioDAO();
                if (_login.Id > 0)
                {
                    dao.Hash(_login);
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

        }
    }
}
