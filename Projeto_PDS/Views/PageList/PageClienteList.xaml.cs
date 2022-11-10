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
    /// Interação lógica para PageClienteList.xam
    /// </summary>
    public partial class PageClienteList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageClienteList()
        {
            InitializeComponent();
            Loaded += PageClienteList_Loaded;
        }
        public PageClienteList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += PageClienteList_Loaded;
            _main = main;
            _page = page;
        }

        private void PageClienteList_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelecionado = dtCliente.SelectedItem as Cliente;
            var resultado = MessageBox.Show($"Deseja realmente excluir o cliente '{clienteSelecionado.Nome}'?", "Confirmar Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(clienteSelecionado);

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
            var clienteSelecionado = dtCliente.SelectedItem as Cliente;
            _page.frameRelatorio.Content = new PageCliente(_main, _page, clienteSelecionado);

        }

        private void CarregarListagem()
        {
            try
            {
                string busca = txtBuscar.Text;
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List(busca);

                dtCliente.ItemsSource = listaClientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
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
