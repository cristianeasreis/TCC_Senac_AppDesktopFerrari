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
    /// Lógica interna para UsuarioWindow.xaml
    /// </summary>
    public partial class UsuarioWindow : Window
    {
        public UsuarioWindow()
        {
            InitializeComponent();
        }

        private void AtualizarDataGrid()
        {
            //carrega os dados no datagrid
            UsuarioRepo repo = new UsuarioRepo();
            list.ItemsSource = repo.Pesquisar(txtPesquisar.Text);

            //para deixar a coluna invisivel
            list.Columns[0].Visibility = Visibility.Hidden;
            list.Columns[4].Visibility = Visibility.Hidden;
            list.Columns[5].Visibility = Visibility.Hidden;
            list.Columns[0].IsReadOnly = true;
            list.Columns[1].IsReadOnly = true;
            list.Columns[2].IsReadOnly = true;
            list.Columns[3].IsReadOnly = true;
        }

        private void BtnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            AtualizarDataGrid();
        }

        private void Btnnovo_Click(object sender, RoutedEventArgs e)
        {
            CadUsuario cadastrar = new CadUsuario();
            cadastrar.ShowDialog();
            AtualizarDataGrid();
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // se existe itens selecionados

            if (list.SelectedItems.Count > 0)
            {
                CadUsuario janela = new CadUsuario();
                //item preencher o item selecionado
                janela.UsuarioAlteracao = list.SelectedItem as Usuario;
                //abre a janela
                janela.ShowDialog();
                AtualizarDataGrid();
            }

        }

        private void List_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                UsuarioRepo repo = new UsuarioRepo();
                Usuario usuario = list.SelectedItem as Usuario;

                if (Aplicacao.UsuarioLogado.Id == usuario.Id)
                {
                    MessageBox.Show("Usuario Não Pode Se Excluir", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    AtualizarDataGrid();
                }
                else
                {
                    e.Handled = true; // para ignorar o DELETE
                   

                }
                if (Aplicacao.UsuarioLogado.Id != usuario.Id)
                {

                    MessageBoxResult resposta;
                    resposta = MessageBox.Show("Deseja realmente excluir ? ", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resposta == MessageBoxResult.Yes)
                    {
                        repo.Excluir(usuario.Id);
                        AtualizarDataGrid();
                    }
                    else
                    {
                        e.Handled = true; // para ignorar o DELETE
                       
                    }
                }
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarDataGrid();

        }
    }
}


