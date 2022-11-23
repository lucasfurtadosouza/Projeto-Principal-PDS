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
    /// Interação lógica para PageFuncionarioList.xam
    /// </summary>
    public partial class PageFuncionarioList : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public PageFuncionarioList()
        {
            InitializeComponent();
            Loaded += PageFuncionarioList_Loaded;
        }
        public PageFuncionarioList(MainWindow main, PageRelatorio page)
        {
            InitializeComponent();
            Loaded += PageFuncionarioList_Loaded;
            _main = main;
            _page = page;
        }

        private void PageFuncionarioList_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void btRemover_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelecionado = dtFuncionario.SelectedItem as Funcionario;
            var message = new WindowMessageBoxPergunta($"Deseja realmente excluir o Funcionário '{funcionarioSelecionado.Nome}'?", "Confirmar Exclusão");
            message.ShowDialog();
            var resultado = message.retorno;
            try
            {
                if (resultado != false)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionarioSelecionado);

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
            var funcionarioSelecionado = dtFuncionario.SelectedItem as Funcionario;
            _page.frameRelatorio.Content = new PageFuncionario(_main, _page, funcionarioSelecionado);
        }
        private void CarregarListagem()
        {
            try
            {
                string busca = txtBuscar.Text;
                var dao = new FuncionarioDAO();
                List<Funcionario> listaFuncionario = dao.List(busca);

                dtFuncionario.ItemsSource = listaFuncionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
