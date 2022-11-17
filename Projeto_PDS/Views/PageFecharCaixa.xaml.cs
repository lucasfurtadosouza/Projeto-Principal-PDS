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
            //txtSaldoInicial.Focus();
            if (_caixa.Id > 0)
            {
                //txtSaldoInicial.Text = Convert.ToString(_caixa.SaldoInicial);
                txtSaldoFinal.Text = Convert.ToString(_caixa.SaldoFinal);
                txtQuantidadePagamentos.Text = Convert.ToString(_caixa.QuantidadePagamentos);
                txtQuantidadeRecebimentos.Text = Convert.ToString(_caixa.QuantidadeRecebimentos);
                //dtDataAbertura.SelectedDate = _caixa.DataAbertura;
                dtDataFechamento.SelectedDate = _caixa.DataFechamento;
                //dtHoraAbertura.SelectedTime = _caixa.HoraAbertura;
                dtHoraFechamento.SelectedTime = _caixa.HoraFechamento;
                cbStatus.Text = _caixa.Status;
            }
            else
            {
                dtDataFechamento.SelectedDate = DateTime.Now;
                dtHoraFechamento.SelectedTime = DateTime.Now;
            }
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            //_caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
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

            try
            {
                var dao = new CaixaDAO();
                if (_caixa.Id > 0)
                {
                    dao.Update(_caixa);
                    var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                    messageUp.ShowDialog();
                    _page.OpenPageList("List_Caixa"); ;
                }
                else
                {
                    dao.Insert(_caixa);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                }

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
            txtSaldoFinal.Clear();
            dtDataFechamento.SelectedDate = DateTime.Now;
            dtHoraFechamento.SelectedTime = DateTime.Now;
            txtQuantidadePagamentos.Clear();
            txtQuantidadeRecebimentos.Clear();
        }
    }
}
