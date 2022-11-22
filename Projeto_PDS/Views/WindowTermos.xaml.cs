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
using Projeto_PDS.DataBase;
using Projeto_PDS;
using System.Windows.Threading;
using System.Timers;
using Projeto_PDS.Views_MessageBox;
namespace Projeto_PDS.Views
    
{
    /// <summary>
    /// Lógica interna para WindowTermos.xaml
    /// </summary>
    public partial class WindowTermos : Window
    {
        public int chave;
        public bool verdade;
        public WindowTermos()
        {
            InitializeComponent();
            Loaded += WindowTermos_Loaded;
        }
        bool maximize = false;

        private void WindowTermos_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void rdAceitar_Checked(Funcionario funcionario)
        {
            chave = funcionario.Id;
        }

        public void rdAceitar_Checked_1(object sender, RoutedEventArgs e)
        {
            verdade = true;

        }

        public void btAvancar_Click(object sender, RoutedEventArgs e)
        {

            if (verdade == true)
            {
                var form = new WindowNovoUsuario();
                form.Show();
                this.Close();
            }
            else
            {
                var messageAlert = new WindowMessageBoxAlerta("Aceite os termos primeiro", "Aceite os Termos");
                messageAlert.ShowDialog();
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

        public void btMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if (maximize == false)
            {
                WindowState = WindowState.Maximized;
                maximize = true;
            }
            else
            {
                WindowState = WindowState.Normal;
                maximize = false;
            }
        }
    }
}
