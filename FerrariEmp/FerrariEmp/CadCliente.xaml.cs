using FerrariEmp.lib.Modelos;
using FerrariEmp.lib.Repositorios;
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

namespace FerrariEmp
{
	/// <summary>
	/// Lógica interna para CadCliente.xaml
	/// </summary>
	public partial class CadCliente : Window
	{
		public Cliente ClienteAlteracao { get; set; }
		public CadCliente()
		{
			InitializeComponent();
		}

		private void BtnSalvar_Click(object sender, RoutedEventArgs e)
		{
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("Nome Da Empresa é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmpresa.Focus();
                return;
            }

            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                MessageBox.Show("CNPJ  é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCnpj.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Telefone é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTelefone.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Celular é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCelular.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                MessageBox.Show("Endereço é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEndereco.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                MessageBox.Show("Nº é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtN.Focus();
                return;
            }
           
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                MessageBox.Show("Bairro é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtBairro.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                MessageBox.Show("Cidade é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCidade.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Estado é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEstado.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtCep.Text))
            {
                MessageBox.Show("Cep é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCep.Focus();
                return;
            }
            ClienteRepo repo = new ClienteRepo();
			Cliente cliente = new Cliente();

			// preenchendo campos

			cliente.Empresa = txtEmpresa.Text;
			cliente.Cnpj = txtCnpj.Text;
			cliente.Email = txtEmail.Text;
			cliente.Telefone = txtTelefone.Text;
			cliente.Celular = txtCelular.Text;
			cliente.Endereco = txtEndereco.Text;
			cliente.N = txtN.Text;
			cliente.Complemento = txtComplemento.Text;
			cliente.Bairro = txtBairro.Text;
			cliente.Cidade = txtCidade.Text;
			cliente.Estado = txtEstado.Text;
			cliente.Cep = txtCep.Text;
			cliente.Ativo = true;
			cliente.DataStatus = DateTime.Now;

			try
			{
				if (ClienteAlteracao != null)
				{
					//preenche o ID
					cliente.Id = ClienteAlteracao.Id;

					repo.Alterar(cliente);
					MessageBox.Show("Cliente alterado com sucesso.");
				}
				else
				{
					repo.Inserir(cliente);
					MessageBox.Show("Cliente Cadastrado Com Sucesso");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu um erro.Mensagem Original: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			Close();
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			if (ClienteAlteracao != null)
			{
				txtEmpresa.Text = ClienteAlteracao.Empresa;
				txtCnpj.Text = ClienteAlteracao.Cnpj;
				txtEmail.Text = ClienteAlteracao.Email;
				txtTelefone.Text = ClienteAlteracao.Telefone;
				txtCelular.Text = ClienteAlteracao.Celular;
				txtEndereco.Text = ClienteAlteracao.Endereco;
				txtN.Text = ClienteAlteracao.N;
				txtComplemento.Text = ClienteAlteracao.Complemento;
				txtBairro.Text = ClienteAlteracao.Bairro;
				txtCidade.Text = ClienteAlteracao.Cidade;
				txtEstado.Text = ClienteAlteracao.Estado;
				txtCep.Text = ClienteAlteracao.Cep;


			}
		}
	}
}