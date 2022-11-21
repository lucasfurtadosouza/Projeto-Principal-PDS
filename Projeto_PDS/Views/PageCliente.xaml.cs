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
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageCliente.xam
    /// </summary>
    public partial class PageCliente : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        private Cliente _cliente = new Cliente();

        public PageCliente(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageCliente_Loaded;
        }
        public PageCliente(MainWindow mainWindow, PageRelatorio page, Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            _main = mainWindow;
            _page = page;

            Loaded += PageCliente_Loaded;
        }

        private void PageCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSexo();
            txtNome.Focus();
            txtNome.Text = _cliente.Nome;
            txtEmail.Text = _cliente.Email;
            txtCpf.Text = _cliente.Cpf;
            txtTelefone.Text = _cliente.Telefone;
            txtRua.Text = _cliente.Rua;
            txtBairro.Text = _cliente.Bairro;
            if(_cliente.Numero != 0)
            {
                txtNumero.Text = Convert.ToString(_cliente.Numero);
                cbSexo.SelectedValue = _cliente.Sexo.Id;
            }
            txtRg.Text = _cliente.Rg;
            dtDataNasc.SelectedDate = _cliente.DataNasc;
            txtRenda.Text = _cliente.RendaFamiliar;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Nome = txtNome.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Cpf = txtCpf.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.Rua = txtRua.Text;
            _cliente.Bairro = txtBairro.Text;
            _cliente.Numero = Convert.ToInt32(txtNumero.Text);
            _cliente.Rg = txtRg.Text;
            if (cbSexo.SelectedItem != null)
                _cliente.Sexo = cbSexo.SelectedItem as Sexo;

            if (dtDataNasc.SelectedDate != null)
                _cliente.DataNasc = dtDataNasc.SelectedDate;

            _cliente.RendaFamiliar = txtRenda.Text;

            try
            {
                var dao = new ClienteDAO();
                if (_cliente.Id > 0)
                {
                    dao.Update(_cliente);
                    var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                    messageUp.ShowDialog();
                    _page.OpenPageList("List_Cliente");
                }
                else
                {
                    dao.Insert(_cliente);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                }

                btLimpar_Click(sender, e);

            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro");
                messageError.ShowDialog();
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
        private void LoadSexo()
        {
            try
            {
                cbSexo.ItemsSource = new SexoDAO().List();
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }
    }
}
