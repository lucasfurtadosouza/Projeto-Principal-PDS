using Projeto_PDS.Helpers;
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
    /// Interação lógica para PageMain.xam
    /// </summary>
    public partial class PageMain : Page
    {
        SessionHelper binds = new SessionHelper();
        public PageMain()
        {
            InitializeComponent();
            txtHora.Text = DateTime.Now.ToShortTimeString();
            txtData.Text = DateTime.Now.ToShortDateString();
            try
            {
                txtLucro.Text = binds.GetLucro();
                txtItensVend.Text = binds.GetItensVendidos();
                txtEstoque.Text = binds.GetEstoque();
            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro"); 
                messageError.ShowDialog();
            }
        }

        private void UIElement_TouchEnter(object sender, TouchEventArgs e)
        {

        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            WindowUsuario window = new WindowUsuario();
            window.ShowDialog();
        }
    }
}
