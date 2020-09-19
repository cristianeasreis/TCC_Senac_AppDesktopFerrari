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
   public class ClienteRepo
    {


		public void Excluir(int Id)
		{
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "DELETE CLIENTE WHERE id_cliente = @ID";
				conn.Execute(script, new { @ID = Id });
			}
		}

		public List<Cliente> Pesquisar(string filtro)
		{
			List<Cliente> cliente;
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "SELECT id_cliente Id,nm_empresa empresa,ds_email email,num_cnpj cnpj,num_telefone telefone,num_celular celular,ds_endereco endereco,ds_numero n,nm_bairro bairro,nm_cidade cidade,nm_estado estado,fl_status ativo,dt_status datastatus,ds_cep cep,ds_complemento complemento " +
				 "FROM CLIENTE WHERE nm_Empresa like '%' + @FILTRO + '%' OR num_cnpj like '%' + @FILTRO + '%' ";



				cliente = conn.Query<Cliente>(script, new { @FILTRO = filtro }).ToList();
			}
			return cliente;
		}
		public List<Cliente> Pesquisar()
		{
			List<Cliente> cliente;
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "SELECT id_cliente Id,nm_empresa empresa,ds_email email,num_cnpj cnpj,num_telefone telefone,num_celular celular,ds_endereco endereco,ds_numero n,nm_bairro bairro,nm_cidade cidade,nm_estado estado,fl_status ativo,dt_status datastatus,ds_cep cep,ds_complemento complemento " +
				 "FROM CLIENTE ";



				cliente = conn.Query<Cliente>(script).ToList();
			}
			return cliente;
		}
		public Cliente PesquisarPorId(int id)
		{
			Cliente cliente;
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "SELECT id_cliente Id,nm_empresa empresa,ds_email email,num_cnpj cnpj,num_telefone telefone,num_celular celular,ds_endereco endereco,ds_numero n,nm_bairro bairro,nm_cidade cidade,nm_estado estado,fl_status ativo,dt_status datastatus,ds_cep cep,ds_complemento complemento " +
				 "FROM CLIENTE WHERE [id_cliente] = @ID ";



				cliente = conn.QueryFirstOrDefault<Cliente>(script, new { @ID = id });
			}
			return cliente;
		}


		public void Inserir(Cliente cliente)
		{
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{

				string script = "INSERT INTO Cliente (nm_empresa,ds_email,num_cnpj,num_telefone,num_celular,ds_endereco,ds_numero,nm_bairro,nm_cidade,nm_estado,fl_status,dt_status,ds_cep,ds_complemento) " +
				"VALUES(@EMPRESA,@EMAIL,@CNPJ,@TELEFONE,@CELULAR,@ENDERECO,@N,@BAIRRO,@CIDADE,@ESTADO,@ATIVO,@DATASTATUS,@CEP,@COMPLEMENTO); SELECT scope_identity()";

				int id = conn.QueryFirst<int>(script, new
				{
					@EMPRESA = cliente.Empresa,
					@EMAIL = cliente.Email,
					@CNPJ = cliente.Cnpj,
					@TELEFONE = cliente.Telefone,
					@CELULAR = cliente.Celular,
					@ENDERECO = cliente.Endereco,
					@N = cliente.N,
					@BAIRRO = cliente.Bairro,
					@CIDADE = cliente.Cidade,
					@ESTADO = cliente.Estado,
					@ATIVO = cliente.Ativo,
					@DATASTATUS = cliente.DataStatus,
					@CEP = cliente.Cep,
					@COMPLEMENTO = cliente.Complemento,
				});
				cliente.Id = id;

			}




		}
		public void Alterar(Cliente cliente)
		{
			//abro a conexao
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "UPDATE Cliente SET nm_empresa = @EMPRESA,ds_email = @EMAIL,num_cnpj = @CNPJ,num_telefone = @TELEFONE,num_celular = @CELULAR,ds_endereco = @ENDERECO,ds_numero = @N,nm_bairro = @BAIRRO,nm_cidade = @CIDADE,nm_estado = @ESTADO,fl_status = @ATIVO,dt_status = @DATASTATUS,ds_cep =@CEP,ds_complemento = @COMPLEMENTO WHERE id_cliente = @ID";


				conn.Execute(script, new
				{

					@EMPRESA = cliente.Empresa,
					@EMAIL = cliente.Email,
					@CNPJ = cliente.Cnpj,
					@TELEFONE = cliente.Telefone,
					@CELULAR = cliente.Celular,
					@ENDERECO = cliente.Endereco,
					@N = cliente.N,
					@BAIRRO = cliente.Bairro,
					@CIDADE = cliente.Cidade,
					@ESTADO = cliente.Estado,
					@ATIVO = cliente.Ativo,
					@DATASTATUS = cliente.DataStatus,
					@CEP = cliente.Cep,
					@COMPLEMENTO = cliente.Complemento,
					@ID = cliente.Id,
				});
			}
		}

	}
}
