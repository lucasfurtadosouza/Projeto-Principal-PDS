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
        public Despesa _despesa = new Despesa();
        public PageDespesa()
        {
            InitializeComponent();
        }
        public PageDespesa(Despesa despesa)
        {
            _despesa = despesa;
            InitializeComponent();
            Loaded += DespesaWindow_Loaded;
        }
        private void DespesaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtValor.Focus();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _despesa.Valor = Convert.ToInt32(txtValor.Text);
            if (dpDataVen.SelectedDate != null)
            {
                _despesa.Data_Vencimento = dpDataVen.SelectedDate;
            }
            if (dpDataVen.SelectedDate != null)
            {
                _despesa.Data_Pagamento = dpDataPag.SelectedDate;
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
                    var form = new WindowDespesaList();
                    form.Show();
                    
                }
                else
                {
                    dao.Insert(_despesa);
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
