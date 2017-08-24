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
        public IEnumerable<ComputadorModel> Get()
        {
            List<ComputadorModel> listaComputador = null;
            try
            {
                listaComputador = _service.Get<ComputadorModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaComputador;
        }
        [HttpGet]
        // GET api/<controller>/5
        public ComputadorModel Get(string id)
        {
            ComputadorModel computador = null;
            try
            {
                computador = _service.Get<ComputadorModel>(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return computador;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]ComputadorModel computador)
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
        public IHttpActionResult Put([FromBody]ComputadorModel computador)
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