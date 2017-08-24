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
        private readonly IAndarService _andarService;
        public ComputadorController(IImobilizadoService service, IAndarService andarService)
        {
            _service = service;
            _andarService = andarService;
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
                listaComputador = _service.GetAll<ComputadorModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaComputador;
        }

        [HttpGet]
        
        // GET api/<controller>
        public IEnumerable<ComputadorModel> Livres()
        {
            List<ComputadorModel> listaComputador = null;
            try
            {
                listaComputador = _service.ObterLivres<ComputadorModel>();

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
                computador = _service.GetById<ComputadorModel>(id);
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
                if (VerificarAndar(computador.Andar))
                {
                    _service.Update(computador);
                    result = Ok();
                }
                else
                    result = BadRequest();
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
                if (VerificarAndar(computador.Andar))
                {
                    _service.Add(computador);
                    result = Ok();
                }
                else
                    result = BadRequest();
            }
            catch (Exception ex)
            {
                result = InternalServerError(ex);
            }

            return result;
        }

        private bool VerificarAndar(AndarModel andar)
        {
            if (andar == null)
                return true;

            var andarValidacao = _andarService.GetById<AndarModel>(andar.Id);

            return (andarValidacao != null);
        }
    }
}