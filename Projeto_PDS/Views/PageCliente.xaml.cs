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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projeto_PDS.Models;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageCliente.xam
    /// </summary>
    public partial class PageCliente : Page
    {
        public PageCliente()
        {
            InitializeComponent();
        }

        private Cliente _cliente = new Cliente();

        public PageCliente(Cliente cliente)
        {
            _cliente = cliente;
            InitializeComponent();
            Loaded += ClienteWindow_Loaded;
        }
        private void ClienteWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Nome = txtNome.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Cpf = txtCpf.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.Rua = txtRua.Text;
            _cliente.Bairro = txtRua.Text;
            _cliente.Numero = txtRua.Text;
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
                if (_cliente.Id > 0)
                {
                    dao.Update(_cliente);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new Projeto_PDS.Views.WindowClienteList();
                    form.Show();
                }
                else
                {
                    dao.Insert(_cliente);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
