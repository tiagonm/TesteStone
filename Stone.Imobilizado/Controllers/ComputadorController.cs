using Stone.Imobilizado.Repository.Model;
using Stone.Imobilizado.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stone.Imobilizado.Controllers
{
    public class ComputadorController : ApiController
    {
        private readonly IImobilizadoService _service;

        public ComputadorController(IImobilizadoService service)
        {
            _service = service;
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            IHttpActionResult result = null;
            try
            {
                _service.Delete(id);
                result = Ok();
            }
            catch (Exception ex)
            {
                result = InternalServerError(ex);
            }

            return result;
        }

        [HttpGet]
        // GET api/<controller>
        public IEnumerable<Computador> Get()
        {
            List<Computador> listaComputador = null;
            try
            {
                listaComputador = _service.Get<Computador>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaComputador;
        }
        [HttpGet]
        // GET api/<controller>/5
        public Computador Get(string id)
        {
            Computador computador = null;
            try
            {
                computador = _service.Get<Computador>(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return computador;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Computador computador)
        {
            IHttpActionResult result = null;
            try
            {
                _service.Update(computador);
                result = Ok();
            }
            catch (Exception ex)
            {
                result = InternalServerError(ex);
            }

            return result;
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]Computador computador)
        {
            IHttpActionResult result = null;
            try
            {                
                _service.Add(computador);
                result = Ok();
            }
            catch (Exception ex)
            {
                result = InternalServerError(ex);
            }

            return result;
        }


    }
}