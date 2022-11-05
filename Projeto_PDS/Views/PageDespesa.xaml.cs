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
    /// Interação lógica para PageDespesa.xam
    /// </summary>
    public partial class PageDespesa : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Despesa _despesa = new Despesa();

        public PageDespesa(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageDespesa_Loaded;
        }

        public PageDespesa(MainWindow mainWindow, PageRelatorio page, Despesa despesa)
        {
            InitializeComponent();
            _despesa = despesa;
            _main = mainWindow;
            _page = page;

            Loaded += PageDespesa_Loaded;
        }
        private void PageDespesa_Loaded(object sender, RoutedEventArgs e)
        {
            txtValor.Focus();
            if(_despesa.Valor != 0)
            {
                txtValor.Text = Convert.ToString(_despesa.Valor);
            }
            dtDataVen.SelectedDate = _despesa.Data_Vencimento;
            dtDataPag.SelectedDate = _despesa.Data_Pagamento;
            txtFormaPagamento.Text = _despesa.Forma_Pagamento;
            txtDescricao.Text = _despesa.Descricao;
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _despesa.Valor = Convert.ToDouble(txtValor.Text);
            if (dtDataVen.SelectedDate != null)
            {
                _despesa.Data_Vencimento = dtDataVen.SelectedDate;
            }
            if (dtDataVen.SelectedDate != null)
            {
                _despesa.Data_Pagamento = dtDataPag.SelectedDate;
            }
            _despesa.Forma_Pagamento = txtFormaPagamento.Text;
            _despesa.Descricao = txtDescricao.Text;

            try
            {
                var dao = new DespesaDAO();
                if (_despesa.Id > 0)
                {
                    dao.Update(_despesa);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    _page.OpenPageList("List_Despesa");

                }
                else
                {
                    dao.Insert(_despesa);
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
            txtValor.Clear();
            txtFormaPagamento.Clear();
            txtDescricao.Clear();
            dtDataVen.SelectedDate = null;
            dtDataPag.SelectedDate = null;
        }

    }
}
