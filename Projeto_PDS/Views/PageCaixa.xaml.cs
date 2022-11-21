﻿using System;
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
    /// Interação lógica para PageCaixa.xam
    /// </summary>
    public partial class PageCaixa : Page
    {
        private MainWindow _main;

        private PageRelatorio _page;

        public Caixa _caixa = new Caixa();

        public PageCaixa(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += WindowCaixa_Loaded;
        }

        public PageCaixa(MainWindow mainWindow, PageRelatorio page, Caixa caixa)
        {
            InitializeComponent();
            _caixa = caixa;
            _main = mainWindow;
            _page = page;
            Loaded += WindowCaixa_Loaded;
        }

        private void WindowCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            txtSaldoInicial.Text = Convert.ToString(_caixa.SaldoInicial);
            txtSaldoFinal.Text = Convert.ToString(_caixa.SaldoFinal);
            txtQuantidadePagamentos.Text = Convert.ToString(_caixa.QuantidadePagamentos);
            txtQuantidadeRecebimentos.Text = Convert.ToString(_caixa.QuantidadeRecebimentos);
            dtDataAbertura.SelectedDate = _caixa.DataAbertura;
            dtDataFechamento.SelectedDate = _caixa.DataFechamento;
            dtHoraAbertura.SelectedTime = _caixa.HoraAbertura;
            dtHoraFechamento.SelectedTime = _caixa.HoraFechamento;
            cbStatus.Text = _caixa.Status;
        }
        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            _page.OpenPageList("List_Caixa"); ;
        }
    }
}
