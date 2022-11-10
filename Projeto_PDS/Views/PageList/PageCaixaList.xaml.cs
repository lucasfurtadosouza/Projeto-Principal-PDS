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
using Projeto_PDS.Views;
using Projeto_PDS.Models;
using System.Web.UI.WebControls;

namespace Projeto_PDS.Views.PageList
{
    /// <summary>
    /// Interação lógica para PageCaixaList.xam
    /// </summary>
    public partial class PageCaixaList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageCaixaList()
        {
            InitializeComponent(); 
            Loaded += CaixaListWindow_Loaded;
        }
        public PageCaixaList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += CaixaListWindow_Loaded;
            _main = main;
            _page = page;
        }

        private void CaixaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var caixaSelecionada = dtCaixa.SelectedItem as Caixa;
            var resultado = MessageBox.Show($"Deseja realmente excluir o caixa '{caixaSelecionada.Id}'?", "Confirmar Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new CaixaDAO();
                    dao.Delete(caixaSelecionada);

                    MessageBox.Show("Registro deletado com sucesso!");
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
            var caixaSelecionada = dtCaixa.SelectedItem as Caixa;
            _page.frameRelatorio.Content = new PageCaixa(_main, _page, caixaSelecionada);
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new CaixaDAO();
                List<Caixa> listaCaixas = dao.List();

                dtCaixa.ItemsSource = listaCaixas;

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
        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            var text = txtBuscar.Text;
            var dao = new CaixaDAO();
            List<Caixa> listaCaixas = dao.List();
            var filteredList = listaCaixas.Where(i => i.Id.ToString().Contains(text));
            dtCaixa.ItemsSource = filteredList;
        }
        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Clear();
            CarregarListagem();
        }
    }
}
