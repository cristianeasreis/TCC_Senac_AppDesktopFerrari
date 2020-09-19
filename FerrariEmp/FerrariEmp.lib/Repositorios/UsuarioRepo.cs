using Dapper;
using FerrariEmp.lib.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerrariEmp.lib.Repositorios
{
    public class UsuarioRepo
    {
        public Usuario ConsultarPorEmail(string email)
        {
            Usuario usuario;
            //abrindo conexao
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                //gerando script
                string script = "SELECT id_usuario Id, ds_email Email, ds_senha Senha, nm_usuario Nome, num_cpf CPF, " +
                    " id_tipo_usuario  TipoUsuario  FROM USUARIO WHERE ds_email = @EMAIL";

                //buscando o primeiro 

                usuario = conn.QueryFirstOrDefault<Usuario>(script, new { email });
            }
            return usuario;
        }
        public void Inserir(Usuario usuario)
        {

			if (ConsultarPorEmail(usuario.Email) != null)
			{
				throw new Exception("E_mail já existe.");
			}
			//abro conexão
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "INSERT INTO USUARIO (ds_email,ds_senha, nm_usuario,num_cpf,id_tipo_usuario) " +
                    "VALUES (@EMAIL ,@SENHA, @NOME, @CPF, @TIPO)";

                conn.Execute(script, new
                {
                    @EMAIL = usuario.Email,
                    @SENHA = usuario.Senha,
                    @NOME = usuario.Nome,
                    @CPF = usuario.CPF,
                    @TIPO = usuario.TipoUsuario,

                });
            }
        }
        public List<Usuario> Pesquisar(string filtro)
        {
            List<Usuario> usuario;
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "SELECT id_usuario Id, ds_email Email, ds_senha Senha,nm_usuario Nome,num_cpf CPF," +
                    " id_tipo_usuario TipoUsuario " +
                    "FROM USUARIO WHERE nm_usuario like '%' + @FILTRO + '%' OR num_cpf like '%' + @FILTRO + '%' ";


                usuario = conn.Query<Usuario>(script, new { @FILTRO = filtro }).ToList();
            }
            return usuario;
        }
        public void Alterar(Usuario usuario)
        {
            //abro a conexao
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "UPDATE USUARIO SET ds_email = @EMAIL, ds_senha = @SENHA,nm_usuario = @NOME," +
                    "num_cpf = @CPF, id_tipo_usuario = @TIPO WHERE  id_usuario = @ID";

                conn.Execute(script, new
                {
                    @EMAIL = usuario.Email,
                    @SENHA = usuario.Senha,
                    @NOME = usuario.Nome,
                    @CPF = usuario.CPF,
                    @TIPO = usuario.TipoUsuario,
                    @ID = usuario.Id
                });
            }
        }
        public void Excluir(int Id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "DELETE USUARIO WHERE id_usuario = @ID";
                conn.Execute(script, new { @ID = Id });
            }

        }
    }
}


