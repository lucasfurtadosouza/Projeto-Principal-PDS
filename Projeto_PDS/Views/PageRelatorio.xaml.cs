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
                case "List_Fornecedor":
                    framePage.Source = new System.Uri($"{pack}/PageFornecedorList.xaml");
                    break;
                case "List_Funcionario":
                    framePage.Source = new System.Uri($"{pack}/PageFuncionarioList.xaml");
                    break;
                case "List_Cliente":
                    framePage.Source = new System.Uri($"{pack}/PageClienteList.xaml");
                    break;
                case "List_Despesa":
                    framePage.Source = new System.Uri($"{pack}/PageDespesaList.xaml");
                    break;
                case "List_Produto":
                    framePage.Source = new System.Uri($"{pack}/PageProdutoList.xaml");
                    break;
                case "List_Caixa":
                    framePage.Source = new System.Uri($"{pack}/PageCaixaList.xaml");
                    break;
            }
        }
    }
}
