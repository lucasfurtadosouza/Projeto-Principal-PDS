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
    /// Interação lógica para PageDespesaList.xam
    /// </summary>
    public partial class PageDespesaList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageDespesaList()
        {
            InitializeComponent(); 
            Loaded += DespesaListWindow_Loaded;
        }
        public PageDespesaList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += DespesaListWindow_Loaded;
            _main = main;
            _page = page;
        }

        private void DespesaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelecionada = dtDespesa.SelectedItem as Despesa;
            var message = new WindowMessageBoxPergunta($"Deseja realmente excluir a Despesa '{despesaSelecionada.Id}'?", "Confirmar Exclusão");
            message.ShowDialog();
            var resultado = message.retorno;
            try
            {
                if (resultado != false)
                {
                    var dao = new DespesaDAO();
                    dao.Delete(despesaSelecionada);

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
            var despesaSelecionada = dtDespesa.SelectedItem as Despesa;
            _page.frameRelatorio.Content = new PageDespesa(_main, _page, despesaSelecionada);

        }
        private void CarregarListagem()
        {
            try
            {
                string busca = txtBuscar.Text;
                var dao = new DespesaDAO();
                List<Despesa> listaDespesas = dao.List(busca);

                dtDespesa.ItemsSource = listaDespesas;

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
