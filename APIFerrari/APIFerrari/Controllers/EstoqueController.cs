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
    public class EstoqueController : ApiController
    {
        // GET: api/Estoque
        public IHttpActionResult Get()
        {
            try
            {
                EstoqueRepo estoqueRepo = new EstoqueRepo();
                var estoque = estoqueRepo.Pesquisar();
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Estoque/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                EstoqueRepo estoqueRepo = new EstoqueRepo();
                var estoque = estoqueRepo.PesquisarPorId(id);
				if(estoque != null )
				{
                return Ok(estoque);

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



        // POST: api/Estoque
        public IHttpActionResult Post([FromBody]Estoque estoque)
        {
            try
            {
                EstoqueRepo estoqueRepo = new EstoqueRepo();
                estoqueRepo.Inserir(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Estoque/5
        public IHttpActionResult Put(int id, [FromBody]Estoque estoque)
        {
            try
            {
                EstoqueRepo estoqueRepo = new EstoqueRepo();
                estoque.Id = id;
                estoqueRepo.Alterar(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Estoque/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EstoqueRepo estoqueRepo = new EstoqueRepo();
                estoqueRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
        }
    }
}
