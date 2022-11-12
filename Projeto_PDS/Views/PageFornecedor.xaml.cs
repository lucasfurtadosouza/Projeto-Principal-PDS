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
using Projeto_PDS.DataBase;
using Projeto_PDS.Views.PageList;
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowFornecedor.xaml
    /// </summary>
    public partial class PageFornecedor : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Fornecedor _fornecedor = new Fornecedor();

        public PageFornecedor(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageFornecedor_Loaded;
        }
        
        public PageFornecedor(MainWindow mainWindow, PageRelatorio page, Fornecedor fornecedor)
        {
            InitializeComponent();
            _fornecedor = fornecedor;
            _main = mainWindow;
            _page = page;

            Loaded += PageFornecedor_Loaded;
        }

        private void PageFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Focus();
            txtNome.Text = _fornecedor.Nome;
            txtRazao.Text = _fornecedor.Razao;
            txtCnpj.Text = _fornecedor.Cnpj;
            txtEmail.Text = _fornecedor.Email;
            txtRua.Text = _fornecedor.Rua;
            if(_fornecedor.Numero != 0)
            {
                txtNumero.Text = Convert.ToString(_fornecedor.Numero);
            }
            txtBairro.Text =_fornecedor.Bairro;
            txtTelefone.Text = _fornecedor.Telefone;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            //_main.setPageMain();
            //_main.OpenPage("MN_Relatorio");

            _fornecedor.Nome = txtNome.Text;
            _fornecedor.Razao = txtRazao.Text;
            _fornecedor.Cnpj = txtCnpj.Text;
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.Rua = txtRua.Text;
            _fornecedor.Numero = Convert.ToInt32(txtNumero.Text);
            _fornecedor.Bairro = txtBairro.Text;
            _fornecedor.Telefone = txtTelefone.Text;

            try
            {
                var dao = new FornecedorDAO();
                if (_fornecedor.Id > 0)
                {
                    dao.Update(_fornecedor);
                    var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                    messageUp.ShowDialog();
                    _page.OpenPageList("List_Fornecedor");
                }
                else
                {
                    dao.Insert(_fornecedor);
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
            txtRazao.Clear();
            txtCnpj.Clear();
            txtEmail.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtTelefone.Clear();
        }
    }
}
