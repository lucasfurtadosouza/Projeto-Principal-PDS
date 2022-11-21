using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Projeto_PDS;
using Projeto_PDS.Models;
using Projeto_PDS.Views_MessageBox;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.setPageMain();
        }
        public  void setPage(string page)
        {
            var pack = "pack://application:,,,/Views";
            framePage.Source = new Uri($"{pack}/{page}.xaml");
        }
        public void setPageMain()
        {
            framePage.Source = new Uri("pack://application:,,,/Views/PageMain.xaml");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            OpenPage(button.Name);            
        }

        public void OpenPage(string menu)
        {
            var pack = "pack://application:,,,/Views";

            switch (menu)
            {
                case "MN_Menu":
                    framePage.Source = new System.Uri($"{pack}/PageMain.xaml");
                    break;
                case "MN_Fornecedor":
                    framePage.NavigationService.Navigate(new PageFornecedor(this));
                    break;
                case "MN_Cliente":
                    framePage.NavigationService.Navigate(new PageCliente(this));
                    break;
                case "MN_Despesa":
                    framePage.NavigationService.Navigate(new PageDespesa(this));
                    break;
                case "MN_Funcionario":
                    framePage.NavigationService.Navigate(new PageFuncionario(this));
                    break;
                case "MN_Produto":
                    framePage.NavigationService.Navigate(new PageProduto(this));
                    break;
                case "MN_CaixaAbrir":
                    framePage.NavigationService.Navigate(new PageAbrirCaixa(this));
                    break;
                case "MN_CaixaFechar":
                    framePage.NavigationService.Navigate(new PageFecharCaixa(this));
                    break;
                case "MN_Venda":
                    framePage.NavigationService.Navigate(new PageVenda(this));
                    break;
                case "MN_Compra":
                    framePage.NavigationService.Navigate(new PageCompra(this));
                    break;
                case "MN_Relatorio":
                    framePage.Content = new PageRelatorio(this);
                    break;
            }

        }
        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            Name_User.Visibility = Visibility.Visible;
            BorderFoto.Margin = new Thickness(0, -170, 0, 0);
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            Name_User.Visibility = Visibility.Collapsed;
            BorderFoto.Margin = new Thickness(0, -10, 0, 0);
        }
        //Icon Editar <materialDesign:PackIcon Kind="Pencil" Height="28" Width="25"/>
    }
}
