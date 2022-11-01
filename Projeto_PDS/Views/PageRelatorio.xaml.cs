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
using Projeto_PDS.Views.PageList;
using System.Windows.Shapes;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageRelatorio.xam
    /// </summary>
    public partial class PageRelatorio : Page
    {
        private MainWindow _main;

        public PageRelatorio()
        {
            InitializeComponent();
        }

        public PageRelatorio(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        { 
            var button = (Button) sender;
            
            OpenPageList(button.Name);
        }

        public void OpenPageList(string name)
        {

            switch (name)
            {
                case "List_Fornecedor":
                    frameRelatorio.Content = new PageFornecedorList(_main, this);
                    break;
                case "List_Funcionario":
                    frameRelatorio.Content = new PageFuncionarioList(_main, this);
                    break;
                case "List_Cliente":
                    frameRelatorio.Content = new PageClienteList(_main, this);
                    break;
                case "List_Despesa":
                    frameRelatorio.Content = new PageDespesaList(_main, this);
                    break;
                case "List_Produto":
                    frameRelatorio.Content = new PageProdutoList(_main, this);
                    break;
                case "List_Caixa":
                    frameRelatorio.Content = new PageCaixaList(_main, this);
                    break;
            }
        }
    }
}
