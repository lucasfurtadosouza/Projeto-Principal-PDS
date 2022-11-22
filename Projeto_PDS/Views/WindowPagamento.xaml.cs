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
using Projeto_PDS.Models;
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowPagamento.xaml
    /// </summary>
    public partial class WindowPagamento : Window
    {
        public Pagamento _pagamento = new Pagamento();
        public Despesa _despesa = new Despesa();
        public WindowPagamento(Despesa despesa)
        {
            InitializeComponent();
            _despesa = despesa;
            Loaded += WindowPagamento_Loaded;
        }
        private void WindowPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            dtDataPagamento.SelectedDate = DateTime.Now;
            dtHoraPagamento.SelectedTime = DateTime.Now;
            cbFormaPagamento.Text = _despesa.Forma_Pagamento;
            txtValor.Text = Convert.ToString(_despesa.Valor);
            LoadCaixa();
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (dtDataPagamento.SelectedDate != null)
                _pagamento.Data = dtDataPagamento.SelectedDate;

            if (dtHoraPagamento.SelectedTime != null)
                _pagamento.Hora = dtHoraPagamento.SelectedTime;

            if (cbCaixa.SelectedItem != null)
                _pagamento.Caixa = cbCaixa.SelectedItem as Caixa;

            _pagamento.Descricao = txtDescricao.Text;
            _pagamento.FormaPagamento = cbFormaPagamento.Text;
            _pagamento.Status = cbStatus.Text;
            _pagamento.Valor = Convert.ToDouble(txtValor.Text);

            var dao = new DespesaDAO();
            dao.Insert(_despesa, _pagamento);
            var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
            message.ShowDialog();
            this.Close();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbStatus.SelectedIndex = -1;
            txtDescricao.Clear();
        }
        private void LoadCaixa()
        {
            try
            {
                cbCaixa.ItemsSource = new CaixaDAO().ListCaixaAberto();
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }
    }
}
