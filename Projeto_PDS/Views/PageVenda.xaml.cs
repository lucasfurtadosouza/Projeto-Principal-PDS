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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageVenda.xam
    /// </summary>
    public partial class PageVenda : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Venda _venda = new Venda();

        private List<VendaItem> _vendaItensList = new List<VendaItem>();
        public PageVenda(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageVenda_Loaded;
        }
        public PageVenda(MainWindow mainWindow, PageRelatorio page, Venda venda)
        {
            InitializeComponent();
            _venda = venda;
            _main = mainWindow;
            _page = page;
            Loaded += PageVenda_Loaded;
        }
        private void PageVenda_Loaded(object sender, RoutedEventArgs e)
        {
            if (_venda.Id > 0)
            {
                txtValorTotal.Text = Convert.ToString(_venda.Valor);
                dtDataVenda.SelectedDate = _venda.Data;
                dtHoraVenda.SelectedTime = _venda.Hora;
                cbFormaPagamento.Text = _venda.FormaPagamento;
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

                if (!_vendaItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _vendaItensList.Add(new VendaItem()
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
            var itemSelected = dataGrid.SelectedItem as VendaItem;
            _vendaItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;
            }

            LoadDataGrid();
        }
        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _vendaItensList.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _vendaItensList;
        }

        private void LoadData()
        {
            dtDataVenda.SelectedDate = DateTime.Now;
            dtHoraVenda.SelectedTime = DateTime.Now;

            try
            {
                cbFuncionario.ItemsSource = new FuncionarioDAO().List();
                cbCliente.ItemsSource = new ClienteDAO().List();
                //comboBoxFuncionario.SelectedValue = Usuario.GetFuncionarioId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _venda.Valor = Convert.ToDouble(txtValorTotal.Text);
            if (dtDataVenda.SelectedDate != null)
            {
                _venda.Data = dtDataVenda.SelectedDate;
            }
            if (dtHoraVenda.SelectedTime != null)
            {
                _venda.Hora = dtHoraVenda.SelectedTime;
            }
            _venda.FormaPagamento = cbFormaPagamento.Text;

            try
            {
                var dao = new VendaDAO();
                if (_venda.Id > 0)
                {
                    //dao.Update(_venda);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //dao.Insert(_venda);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbCliente.SelectedIndex = -1;
            cbFuncionario.SelectedIndex = -1;
            cbFormaPagamento.SelectedIndex = -1;
            txtValorTotal.Clear();
            dataGrid.ItemsSource = null;
            LoadData();
            //txtFormaPagamento.Clear();
        }

    }
}
