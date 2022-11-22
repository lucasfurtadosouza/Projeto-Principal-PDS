using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageFecharCaixa.xam
    /// </summary>
    public partial class PageFecharCaixa : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Caixa _caixa = new Caixa();

        public PageFecharCaixa(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += WindowCaixa_Loaded;
        }

        public PageFecharCaixa(MainWindow mainWindow, PageRelatorio page, Caixa caixa)
        {
            InitializeComponent();
            _caixa = caixa;
            _main = mainWindow;
            _page = page;
            Loaded += WindowCaixa_Loaded;
        }

        private void WindowCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            cbCaixa.Focus();
            LoadCaixaAberto();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbCaixa.SelectedIndex != -1)
                {
                    if (cbStatus.Text == "Fechado")
                    {
                        _caixa.Id = Convert.ToInt32(cbCaixa.SelectedValue);
                        _caixa.SaldoFinal = Convert.ToDouble(txtSaldoFinal.Text);
                        if (dtDataFechamento.SelectedDate != null)
                        {
                            _caixa.DataFechamento = dtDataFechamento.SelectedDate;
                        }
                        if (dtHoraFechamento.SelectedTime != null)
                        {
                            _caixa.HoraFechamento = dtHoraFechamento.SelectedTime;
                        }
                        _caixa.QuantidadePagamentos = Convert.ToInt32(txtQuantidadePagamentos.Text);
                        _caixa.QuantidadeRecebimentos = Convert.ToInt32(txtQuantidadeRecebimentos.Text);
                        _caixa.Status = cbStatus.Text;

                        var dao = new CaixaDAO();
                        dao.FecharCaixa(_caixa);
                        var messageUp = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Caixa Fechado");
                        messageUp.ShowDialog();
                        LoadCaixaAberto();
                        btLimpar_Click(sender, e);
                    }
                    else
                    {
                        var messageAlert = new WindowMessageBoxAlerta("O Status do Caixa está Vazio!", "Status Vazio");
                        messageAlert.ShowDialog();
                    }
                }
                else
                {
                    var messageAlert = new WindowMessageBoxAlerta("O Caixa não foi selecionado!", "Caixa Não Selecionado");
                    messageAlert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro");
                messageError.ShowDialog();
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbCaixa.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            txtSaldoFinal.Clear();
            dtDataFechamento.SelectedDate = DateTime.Now;
            dtHoraFechamento.SelectedTime = DateTime.Now;
            txtQuantidadePagamentos.Clear();
            txtQuantidadeRecebimentos.Clear();
        }
        private void LoadCaixaAberto()
        {
            try
            {
                cbCaixa.ItemsSource = new CaixaDAO().ListCaixaAberto();
                dtDataFechamento.SelectedDate = DateTime.Now;
                dtHoraFechamento.SelectedTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }

        private void cbCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbCaixa.SelectedIndex != -1)
                {
                    var caixaSelecionado = cbCaixa.SelectedItem as Caixa;

                    txtSaldoFinal.Text = Convert.ToString(caixaSelecionado.SaldoFinal);
                    txtQuantidadePagamentos.Text = Convert.ToString(caixaSelecionado.QuantidadePagamentos);
                    txtQuantidadeRecebimentos.Text = Convert.ToString(caixaSelecionado.QuantidadeRecebimentos);
                    dtDataFechamento.SelectedDate = caixaSelecionado.DataFechamento;
                    dtHoraFechamento.SelectedTime = caixaSelecionado.HoraFechamento;
                    dtDataFechamento.SelectedDate = DateTime.Now;
                    dtHoraFechamento.SelectedTime = DateTime.Now;
                    cbStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Erro ao selecionar o Caixa");
                messageErro.ShowDialog();
            }
            
        }
    }
}
