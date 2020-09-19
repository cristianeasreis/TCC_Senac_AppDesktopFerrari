using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
	/// Lógica interna para ConfigWindow.xaml
	/// </summary>
	public partial class ConfigWindow : Window
	{
		public ConfigWindow()
		{
			InitializeComponent();
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
		
		}

		private void BtnSalvar_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void BtnSalvar_Click_1(object sender, RoutedEventArgs e)
		{

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = txtServidor.Text;
			builder.InitialCatalog = txtNome.Text;
			builder.UserID = txtUsuario.Text;
			builder.Password = txtSenha.Password;

			SqlConnection connection = new SqlConnection(builder.ConnectionString);
			bool resultadoTesteConexao;
			string erro = "";
			try
			{
				connection.Open();
				connection.Close();
				resultadoTesteConexao = true;

			}
			catch (Exception ex)
			{
				erro = ex.ToString();
				resultadoTesteConexao = false;

			}
			if (resultadoTesteConexao)
			{
				ConnectionStringSettings novaconfiguracao = new ConnectionStringSettings("banco", builder.ConnectionString);

				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

				config.ConnectionStrings.ConnectionStrings.Clear();

				config.ConnectionStrings.ConnectionStrings.Add(novaconfiguracao);

				config.Save(ConfigurationSaveMode.Modified);

				ConfigurationManager.RefreshSection("connectionStrings");

				MessageBox.Show("Alterações efetuados com sucesso.");
				Close();
			}
			else
			{
				MessageBox.Show("Ocorreu um erro ao estabelecer" + "conexao com banco de dados.Erro Original: " + erro, "Erro",
					MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Window_ContentRendered_1(object sender, EventArgs e)
		{
			String connection = lib.Repositorios.Conexao.ConsultarConexao();

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
			txtServidor.Text = builder.DataSource;
			txtNome.Text = builder.InitialCatalog;
			txtUsuario.Text = builder.UserID;
			txtSenha.Password = builder.Password;
		}
	}
}
