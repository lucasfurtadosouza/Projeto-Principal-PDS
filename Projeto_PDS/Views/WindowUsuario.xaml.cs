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
    /// Lógica interna para WindowUsuario.xaml
    /// </summary>
    public partial class WindowUsuario : Window
    {
        public Usuario _usuario = new Usuario();
        public WindowUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Loaded += WindowRecebimento_Loaded;
        }
        private void WindowRecebimento_Loaded(object sender, RoutedEventArgs e)
        {
            /*dtDataVenda.SelectedDate = _venda.Data;
            dtHoraVenda.SelectedTime = _venda.Hora;
            cbFormaPagamento.Text = _venda.FormaPagamento;
            cbFormaPagamento.Text = _venda.FormaPagamento;
            txtValor.Text = Convert.ToString(_venda.Valor);*/
            LoadFuncionario();
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            /*if (dtDataVenda.SelectedDate != null)
                _recebimento.Data = dtDataVenda.SelectedDate;

            if (dtHoraVenda.SelectedTime != null)
                _recebimento.Hora = dtHoraVenda.SelectedTime;

            if (cbCaixa.SelectedItem != null)
                _recebimento.Caixa = cbCaixa.SelectedItem as Caixa;

            _recebimento.Descricao = txtDescricao.Text;
            _recebimento.FormaPagamento = cbFormaPagamento.Text;
            _recebimento.Status = cbStatus.Text;
            _recebimento.Valor = Convert.ToDouble(txtValor.Text);

            var dao = new VendaDAO();
            dao.Insert(_venda, _recebimento);
            var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
            message.ShowDialog();*/
            this.Close();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            cbFuncionario.SelectedIndex = -1;
            txtNome.Clear();
            txtSenha.Clear();
        }
        private void LoadFuncionario()
        {
            try
            {
                cbFuncionario.ItemsSource = new CaixaDAO().ListCaixaAberto();
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }
    }
}
