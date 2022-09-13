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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowFornecedor.xaml
    /// </summary>
    public partial class PageFornecedor : Page
    {
        private MainWindow _main;

        public Fornecedor _fornecedor = new Fornecedor();

        public PageFornecedor(MainWindow mainWindow)
        {
            InitializeComponent();
            
            _main = mainWindow;

            Loaded += WindowFornecedor_Loaded;
        }
        
        public PageFornecedor()
        {
            InitializeComponent();
        }
        public PageFornecedor(Fornecedor fornecedor)
        {
            _fornecedor = fornecedor;
            InitializeComponent();
            Loaded += WindowFornecedor_Loaded;
        }

        private void WindowFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btSalvarFornecedor_Click(object sender, RoutedEventArgs e)
        {
           

            MessageBox.Show("aqui");

            _main.setPageMain();


            //_fornecedor.Nome = txtNome.Text;
            //_fornecedor.Razao = txtRazao.Text;
            //_fornecedor.Cnpj = txtCnpj.Text;
            //_fornecedor.Email= txtEmail.Text;
            //_fornecedor.Endereco = txtEndereco.Text;
            //_fornecedor.Telefone = txtTelefone.Text;


            //try
            //{
            //    var dao = new FornecedorDAO();
            //    if (_fornecedor.Id > 0)
            //    {
            //        dao.Update(_fornecedor);
            //        MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
            //        var form = new WindowFornecedorList();
            //        form.Show();
            //        //this.Close();
            //    }
            //    else
            //    {
            //        dao.Insert(_fornecedor);
            //        MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
