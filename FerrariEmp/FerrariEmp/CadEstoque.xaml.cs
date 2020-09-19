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
    /// Lógica interna para CadEstoque.xaml
    /// </summary>
    public partial class CadEstoque : Window
    {

        public Estoque EstoqueAlteracao { get; set; }
        public CadEstoque()
        {
            InitializeComponent();
        }



        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            //verificar se é vazio ou espaço em branco 

            if (string.IsNullOrWhiteSpace(txtPeca.Text))
            {
                MessageBox.Show("Nome Peça  é Obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPeca.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 

            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                MessageBox.Show("Quantidade  é Obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtQuantidade.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 

            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Valor é Obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtValor.Focus();
                return;
            }
            EstoqueRepo repo = new EstoqueRepo();
            Estoque estoque = new Estoque();

            estoque.Peca = txtPeca.Text;
            estoque.Quantidade = txtQuantidade.Text;
            estoque.Valor = Decimal.Parse(txtValor.Text);

            try
            {
                if (EstoqueAlteracao != null)
                {
                    //preenche o ID
                    estoque.Id = EstoqueAlteracao.Id;

                    repo.Alterar(estoque);
                    MessageBox.Show("Produto Alterado com sucesso.");
                }
                else
                {
                    repo.Inserir(estoque);
                    MessageBox.Show("Produto Cadastrado Com Sucesso");
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
            if (EstoqueAlteracao != null)
            {
                txtPeca.Text = EstoqueAlteracao.Peca;
                txtQuantidade.Text = EstoqueAlteracao.Quantidade;
                txtValor.Text = EstoqueAlteracao.Valor.ToString("n2");

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

