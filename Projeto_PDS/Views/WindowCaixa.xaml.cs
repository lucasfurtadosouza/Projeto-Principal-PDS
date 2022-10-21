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
using MySql.Data.MySqlClient;
using Projeto_PDS.Models;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowCaixa.xaml
    /// </summary>
    public partial class WindowCaixa : Window
    {
        public Caixa _caixa = new Caixa();
        public WindowCaixa()
        {
            InitializeComponent();
            Loaded += WindowCaixa_Loaded;
        }
        public WindowCaixa(Caixa caixa)
        {
            _caixa = caixa;
            InitializeComponent();
            Loaded += WindowCaixa_Loaded;
        }
        private void WindowCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            txtSaldoInicial.Focus();
            txtSaldoInicial.Text = Convert.ToString(_caixa.SaldoInicial);
            txtSaldoFinal.Text = Convert.ToString(_caixa.SaldoFinal);
            if (_caixa.DataAbertura != null)
            {
                dtDataAbertura.SelectedDate = _caixa.DataAbertura;
            }
            if (_caixa.DataFechamento != null)
            {
                dtDataFechamento.SelectedDate = _caixa.DataFechamento;
            }
            if (_caixa.HoraAbertura != null)
            {
                dtHoraAbertura.SelectedTime = _caixa.HoraAbertura;
            }
            if (dtHoraFechamento.SelectedTime != null)
            {
                dtHoraFechamento.SelectedTime = _caixa.HoraFechamento;
            }

        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
            _caixa.SaldoFinal = Convert.ToDouble(txtSaldoFinal.Text);
            if (dtDataAbertura.SelectedDate != null)
            {
                _caixa.DataAbertura = dtDataAbertura.SelectedDate;
            }
            if (dtDataFechamento.SelectedDate != null)
            {
                _caixa.DataFechamento = dtDataFechamento.SelectedDate;
            }
            if (dtHoraAbertura.SelectedTime != null)
            {
                _caixa.HoraAbertura = dtHoraAbertura.SelectedTime;
            }
            if (dtHoraFechamento.SelectedTime != null)
            {
                _caixa.HoraFechamento = dtHoraFechamento.SelectedTime;
            }
            _caixa.QuantidadePagamentos = Convert.ToInt32(txtQuantidadePagamentos.Text);
            _caixa.QuantidadeRecebimentos = Convert.ToInt32(txtQuantidadeRecebimentos.Text);

            try
            {
                var dao = new CaixaDAO();
                if (_caixa.Id > 0)
                {
                    dao.Update(_caixa);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new WindowCaixaList();
                    form.Show();
                }
                else
                {
                    dao.Insert(_caixa);
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
            txtSaldoInicial.Clear();
            txtSaldoFinal.Clear();
            dtDataAbertura.SelectedDate = null;
            dtDataFechamento.SelectedDate = null;
            dtHoraAbertura.SelectedTime = null;
            dtHoraFechamento.SelectedTime = null;
            txtQuantidadePagamentos.Clear();
            txtQuantidadeRecebimentos.Clear();
        }
    }
}
