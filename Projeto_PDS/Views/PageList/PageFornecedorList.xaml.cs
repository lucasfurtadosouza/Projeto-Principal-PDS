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
    /// Interação lógica para PageFornecedorList.xam
    /// </summary>
    public partial class PageFornecedorList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageFornecedorList()
        {
            InitializeComponent(); 
            Loaded += FornecedorListWindow_Loaded;
        }
        public PageFornecedorList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += FornecedorListWindow_Loaded;
            _main = main;
            _page = page;
        }

        private void FornecedorListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var FornecedorSelecionado = dtFornecedor.SelectedItem as Fornecedor;
            var resultado = MessageBox.Show($"Deseja realmente excluir o fornecedor '{FornecedorSelecionado.Razao}'?", "Confirmar Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(FornecedorSelecionado);

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
            var fornecedorSelecionada = dtFornecedor.SelectedItem as Fornecedor;
            _page.frameRelatorio.Content = new PageFornecedor(_main, _page, fornecedorSelecionada);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new FornecedorDAO();
                List<Fornecedor> listaFornecedores = dao.List();

               dtFornecedor.ItemsSource = listaFornecedores;

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
