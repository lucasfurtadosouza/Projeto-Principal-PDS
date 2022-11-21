using Projeto_PDS.Models;
using Projeto_PDS.Views_MessageBox;
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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageAbrirCaixa.xam
    /// </summary>
    public partial class PageAbrirCaixa : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Caixa _caixa = new Caixa();

        public PageAbrirCaixa(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += PageAbrirCaixa_Loaded;
        }

        public PageAbrirCaixa(MainWindow mainWindow, PageRelatorio page, Caixa caixa)
        {
            InitializeComponent();
            _caixa = caixa;
            _main = mainWindow;
            _page = page;

            Loaded += PageAbrirCaixa_Loaded;
        }
        private void PageAbrirCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            txtSaldoInicial.Focus();
            dtDataAbertura.SelectedDate = DateTime.Now;
            dtHoraAbertura.SelectedTime = DateTime.Now;
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _caixa.SaldoInicial = Convert.ToDouble(txtSaldoInicial.Text);
            if (dtDataAbertura.SelectedDate != null)
            {
                _caixa.DataAbertura = dtDataAbertura.SelectedDate;
            }
            if (dtHoraAbertura.SelectedTime != null)
            {
                _caixa.HoraAbertura = dtHoraAbertura.SelectedTime;
            }
            _caixa.Status = "Aberto";

            try
            {
                var dao = new CaixaDAO();
                dao.Insert(_caixa);
                var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                message.ShowDialog();

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
            txtSaldoInicial.Clear();
            dtDataAbertura.SelectedDate = DateTime.Now;
            dtHoraAbertura.SelectedTime = DateTime.Now;
        }
    }
}
