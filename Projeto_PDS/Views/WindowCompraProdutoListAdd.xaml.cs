using Projeto_PDS.Models;
using Projeto_PDS.Views_MessageBox;
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
using System.Windows.Shapes;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowCompraProdutoListAdd.xaml
    /// </summary>
    public partial class WindowCompraProdutoListAdd : Window
    {
        private List<Produto> _produtosList = new List<Produto>();
        public List<Produto> ProdutosSelecionados { get; private set; } = new List<Produto>();
        public WindowCompraProdutoListAdd()
        {
            InitializeComponent();
            Loaded += VendaProdutoListAdd_Loaded;
        }
        private void VendaProdutoListAdd_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var text = txtSearch.Text;

            var filteredList = _produtosList.Where(i => i.Nome.ToLower().Contains(text));
            dataGrid.ItemsSource = filteredList;
        }
        private void BtnAdicionarProdutos_Click(object sender, RoutedEventArgs e)
        {
            var itens = dataGrid.Items;
            ProdutosSelecionados.Clear();

            foreach (Produto produto in itens)
            {
                if (produto.IsSelected)
                    ProdutosSelecionados.Add(produto);
            }

            if (ProdutosSelecionados.Count == 0)
            {
                var messageAlerta = new WindowMessageBoxAlerta("Nenhum produto foi selecionado!", "Seleção Vazia");
                messageAlerta.ShowDialog();
            }
            this.Close();
        }
        private void LoadDataGrid()
        {
            try
            {
                _produtosList = new ProdutoDAO().List(null);
                dataGrid.ItemsSource = _produtosList;

            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageError.ShowDialog();
            }
        }
        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
