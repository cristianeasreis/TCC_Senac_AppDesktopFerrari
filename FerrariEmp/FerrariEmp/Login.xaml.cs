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
	/// Lógica interna para Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		public Login()
		{
			InitializeComponent();
		}

		private void BntEntrar_Click(object sender, RoutedEventArgs e)
		{
			// instanciando o repositorio
			UsuarioRepo repo = new UsuarioRepo();
			// instanciando o modelo
			Usuario usuario;
			//consultando o usuario por email
			usuario = repo.ConsultarPorEmail(txtemail.Text);
			// se usuario tiver preenchido e se a senha for igual 
			if (usuario != null && usuario.Senha == txtsenha.Password)
			{
				MessageBox.Show("Seja bem vindo " + usuario.Nome);

				Aplicacao.UsuarioLogado = usuario;


				//abre menu
				Menu janela = new Menu();
				janela.Show();
				//fecha janela atual
				Close();
			}
			else
			{
				MessageBox.Show("Usuario ou Senha Inválido");
			}


		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			if (Aplicacao.TestarConexao() == false)
			{
				MessageBox.Show("Não foi possivel conectar ao banco de dados.Verifique se as canexao estão corretas",
				"Erro", MessageBoxButton.OK, MessageBoxImage.Error);

				MessageBoxResult resultado = MessageBox.Show("Deseja Configurar o banco de dados agora?",
					"configuração", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (resultado == MessageBoxResult.Yes)
				{
					ConfigWindow janela = new ConfigWindow();
					janela.ShowDialog();

					if (Aplicacao.TestarConexao() == false)
					{
						Close();
					}
				}
				else
				{
					Close();
				}
			}
		}
	}
}
