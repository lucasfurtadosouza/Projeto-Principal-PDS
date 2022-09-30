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
    /// Interação lógica para PageProduto.xam
    /// </summary>
    public partial class PageProduto : Page
    {
        public Produto _produto = new Produto();
        public PageProduto()
        {
            InitializeComponent();
        }

        public PageProduto(Produto produto)
        {
            _produto = produto;
            InitializeComponent();
            Loaded += WindowProduto_Loaded;
        }
        private void WindowProduto_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Focus();
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
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new WindowCaixaList();
                    form.Show();
                }
                else
                {
                    dao.Insert(_produto);
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
            txtValorCompra.Clear();
            txtValorVenda.Clear();
            txtEstoque.Clear();
            txtDescricao.Clear();
        }
    }
}
