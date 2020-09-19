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
    public class EstoqueRepo
    {
        public void Inserir(Estoque estoque)
        {
            //abro conexão
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "INSERT INTO ESTOQUE (nm_peca, qda_peca, vl_peca) " +
					"VALUES (@PECA ,@QPECA, @VPECA); SELECT scope_identity()";

				int id = conn.QueryFirst<int>(script, new
				{

                    @PECA = estoque.Peca,
                    @QPECA = estoque.Quantidade,
                    @VPECA = estoque.Valor,

                });
				estoque.Id = id;

            }
        }

        public List<Estoque> Pesquisar(string filtro)
        {
            List<Estoque> estoque;
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "SELECT id_Estoque Id,nm_peca Peca,qda_peca Quantidade,vl_peca Valor " +
                 "FROM ESTOQUE WHERE nm_peca like '%' + @FILTRO + '%' OR qda_peca like '%' + @FILTRO + '%' ";
                estoque = conn.Query<Estoque>(script, new { @FILTRO = filtro }).ToList();
            }
            return estoque;
        }

        public List<Estoque> Pesquisar()
        {
            List<Estoque> estoque;
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "SELECT id_Estoque Id,nm_peca Peca,qda_peca Quantidade,vl_peca Valor " +
                 "FROM ESTOQUE";
                estoque = conn.Query<Estoque>(script).ToList();
            }
            return estoque;
        }


        public Estoque PesquisarPorId(int id)
        {
           
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                return conn.QueryFirstOrDefault<Estoque>("SELECT id_Estoque Id,nm_peca Peca,qda_peca Quantidade,vl_peca Valor " +
                 "FROM ESTOQUE WHERE id_Estoque  = @ID", new { @ID = id }); 
               
            }
           
        }


        public void Alterar(Estoque estoque)
        {
            //abro a conexao
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "UPDATE ESTOQUE SET nm_peca = @PECA,qda_peca = @QPECA,vl_peca = @VPECA WHERE id_Estoque = @ID";


                conn.Execute(script, new
                {

                    @PECA = estoque.Peca,
                    @QPECA = estoque.Quantidade,
                    @VPECA = estoque.Valor,
                    @ID = estoque.Id,
                });
            }
        }

        public void Excluir(int Id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "DELETE ESTOQUE WHERE id_Estoque = @ID";
                conn.Execute(script, new { @ID = Id });
            }
        }
    }


}
