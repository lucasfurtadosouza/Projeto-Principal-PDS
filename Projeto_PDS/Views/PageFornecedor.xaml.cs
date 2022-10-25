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
            Loaded += WindowFornecedor_Loaded;
        }
        
        public PageFornecedor(MainWindow mainWindow, PageRelatorio page, Fornecedor fornecedor)
        {
            InitializeComponent();
            _fornecedor = fornecedor;
            _main = mainWindow;
            _page = page;

            Loaded += WindowFornecedor_Loaded;
        }

        private void WindowFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            
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
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    _page.OpenPageList("List_Fornecedor");
                }
                else
                {
                    dao.Insert(_fornecedor);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

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
