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
        }
        public WindowCaixa(Caixa caixa)
        {
            _caixa = caixa;
            InitializeComponent();
            Loaded += WindowCaixa_Loaded;
        }
        private void WindowCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            //txtSaldoInicial.Focus();
        }
        private void btSalvarCaixa_Click(object sender, RoutedEventArgs e)
        {
            //public int Id { get; set; }
            //public double SaldoInicial { get; set; }
            //public double SaldoFinal { get; set; }
            //public DateTime? DataAbertura { get; set; }
            //public DateTime? DataFechamento { get; set; }
            //public DateTime? HoraAbertura { get; set; }
            //public DateTime? HoraFechamento { get; set; }
            //public int QuantidadePagamentos { get; set; }
            //public int QuantidadeRecebimentos { get; set; }
            /*
            _caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
            _caixa.SaldoFinal = Convert.ToDouble(txtSaldoFinal.Text);
            if (dpDataCriacao.SelectedDate != null)
            {
                _escola.DataCricao = dpDataCriacao.SelectedDate;
            }
            if (dpDataCriacao.SelectedDate != null)
            {
                _escola.DataCricao = dpDataCriacao.SelectedDate;
            }
            _curso.Carga = txtCarga.Text;
            _curso.Turno = cbTurno.Text;

            try
            {
                var dao = new CursoDAO();
                if (_curso.IdCur > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new ProjetoEscola.Views.CursoWindowLista();
                    form.Show();
                    this.Close();
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
    }
}
