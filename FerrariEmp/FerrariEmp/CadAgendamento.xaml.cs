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
    /// Lógica interna para CadAgendamento.xaml
    /// </summary>
    public partial class CadAgendamento : Window
    {
        public Agendamento AgendamentoAlteracao { get; set; }
        public CadAgendamento()
        {
            InitializeComponent();
        }



        private void BtnSalvar_Click_1(object sender, RoutedEventArgs e)
        {

            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(dtVisita.Text))
            {
                MessageBox.Show("Data da Visita  é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                dtVisita.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(dtServiço.Text))
            {
                MessageBox.Show("Data do Serviço  é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                dtServiço.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtMensagem.Text))
            {
                MessageBox.Show("Descrição do Serviço  é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMensagem.Focus();
                return;
            }
            
           
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Marca Da Maquina  é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMarca.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(dsMaquina.Text))
            {
                MessageBox.Show("Descrição Da Maquina  é Obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                dsMaquina.Focus();
                return;
            }
          

            AgendamentoRepo repo = new AgendamentoRepo();
            Agendamento agendamento = new Agendamento();
			

			// preenchendo campos

			agendamento.Visita = Convert.ToDateTime(dtVisita.Text);
            agendamento.DServiço = txtMensagem.Text;
           
            agendamento.IdUsuario = int.Parse(txtCodUsuario.Content.ToString());
            agendamento.Mmaquina = txtMarca.Text;
            agendamento.DsMaquina = dsMaquina.Text;
            agendamento.VlServiço = Decimal.Parse(txtValor.Text);
            agendamento.DTServico = DateTime.Now;
            agendamento.Ativo = true;
            agendamento.DateStatus = DateTime.Now;
            agendamento.Nome = cbCliente.Text;


            if (dsMaquina.Text == "Gás")
            {
                agendamento.DsMaquina = "Gas";
            }
            else if (dsMaquina.Text == "Diesel")
            {
                agendamento.DsMaquina = "Diesel";
            }
            if (dsMaquina.Text == "Gasolina")
            {
                agendamento.DsMaquina = "Gasolina";
            }
            else if (dsMaquina.Text == "Eletrica")
            {
                agendamento.DsMaquina = "Eletrica";
            }
           

            try
            {
                if (AgendamentoAlteracao != null)
                {
                    //preenche o ID
                    agendamento.Id = AgendamentoAlteracao.Id;

                    repo.Alterar(agendamento);
                    MessageBox.Show("Agendamento Alterado Com sucesso.");
                }
                else
                {
                    repo.Inserir(agendamento);
                    MessageBox.Show("Agendamento Cadastrado Com Sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro.Mensagem Original: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

			Cliente cat = (Cliente)cbCliente.SelectedValue;
			


			Close();


        }



           
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ClienteRepo repo = new ClienteRepo();
			cbCliente.ItemsSource = repo.Pesquisar("");

         

            if (AgendamentoAlteracao != null)
            {
                dtVisita.Text = AgendamentoAlteracao.Visita.ToString("");
                txtMensagem.Text = AgendamentoAlteracao.DServiço;
				
                txtCodUsuario.Content = AgendamentoAlteracao.IdUsuario.ToString("");
                txtMarca.Text = AgendamentoAlteracao.Mmaquina;
                dsMaquina.Text = AgendamentoAlteracao.DsMaquina;
                txtValor.Text = AgendamentoAlteracao.VlServiço.ToString("N2");
                dtServiço.Text = AgendamentoAlteracao.DTServico.ToString("");
                cbCliente.Text = AgendamentoAlteracao.Nome;

            }
			if (Aplicacao.UsuarioLogado != null)
			{
				txtCodUsuario.Content = Aplicacao.UsuarioLogado.Id.ToString();
			}
            



        }

        private void TxtValor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (e.Text != "," && IsNumber(e.Text) == false)
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente Numero e Virgula");
            }

            else if (e.Text == ",")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                    e.Handled = true;


            }
        }
        private bool IsNumber(string Text)
        {
            Decimal output;
            return Decimal.TryParse(Text, out output);
        }

    }
}

