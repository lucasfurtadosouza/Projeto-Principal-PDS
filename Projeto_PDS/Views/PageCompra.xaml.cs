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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageCompra.xam
    /// </summary>
    public partial class PageCompra : Page
    {
        private MainWindow _main;
        private PageRelatorio _page;

        public Compra _compra = new Compra();

        private List<CompraItem> _compraItensList = new List<CompraItem>();
        public PageCompra(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageCompra_Loaded;
        }
        public PageCompra(MainWindow mainWindow, PageRelatorio page, Compra compra)
        {
            InitializeComponent();
            _compra = compra;
            _main = mainWindow;
            _page = page;
            Loaded += PageCompra_Loaded;
        }
        private void PageCompra_Loaded(object sender, RoutedEventArgs e)
        {
            if (_compra.Id > 0)
            {
                txtValorTotal.Text = Convert.ToString(_compra.Valor);
                dtDataCompra.SelectedDate = _compra.Data;
                dtHoraCompra.SelectedTime = _compra.Hora;
                cbFormaPagamento.Text = _compra.FormaPagamento;
                cbFuncionario.SelectedItem = _compra.Funcionario;
                cbFornecedor.SelectedItem = _compra.Fornecedor;
            }
            else
            {
                LoadData();
            }
        }
        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowVendaProdutoListAdd();
            window.ShowDialog();

            var produtosSelecionadosList = window.ProdutosSelecionados;
            var count = 1;

            foreach (Produto produto in produtosSelecionadosList)
            {

                if (!_compraItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _compraItensList.Add(new CompraItem()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.ValorVenda,
                        ValorTotal = produto.ValorVenda
                    });

                    count++;
                }
            }
            LoadDataGrid();
        }

        private void BtnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGrid.SelectedItem as CompraItem;
            _compraItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as CompraItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                if (quantidade <= item.Produto.Estoque)
                {
                    item.Quantidade = quantidade;
                    item.ValorTotal = quantidade * item.Valor;
                }
                else
                {
                    var messageEstoque = new WindowMessageBoxAlerta("Não há estoque suficiente!", "Alerta de Quantidade");
                    messageEstoque.ShowDialog();
                }
            }

            LoadDataGrid();
        }
        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _compraItensList.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _compraItensList;
        }

        private void LoadData()
        {
            dtDataCompra.SelectedDate = DateTime.Now;
            dtHoraCompra.SelectedTime = DateTime.Now;

            try
            {
                cbFuncionario.ItemsSource = new FuncionarioDAO().List(null);
                cbFornecedor.ItemsSource = new FornecedorDAO().List(null);
                //comboBoxFuncionario.SelectedValue = Usuario.GetFuncionarioId();
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _compra.Valor = UpdateValorTotal();
            if (dtDataCompra.SelectedDate != null)
                _compra.Data = dtDataCompra.SelectedDate;

            if (dtHoraCompra.SelectedTime != null)
                _compra.Hora = dtHoraCompra.SelectedTime;

            if (cbFornecedor.SelectedItem != null)
                _compra.Fornecedor = cbFornecedor.SelectedItem as Fornecedor;

            if (cbFuncionario.SelectedItem != null)
                _compra.Funcionario = cbFuncionario.SelectedItem as Funcionario;

            _compra.Itens = _compraItensList;
            _compra.FormaPagamento = cbFormaPagamento.Text;
            _compra.Status = "Realizada";

            try
            {
                var dao = new CompraDAO();
                dao.Insert(_compra);
                var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                message.ShowDialog();
                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro");
                messageError.ShowDialog();
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbFornecedor.SelectedIndex = -1;
            cbFuncionario.SelectedIndex = -1;
            cbFormaPagamento.SelectedIndex = -1;
            txtValorTotal.Clear();
            dataGrid.ItemsSource = null;
            LoadData();
        }
    }
}
