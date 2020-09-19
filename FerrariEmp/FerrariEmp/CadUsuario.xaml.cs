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

namespace FerrariEmp
{
    /// <summary>
    /// Lógica interna para CadUsuario.xaml
    /// </summary>
    public partial class CadUsuario : Window
    {
        public Usuario UsuarioAlteracao { get; set; }
        public CadUsuario()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //verificar se é vazio ou espaço em branco 

            if (string.IsNullOrWhiteSpace(txtnome.Text))
            {
                MessageBox.Show("Nome é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtnome.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtcpf.Text))
            {
                MessageBox.Show("CPF é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtcpf.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Email é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtemail.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(txtsenha.Password))
            {
                MessageBox.Show("Senha é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsenha.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (string.IsNullOrWhiteSpace(cbotipo.Text))
            {
                MessageBox.Show("Tipo é obrigatório", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                cbotipo.Focus();
                return;
            }
            //verificar se é vazio ou espaço em branco 
            if (txtsenha.Password != txtconfs.Password)
            {
                MessageBox.Show("Senha e Confirmação de senha estão diferentes", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsenha.Focus();
                return;
            }
            // instanciando objeto
            UsuarioRepo repo = new UsuarioRepo();
            Usuario usuario = new Usuario();

            // preenchendo campos

            usuario.Nome = txtnome.Text;
            usuario.Email = txtemail.Text;
            usuario.CPF = txtcpf.Text;
            usuario.Senha = txtsenha.Password;

            if (cbotipo.Text == "Administrador")
            {
                usuario.TipoUsuario = 1;
            }
            else if (cbotipo.Text == "Operador")
            {
                usuario.TipoUsuario = 2;
            }
            try
            {


                if (UsuarioAlteracao != null)
                {
                    //preenche o ID
                    usuario.Id = UsuarioAlteracao.Id;
                    //inserinco usuario
                    repo.Alterar(usuario);
                    MessageBox.Show("Usuario alterado com sucesso.");
                }
                else
                {//inserindo usuario
                    repo.Inserir(usuario);
                    MessageBox.Show("Usuario Cadastrado Com Sucesso.");
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
            if (UsuarioAlteracao != null)
            {
                txtnome.Text = UsuarioAlteracao.Nome;
                txtemail.Text = UsuarioAlteracao.Email;
                txtcpf.Text = UsuarioAlteracao.CPF;
                txtsenha.Password = UsuarioAlteracao.Senha;
                txtconfs.Password = UsuarioAlteracao.Senha;

                if (UsuarioAlteracao.TipoUsuario == 1)
                {
                    cbotipo.Text = "Administrador";
                }
                if (UsuarioAlteracao.TipoUsuario == 2)
                {
                    cbotipo.Text = "Operador";
                }

            }
        }

    }
}
