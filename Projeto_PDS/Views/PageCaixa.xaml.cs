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
    /// Interação lógica para PageCaixa.xam
    /// </summary>
    public partial class PageCaixa : Page
    {
        public Caixa _caixa = new Caixa();
        public PageCaixa()
        {
            InitializeComponent();
        }
        public PageCaixa(Caixa caixa)
        {
            _caixa = caixa;
            InitializeComponent();
            Loaded += WindowCaixa_Loaded;
        }
        private void WindowCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            txtSaldoInicial.Focus();
        }
        private void btSalvarCaixa_Click(object sender, RoutedEventArgs e)
        {
            _caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
            _caixa.SaldoFinal = Convert.ToDouble(txtSaldoFinal.Text);
            if (dpDataAbertura.SelectedDate != null)
            {
                _caixa.DataAbertura = dpDataAbertura.SelectedDate;
            }
            if (dpDataFechamento.SelectedDate != null)
            {
                _caixa.DataFechamento = dpDataFechamento.SelectedDate;
            }
            if (dpHoraAbertura.SelectedDate != null)
            {
                _caixa.HoraAbertura = dpHoraAbertura.SelectedDate;
            }
            if (dpHoraFechamento.SelectedDate != null)
            {
                _caixa.HoraFechamento = dpHoraFechamento.SelectedDate;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
