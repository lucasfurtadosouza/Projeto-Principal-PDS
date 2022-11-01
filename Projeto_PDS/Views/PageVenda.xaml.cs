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
    /// Interação lógica para PageVenda.xam
    /// </summary>
    public partial class PageVenda : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Venda _venda = new Venda();

        public PageVenda(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += WindowProduto_Loaded;
        }
        public PageVenda(MainWindow mainWindow, PageRelatorio page, Venda venda)
        {
            InitializeComponent();
            _venda = venda;
            _main = mainWindow;
            _page = page;

            Loaded += WindowVenda_Loaded;
        }
        private void WindowVenda_Loaded(object sender, RoutedEventArgs e)
        {

            dtHoraVenda.Text = DateTime.Now.ToString("hh:mm");
            dtDataVenda.Text = DateTime.Now.ToShortDateString();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            //_venda.Valor = Convert.ToDouble(txtValor.Text);
            if (dtDataVenda.SelectedDate != null)
            {
                _venda.Data = dtDataVenda.SelectedDate;
            }
            if (dtHoraVenda.SelectedTime != null)
            {
                _venda.Hora = dtHoraVenda.SelectedTime;
            }
            //_venda.FormaPagamento = txtFormaPagamento.Text;

            try
            {
                var dao = new VendaDAO();
                if (_venda.Id > 0)
                {
                    //dao.Update(_venda);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //dao.Insert(_venda);
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
            //txtValor.Clear();
            dtDataVenda.SelectedDate = null;
            dtHoraVenda.SelectedTime = null;
            //txtFormaPagamento.Clear();
        }

    }
}
