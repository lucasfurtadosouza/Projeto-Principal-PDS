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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para WindowFuncionario.xaml
    /// </summary>
    public partial class WindowFuncionario : Window
    {
        public Funcionario _funcionario = new Funcionario();
        public WindowFuncionario()
        {
            InitializeComponent();
        }
        public WindowFuncionario(Funcionario funcionario)
        {
            _funcionario = funcionario;
            InitializeComponent();
            Loaded += FuncionarioWindow_Loaded;
        }
        private void FuncionarioWindow_Loaded(object sender, RoutedEventArgs e)
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

            if (dpDataNasc.SelectedDate != null)
            {
                _funcionario.DataNasc = dpDataNasc.SelectedDate;
            }
            _funcionario.CarteiraDeTrabalho = txtCarteiraTrabalho.Text;
            _funcionario.Salario = Convert.ToInt32(txtSalario.Text);
            
            _funcionario.Foto = txtFoto.Text;

            try
            {
                var dao = new FuncionarioDAO();
                if (_funcionario.Id > 0)
                {
                    dao.Update(_funcionario);
                    MessageBox.Show("Informações Atualizadas com Sucesso", "Cadastro Atualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new WindowDespesaList();
                    form.Show();
                    this.Close();
                }
                else
                {
                    dao.Insert(_funcionario);
                    MessageBox.Show("Informações Salvas com Sucesso", "Cadastro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
