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
    /// Lógica interna para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioWindow window = new UsuarioWindow();
            window.ShowDialog();
        }

		private void BtnCliente_Click(object sender, RoutedEventArgs e)
		{
			ClienteWindow cadastrar = new ClienteWindow();
			cadastrar.ShowDialog();
		}

		private void BtnEstoque_Click(object sender, RoutedEventArgs e)
		{
			EstoqueWindow cadastrar = new EstoqueWindow();
			cadastrar.ShowDialog();
		}

        private void BtnAgendamento_Click(object sender, RoutedEventArgs e)
        {
            AgendamentoWindow cadastrar = new AgendamentoWindow();
            cadastrar.ShowDialog();

        }

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			lbUsuario.Content = Aplicacao.UsuarioLogado.Nome;
			
		}
	}
}
