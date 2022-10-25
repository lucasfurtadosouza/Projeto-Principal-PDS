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
        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelecionado = dtFuncionario.SelectedItem as Funcionario;
            var resultado = MessageBox.Show($"Deseja realmente excluir o funcionário '{funcionarioSelecionado.Nome}'?", "Confirmar Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionarioSelecionado);

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
            var funcionarioSelecionado = dtFuncionario.SelectedItem as Funcionario;
            _page.frameRelatorio.Content = new PageFuncionario(_main, _page, funcionarioSelecionado);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new FuncionarioDAO();
                List<Funcionario> listaFuncionario = dao.List();

                dtFuncionario.ItemsSource = listaFuncionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
