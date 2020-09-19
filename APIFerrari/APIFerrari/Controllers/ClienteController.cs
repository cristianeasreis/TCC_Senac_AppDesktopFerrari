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
	public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IHttpActionResult Get()
        {
			try
			{
				ClienteRepo clienteRepo = new ClienteRepo();
				var cliente = clienteRepo.Pesquisar();
				return Ok(cliente);
			}
			catch(Exception ex)
			{
				return InternalServerError(ex);
			}
        }

        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
			try
			{
				ClienteRepo clienteRepo = new ClienteRepo();
				var cliente = clienteRepo.PesquisarPorId(id);
				
				if (cliente != null)
				{
					return Ok(cliente);

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

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Cliente cliente)
        {
			cliente.DataStatus = DateTime.Now; 
			try
			{
				ClienteRepo clienteRepo = new ClienteRepo();
				clienteRepo.Inserir(cliente);
				return Ok(cliente);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente)
        {
			cliente.DataStatus = DateTime.Now;
			try
			{
				ClienteRepo clienteRepo = new ClienteRepo();
				cliente.Id = id;
				clienteRepo.Alterar(cliente);
				return Ok(cliente);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// DELETE: api/Cliente/5
		public IHttpActionResult Delete(int id)
        {
			try
			{
				ClienteRepo clienteRepo = new ClienteRepo();
			
				clienteRepo.Excluir(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
    }
}
