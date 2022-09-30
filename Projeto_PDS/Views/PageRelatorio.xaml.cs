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
    /// Interação lógica para PageRelatorio.xam
    /// </summary>
    public partial class PageRelatorio : Page
    {
        public PageRelatorio()
        {
            InitializeComponent();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var frame = framePage;
            var pack = "pack://application:,,,/Views/PageList";

            switch (button.Name)
            {
                case "MN_Menu":
                    framePage.Source = new System.Uri($"{pack}/PageMain.xaml");
                    break;
                case "List_Fornecedor":
                    framePage.Source = new System.Uri($"{pack}/PageFornecedorList.xaml");
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
    }
}
