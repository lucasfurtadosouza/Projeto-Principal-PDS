using Projeto_PDS.Models;
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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowRecebimento.xaml
    /// </summary>
    public partial class WindowRecebimento : Window
    {
        //public Recebimento _recebimento = new Recebimento();
        public WindowRecebimento()
        {
            InitializeComponent();
            Loaded += WindowRecebimento_Loaded;
        }
        private void WindowRecebimento_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
