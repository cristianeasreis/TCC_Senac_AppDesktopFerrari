using FerrariEmp.lib.Modelos;
using FerrariEmp.lib.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIFerrari.Controllers

{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]


    public class AgendamentoController : ApiController
    {
        // GET: api/Agendamento
        public IHttpActionResult Get()
        {
			try
			{
				AgendamentoRepo agendamentosRepo = new AgendamentoRepo();
				var agendamentos = agendamentosRepo.Pesquisar();
				return Ok(agendamentos);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

        // GET: api/Agendamento/5
        public IHttpActionResult Get(int id)
        {
			try
			{
				AgendamentoRepo agendamentosRepo = new AgendamentoRepo();
				var agendamentos = agendamentosRepo.PesquisarPorId(id);
				
				if (agendamentos != null)
				{
					return Ok(agendamentos);

				}
				else
				{
					return StatusCode(HttpStatusCode.NoContent);
				}
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
			
        }

        // POST: api/Agendamento
        public IHttpActionResult Post([FromBody]Agendamento agendamento)
        {
			UsuarioRepo usuarioRepo = new UsuarioRepo();
			Usuario usuario = new Usuario();
			usuario = usuarioRepo.ConsultarPorEmail(User.Identity.Name);
			agendamento.IdUsuario = usuario.Id;
			agendamento.DateStatus = DateTime.Now;
			try
			{
				AgendamentoRepo agendamentosRepo = new AgendamentoRepo();
				 agendamentosRepo.Inserir(agendamento);
				return Ok(agendamento);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

        // PUT: api/Agendamento/5
        public IHttpActionResult Put(int id, [FromBody]Agendamento agendamento)
        {
			UsuarioRepo usuarioRepo = new UsuarioRepo();
			Usuario usuario = new Usuario();
			usuario = usuarioRepo.ConsultarPorEmail(User.Identity.Name);
			agendamento.IdUsuario = usuario.Id;
			agendamento.DateStatus = DateTime.Now;
			try
			{
				AgendamentoRepo agendamentosRepo = new AgendamentoRepo();
				agendamento.Id = id;
				agendamentosRepo.Alterar(agendamento);
				return Ok(agendamento);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

        // DELETE: api/Agendamento/5
        public IHttpActionResult Delete(int id)
        {
			try
			{
				AgendamentoRepo agendamentosRepo = new AgendamentoRepo();
				
				agendamentosRepo.Excluir(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
    }
}
