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

namespace Projeto_PDS.Views.PageList
{
    /// <summary>
    /// Interação lógica para PageProdutoList.xam
    /// </summary>
    public partial class PageProdutoList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageProdutoList()
        {
            InitializeComponent();
            Loaded += ProdutoListWindow_Loaded;
        }
        public PageProdutoList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += ProdutoListWindow_Loaded;
            _main = main;
            _page = page;
        }

        private void ProdutoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelecionado = dtProduto.SelectedItem as Produto;
            var message = new WindowMessageBoxPergunta($"Deseja realmente excluir o Produto '{produtoSelecionado.Nome}'?", "Confirmar Exclusão");
            message.ShowDialog();
            var resultado = message.retorno;
            try
            {
                if (resultado != false)
                {
                    {
                    var dao = new ProdutoDAO();
                    dao.Delete(produtoSelecionado);

                        var messageCheck = new WindowMessageBoxCerto("Registro deletado com sucesso!", "Registro Excluído");
                        messageCheck.ShowDialog();
                        CarregarListagem();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btAtualizar_Click(Object sender, RoutedEventArgs e)
        {
            var produtoSelecionado = dtProduto.SelectedItem as Produto;
            _page.frameRelatorio.Content = new PageProduto(_main, _page, produtoSelecionado);
        }
        private void CarregarListagem()
        {
            try
            {
                string busca = txtBuscar.Text;
                var dao = new ProdutoDAO();
                List<Produto> listaProdutos = dao.List(busca);

                dtProduto.ItemsSource = listaProdutos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCarregar_Click(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Clear();
            CarregarListagem();
        }
    }
}
