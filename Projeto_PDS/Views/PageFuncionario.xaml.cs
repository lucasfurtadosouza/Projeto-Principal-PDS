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
using Projeto_PDS.Views_MessageBox;

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
            Loaded += PageFuncionario_Loaded;
        }
        public PageFuncionario(MainWindow mainWindow, PageRelatorio page, Funcionario funcionario)
        {
            InitializeComponent();
            _funcionario = funcionario;
            _main = mainWindow;
            _page = page;

            Loaded += PageFuncionario_Loaded;
        }
        private void PageFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSexo();
            txtNome.Focus();
            txtNome.Text = _funcionario.Nome;
            txtEmail.Text = _funcionario.Email;
            txtCpf.Text = _funcionario.Cpf;
            txtTelefone.Text = _funcionario.Telefone;
            txtRua.Text = _funcionario.Rua;
            if(_funcionario.Numero != 0)
            {
                txtNumero.Text = Convert.ToString(_funcionario.Numero);
                txtSalario.Text = Convert.ToString(_funcionario.Salario);
                cbSexo.SelectedValue = _funcionario.Sexo.Id;
            }
            txtBairro.Text = _funcionario.Bairro;
            txtRg.Text = _funcionario.Rg;
            dtDataNasc.SelectedDate = _funcionario.DataNasc;
            txtCarteiraTrabalho.Text = _funcionario.CarteiraDeTrabalho;
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

            if (cbSexo.SelectedItem != null)
                _funcionario.Sexo = cbSexo.SelectedItem as Sexo;

            if (dtDataNasc.SelectedDate != null)
                _funcionario.DataNasc = dtDataNasc.SelectedDate;

            _funcionario.CarteiraDeTrabalho = txtCarteiraTrabalho.Text;
            _funcionario.Salario = Convert.ToDouble(txtSalario.Text);

            _funcionario.Foto = null;

            try
            {
                var dao = new FuncionarioDAO();
                
                if (_funcionario.Id > 0)
                {
                    dao.Update(_funcionario);
                    var messageUp = new WindowMessageBoxCerto("Informações Atualizadas com Sucesso!", "Registro Atualizado");
                    messageUp.ShowDialog();
                    _page.OpenPageList("List_Funcionario");
                }
                else
                {
                    dao.Insert(_funcionario);
                    var message = new WindowMessageBoxCerto("Informações Salvas com Sucesso!", "Registro Salvo");
                    message.ShowDialog();
                }

                btLimpar_Click(sender, e);
            }
            catch (Exception ex)
            {
                var messageError = new WindowMessageBoxError("Error: " + ex.Message, "Erro");
                messageError.ShowDialog();
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
        private void LoadSexo()
        {
            try
            {
                cbSexo.ItemsSource = new SexoDAO().List();
            }
            catch (Exception ex)
            {
                var messageErro = new WindowMessageBoxError("Error: " + ex.Message, "Não Executado");
                messageErro.ShowDialog();
            }
        }
    }
}
