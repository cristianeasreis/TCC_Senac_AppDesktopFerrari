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
    /// Lógica interna para EstoqueWindow.xaml
    /// </summary>
    public partial class EstoqueWindow : Window
    {
        public EstoqueWindow()
        {
            InitializeComponent();
        }
        private void AtualizarDataGrid() {
            EstoqueRepo repo = new EstoqueRepo();
            List.ItemsSource = repo.Pesquisar(txtPeca.Text);
            List.Columns[0].Visibility = Visibility.Hidden;
            List.Columns[0].IsReadOnly = true;
            List.Columns[1].IsReadOnly = true;
            List.Columns[2].IsReadOnly = true;
            List.Columns[3].IsReadOnly = true;
        }


        private void TxtPesquisar_Click(object sender, RoutedEventArgs e)
		{
            AtualizarDataGrid();

        }

		private void TxtNovo_Click(object sender, RoutedEventArgs e)
		{

			CadEstoque cadastrar = new CadEstoque();
			cadastrar.ShowDialog();
		}

		private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (List.SelectedItems.Count > 0)
			{
				CadEstoque janela = new CadEstoque();
				//item preencher o item selecionado
				janela.EstoqueAlteracao = List.SelectedItem as Estoque;
				//abre a janela
				janela.ShowDialog();
                AtualizarDataGrid();
            }
		}

		private void List_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Delete)
			{
				EstoqueRepo repo = new EstoqueRepo();
				Estoque estoque = List.SelectedItem as Estoque;

				MessageBoxResult resposta;
				resposta = MessageBox.Show("Deseja realmente excluir ? ", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (resposta == MessageBoxResult.Yes)
				{
					repo.Excluir(estoque.Id);
                    AtualizarDataGrid();
                }
				else
				{
					e.Handled = true; // para ignorar o DELETE
				}


			}
		}

       

        private void List_AutoGeneratingColumn_1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Valor")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "C2";            }

        }

        private void TxtPeca_TextChanged(object sender, TextChangedEventArgs e)
        {

            AtualizarDataGrid();
        }
    }
}
