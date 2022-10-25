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
using Projeto_PDS.Models;

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Interação lógica para PageFuncionario.xam
    /// </summary>
    public partial class PageFuncionario : Page
    {
        public Funcionario _funcionario = new Funcionario();

        private MainWindow _main;

        private PageRelatorio _page;

        public PageFuncionario(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
            Loaded += WindowFornecedor_Loaded;
        }
        public PageFuncionario(MainWindow mainWindow, PageRelatorio page, Funcionario funcionario)
        {
            InitializeComponent();
            _funcionario = funcionario;
            _main = mainWindow;
            _page = page;

            Loaded += WindowFornecedor_Loaded;
        }
        private void WindowFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Focus();
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _funcionario.Nome = txtNome.Text;
            _funcionario.Email = txtEmail.Text;
            _funcionario.Cpf = txtCpf.Text;
            _funcionario.Telefone = txtTelefone.Text;
            _funcionario.Rua = txtRua.Text;
            _funcionario.Numero = Convert.ToInt32(txtNumero.Text);
            _funcionario.Bairro = txtBairro.Text;
            _funcionario.Rg = txtRg.Text;

            if (dtDataNasc.SelectedDate != null)
            {
                _funcionario.DataNasc = dtDataNasc.SelectedDate;
            }
            _funcionario.CarteiraDeTrabalho = txtCarteiraTrabalho.Text;
            _funcionario.Salario = Convert.ToDouble(txtSalario.Text);

            _funcionario.Foto = null;

            try
            {
                var dao = new FuncionarioDAO();
                if (_funcionario.Id > 0)
                {
                    dao.Update(_funcionario);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    _page.OpenPageList("List_Fornecedor");
                }
                else
                {
                    dao.Insert(_funcionario);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtRg.Clear();
            txtCarteiraTrabalho.Clear();
            txtSalario.Clear();
            cbSexo.SelectedIndex = -1;
            dtDataNasc.SelectedDate = null;
        }
    }
}
