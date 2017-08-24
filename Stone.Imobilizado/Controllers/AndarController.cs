using Stone.Imobilizado.Repository.Model;
using Stone.Imobilizado.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Stone.Imobilizado.Controllers
{
    public class AndarController : ApiController
    {
        private readonly IAndarService _service;
        public AndarController(IAndarService service)
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
        public IEnumerable<AndarModel> Get()
        {
            List<AndarModel> listaAndar = null;
            try
            {
                listaAndar = _service.GetAll<AndarModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaAndar;
        }
        [HttpGet]
        // GET api/<controller>/5
        public AndarModel Get(string id)
        {
            AndarModel andarModel = null;
            try
            {
                andarModel = _service.GetById<AndarModel>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return andarModel;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]AndarModel andarModel)
        {
            IHttpActionResult result = null;
            try
            {
                _service.Update(andarModel);
                result = Ok();
            }
            catch (Exception ex)
            {
                result = InternalServerError(ex);
            }

            return result;
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]AndarModel andar)
        {
            IHttpActionResult result = null;
            try
            {                
                _service.Add(andar);
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