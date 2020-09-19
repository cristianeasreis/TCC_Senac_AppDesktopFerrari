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
    public class AgendamentoRepo
    {
        public void Inserir(Agendamento agendamento)
        {
            //abro conexão
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "INSERT INTO AgendamentoVisita (dt_visita,ds_servico,ds_maquina,nm_marca,id_usuario," +
                    "vl_sevico,dt_sevico, fl_status,dt_status,nm_empresa) " +
					"VALUES(@Visita,@DServico,@DsMaquina,@Mmaquina,@Usuario,@VlServiço,@DTServico,@ATIVO,@DATASTATUS,@Nome); SELECT scope_identity()";





				int id = conn.QueryFirst<int>(script, new
				{
                    @Visita = agendamento.Visita,
                    @DServico = agendamento.DServiço,
                    @DsMaquina = agendamento.DsMaquina,
                    @Mmaquina = agendamento.Mmaquina,
                    @Usuario = agendamento.IdUsuario,
                    @VlServiço = agendamento.VlServiço,
                    @DTServico = agendamento.DTServico,
                    @ATIVO = agendamento.Ativo,
                    @DATASTATUS = agendamento.DateStatus,
                    @Nome = agendamento.Nome

                });
				agendamento.Id = id;
            }

        }

        public List<Agendamento> Pesquisar(string filtro)
        {
            List<Agendamento> agendamento;
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "SELECT id_AgendamentoVisita Id,dt_visita Visita,ds_servico DServiço,ds_maquina DsMaquina,nm_marca Mmaquina,id_usuario idUsuario,vl_sevico VlServiço,dt_sevico DTServico,fl_status Ativo,dt_status DateStatus,nm_Empresa Nome " +
                    "FROM AgendamentoVisita WHERE dt_visita like '%' + @FILTRO + '%' OR vl_sevico like '%' + @FILTRO + '%' ";


                agendamento = conn.Query<Agendamento>(script, new { @FILTRO = filtro }).ToList();
            }
            return agendamento;
        }

		public Agendamento PesquisarPorId(int id)
		{
			Agendamento agendamento;
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "SELECT id_AgendamentoVisita Id,dt_visita Visita,ds_servico DServiço,ds_maquina DsMaquina,nm_marca Mmaquina,id_usuario idUsuario,vl_sevico VlServiço,dt_sevico DTServico,fl_status Ativo,dt_status DateStatus,nm_Empresa Nome " +
					"FROM AgendamentoVisita WHERE [id_AgendamentoVisita] = @ID ";


				agendamento = conn.QueryFirstOrDefault<Agendamento>(script, new { @ID = id });
			}
			return agendamento;
		}

		public List<Agendamento> Pesquisar()
		{
			List<Agendamento> agendamento;
			using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
			{
				string script = "SELECT id_AgendamentoVisita Id,dt_visita Visita,ds_servico DServiço,ds_maquina DsMaquina,nm_marca Mmaquina,id_usuario idUsuario,vl_sevico VlServiço,dt_sevico DTServico,fl_status Ativo,dt_status DateStatus,nm_Empresa Nome " +
					"FROM AgendamentoVisita  ";


				agendamento = conn.Query<Agendamento>(script).ToList();
			}
			return agendamento;
		}
		public void Alterar(Agendamento agendamento)
        {
            //abro a conexao
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "UPDATE AgendamentoVisita SET dt_visita = @Visita," +
                    "ds_servico =  @DServico,ds_maquina = @DsMaquina,nm_marca = @Mmaquina,id_usuario = @Usuario," +
                    "vl_sevico = @VlServiço,dt_sevico = @DTServico,fl_status = @ATIVO,dt_status = @DATASTATUS,nm_empresa = @Nome WHERE id_AgendamentoVisita = @ID";


                conn.Execute(script, new
                {

                    @Visita = agendamento.Visita,
                    @DServico = agendamento.DServiço,
                    @DsMaquina = agendamento.DsMaquina,
                    @Mmaquina = agendamento.Mmaquina,
                    @Usuario = agendamento.IdUsuario,
                    @VlServiço = agendamento.VlServiço,
                    @DTServico = agendamento.DTServico,
                    @ATIVO = agendamento.Ativo,
                    @DATASTATUS = agendamento.DateStatus,
                    @Nome = agendamento.Nome,
                    @ID = agendamento.Id
                });
            }

        }
        public void Excluir(int Id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConsultarConexao()))
            {
                string script = "DELETE AgendamentoVisita WHERE id_AgendamentoVisita = @ID";
                conn.Execute(script, new { @ID = Id });
            }
        }
    }
}
