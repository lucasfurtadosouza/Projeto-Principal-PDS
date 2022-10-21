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
using Projeto_PDS.DataBase;
using MySql.Data.MySqlClient;
using Projeto_PDS.Models;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowCliente.xaml
    /// </summary>
    public partial class WindowCliente : Window
    {
        private Cliente _cliente = new Cliente();
        public WindowCliente()
        {
            InitializeComponent();
        }

        public WindowCliente(Cliente cliente)
        {
            _cliente = cliente;
            InitializeComponent();
            Loaded += ClienteWindow_Loaded;
        }
        private void ClienteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cliente.Nome;
            txtEmail.Text = _cliente.Email;
            txtCpf.Text = _cliente.Cpf;
            txtTelefone.Text = _cliente.Telefone;
            txtRua.Text = _cliente.Rua;
            txtBairro.Text = _cliente.Bairro;
            txtNumero.Text = _cliente.Numero;
            txtRg.Text = _cliente.Rg;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Nome = txtNome.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Cpf = txtCpf.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.Rua = txtRua.Text;
            _cliente.Bairro = txtBairro.Text;
            _cliente.Numero = txtNumero.Text;
            _cliente.Rg = txtRg.Text;

            if (dtDataNasc.SelectedDate != null)
            {
                _cliente.DataNasc = (DateTime)dtDataNasc.SelectedDate;
            }

            _cliente.Sexo = cbSexo.Text;
            _cliente.RendaFamiliar = txtRenda.Text;

            try
            {
                var dao = new ClienteDAO();
                dao.Update(_cliente);
                MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                
                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtRg.Clear();
            txtRenda.Clear();
            dtDataNasc.SelectedDate = null;
            cbSexo.SelectedIndex = -1;
        }
    }
}