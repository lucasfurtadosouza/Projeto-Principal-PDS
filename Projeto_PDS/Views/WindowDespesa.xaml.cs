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

    public partial class WindowDespesa : Window
    {
        public Despesa _despesa = new Despesa();
        public WindowDespesa()
        {
            InitializeComponent();
        }
        public WindowDespesa(Despesa despesa)
        {
            _despesa = despesa;
            InitializeComponent();
            Loaded += DespesaWindow_Loaded;
        }
        private void DespesaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //txtValor.Focus();
        }
        private void btSalvarDespesa_Click(object sender, RoutedEventArgs e)
        {/*
            _despesa.Valor = txtValorText;
            _despesa.Data_Vencimento = txtData_ven.Text;
            _despesa.Data_Pagamento = dpData_Pag.Text;
            _despesa.Forma_Pagamento = txtForma_Pag.Text;
            _despesa.Descricao = txtDescri.Text;


            try
            {
                var dao = new DespesaDAO();
                if (_despesa.Id > 0)
                {
                    dao.Update(_despesa);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new WindowDespesaList();
                    form.Show();
                    this.Close();
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
            }*/
        }
    }
}
