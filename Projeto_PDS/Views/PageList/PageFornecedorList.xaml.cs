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
        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var FornecedorSelecionado = dtFornecedor.SelectedItem as Fornecedor;
            var message = new WindowMessageBoxPergunta($"Deseja realmente excluir o Fornecedor '{FornecedorSelecionado.Nome}'?", "Confirmar Exclusão");
            message.ShowDialog();
            var resultado = message.retorno;
            try
            {
                if (resultado != false)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(FornecedorSelecionado);

                    var messageCheck = new WindowMessageBoxCerto("Registro deletado com sucesso!", "Registro Excluído");
                    messageCheck.ShowDialog();
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btAtualizar_Click(Object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionada = dtFornecedor.SelectedItem as Fornecedor;
            _page.frameRelatorio.Content = new PageFornecedor(_main, _page, fornecedorSelecionada);
        }
        private void CarregarListagem()
        {
            try
            {
                string busca = txtBuscar.Text;
                var dao = new FornecedorDAO();
                List<Fornecedor> listaFornecedores = dao.List(busca);

               dtFornecedor.ItemsSource = listaFornecedores;

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
