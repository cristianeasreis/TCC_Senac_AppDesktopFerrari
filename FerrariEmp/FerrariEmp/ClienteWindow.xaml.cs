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
    /// Lógica interna para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        public ClienteWindow()
        {
            InitializeComponent();
        }

        private void AtualizarDataGrid() {
            ClienteRepo repo = new ClienteRepo();
            list.ItemsSource = repo.Pesquisar(txtPesquisar.Text);
            list.Columns[0].Visibility = Visibility.Hidden;
            list.Columns[0].IsReadOnly = true;
            list.Columns[1].IsReadOnly = true;
            list.Columns[2].IsReadOnly = true;
            list.Columns[3].IsReadOnly = true;
            list.Columns[4].IsReadOnly = true;
            list.Columns[5].IsReadOnly = true;
            list.Columns[6].IsReadOnly = true;
            list.Columns[7].IsReadOnly = true;
            list.Columns[8].IsReadOnly = true;
            list.Columns[9].IsReadOnly = true;
            list.Columns[10].IsReadOnly = true;
            list.Columns[11].IsReadOnly = true;
            list.Columns[12].IsReadOnly = true;
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarDataGrid();

        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            CadCliente cadastrar = new CadCliente();
            cadastrar.ShowDialog();
        }

        private void List_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                ClienteRepo repo = new ClienteRepo();
                Cliente cliente = list.SelectedItem as Cliente;

                MessageBoxResult resposta;
                resposta = MessageBox.Show("Deseja realmente excluir ? ", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resposta == MessageBoxResult.Yes)
                {
                    repo.Excluir(cliente.Id);
                    AtualizarDataGrid();
                }
                else
                {
                    e.Handled = true; // para ignorar o DELETE
                }


            }
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (list.SelectedItems.Count > 0)
            {
                CadCliente janela = new CadCliente();
                //item preencher o item selecionado
                janela.ClienteAlteracao = list.SelectedItem as Cliente;
                //abre a janela
                janela.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarDataGrid();
        }
    }
}
