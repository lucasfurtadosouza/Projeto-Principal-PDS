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
    /// Interação lógica para PageProduto.xam
    /// </summary>
    public partial class PageProduto : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Produto _produto = new Produto();

        public PageProduto(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += WindowProduto_Loaded;
        }
        public PageProduto(MainWindow mainWindow, PageRelatorio page, Produto produto)
        {
            InitializeComponent();
            _produto = produto;
            _main = mainWindow;
            _page = page;

            Loaded += WindowProduto_Loaded;
        }
        private void WindowProduto_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Focus();
            txtNome.Text = _produto.Nome;
            if(_produto.ValorCompra != 0)
            {
                txtValorCompra.Text = Convert.ToString(_produto.ValorCompra);
            }
            if (_produto.ValorVenda != 0)
            {
                txtValorVenda.Text = Convert.ToString(_produto.ValorVenda);
            }
            if (_produto.Estoque != 0)
            {
                txtEstoque.Text = Convert.ToString(_produto.Estoque);
            }
            txtDescricao.Text= _produto.Descricao;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _produto.Nome = txtNome.Text;
            _produto.ValorCompra = Convert.ToDouble(txtValorCompra.Text);
            _produto.ValorVenda = Convert.ToDouble(txtValorVenda.Text);
            _produto.Estoque = Convert.ToInt32(txtEstoque.Text);
            _produto.Descricao = txtDescricao.Text;
            _produto.Foto = null;

            try
            {
                var dao = new ProdutoDAO();
                if (_produto.Id > 0)
                {
                    dao.Update(_produto);
                    var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                    messageUp.Show();
                    _page.OpenPageList("List_Produto");
                }
                else
                {
                    dao.Insert(_produto);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.Show();
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
            txtValorCompra.Clear();
            txtValorVenda.Clear();
            txtEstoque.Clear();
            txtDescricao.Clear();
        }
    }
}
