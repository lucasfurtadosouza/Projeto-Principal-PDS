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
            var frame = framePage;
            var pack = "pack://application:,,,/Views";



            switch (button.Name)
            {
                case "MN_Menu":
                    framePage.Source = new System.Uri($"{pack}/PageMain.xaml");
                    break;
                case "MN_Fornecedor":
                    framePage.NavigationService.Navigate(new PageFornecedor(this)); //Uri($"{pack}/PageFornecedor.xaml");
                    break;
                case "MN_Cliente":
                    framePage.Source = new System.Uri($"{pack}/PageCliente.xaml");
                    break;
                case "MN_Despesa":
                    framePage.Source = new System.Uri($"{pack}/PageDespesa.xaml");
                    break;
                case "MN_Funcionario":
                    framePage.Source = new System.Uri($"{pack}/PageFuncionario.xaml");
                    break;
                case "MN_Produto":
                    framePage.Source = new System.Uri($"{pack}/PageProduto.xaml");
                    break;
                case "MN_Relatorio":
                    framePage.Source = new System.Uri($"{pack}/PageRelatorio.xaml");
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
