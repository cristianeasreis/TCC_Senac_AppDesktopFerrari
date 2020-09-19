using FerrariEmp.lib.Modelos;
using FerrariEmp.lib.Repositorios;
using System;
using System.Collections.Generic;
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
using Xceed;

namespace FerrariEmp
{
    /// <summary>
    /// Lógica interna para AgendamentoWindow.xaml
    /// </summary>
    public partial class AgendamentoWindow : Window
    {
        public AgendamentoWindow()
        {
            InitializeComponent();
        }
        private void AtualizarDataGrid() {
            //carrega os dados no datagrid
            AgendamentoRepo repo = new AgendamentoRepo();
            list.ItemsSource = repo.Pesquisar(txtPesquisar.Text);
            list.Columns[0].Visibility = Visibility.Hidden;
            list.Columns[6].Visibility = Visibility.Hidden;
            list.Columns[3].Visibility = Visibility.Hidden;
            list.Columns[0].IsReadOnly = true;
            list.Columns[1].IsReadOnly = true;
            list.Columns[2].IsReadOnly = true;
            list.Columns[3].IsReadOnly = true;
            list.Columns[4].IsReadOnly = true;
            list.Columns[5].IsReadOnly = true;
            list.Columns[6].IsReadOnly = true;
            list.Columns[7].IsReadOnly = true;
            list.Columns[8].IsReadOnly = true;
            list.Columns[10].IsReadOnly = true;

        }



        private void BtnPesqisar_Click(object sender, RoutedEventArgs e)
        {


            AtualizarDataGrid();

        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            CadAgendamento cadastrar = new CadAgendamento();
            cadastrar.ShowDialog();
        }

        private void List_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Visita")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "dd / MM / yyyy HH:mm";
            }
            if (e.Column.Header.ToString() == "DTServico")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "dd / MM / yyyy HH:mm";
            }
            if (e.Column.Header.ToString() == "DateStatus")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "dd / MM / yyyy HH:mm";
            }
            if (e.Column.Header.ToString() == "VlServiço")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "C2";
            }
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                CadAgendamento janela = new CadAgendamento();
                janela.AgendamentoAlteracao = list.SelectedItem as Agendamento;
                janela.ShowDialog();

                AtualizarDataGrid();
            }
        }

        private void List_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            {
                if (e.Key == Key.Delete)
                {
                    AgendamentoRepo repo = new AgendamentoRepo();
                    Agendamento agendamento = list.SelectedItem as Agendamento;

                    MessageBoxResult resposta;
                    resposta = MessageBox.Show("Deseja realmente excluir ? ", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resposta == MessageBoxResult.Yes)
                    {
                        repo.Excluir(agendamento.Id);
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
