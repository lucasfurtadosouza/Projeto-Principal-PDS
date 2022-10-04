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

namespace Projeto_PDS.Views.PageList
{
    /// <summary>
    /// Interação lógica para PageProdutoList.xam
    /// </summary>
    public partial class PageProdutoList : Page
    {
        public PageProdutoList()
        {
            InitializeComponent();
            Loaded += ProdutoListWindow_Loaded;
        }

        private void ProdutoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelecionado = dtProduto.SelectedItem as Produto;
            var resultado = MessageBox.Show($"Deseja realmente excluir o produto '{produtoSelecionado.Nome}'?", "Confirmar Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
                    dao.Delete(produtoSelecionado);

                    MessageBox.Show("Registro deletado com sucesso!");
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Atualizar_Click(Object sender, RoutedEventArgs e)
        {
            var produtoSelecionado = dtProduto.SelectedItem as Produto;
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new ProdutoDAO();
                List<Produto> listaProdutos = dao.List();

                dtProduto.ItemsSource = listaProdutos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.MainWindow();
            form.Show();
        }

        private void btCarregar_Click(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
    }
}
