using Stone.Imobilizado.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Stone.Imobilizado.Repository;

namespace Stone.Imobilizado.Service
{
    public class ImobilizadoService : IImobilizadoService
    {
        private readonly IImobilizadoRepository _repository;
        public ImobilizadoService(IImobilizadoRepository repository)
        {
            _repository = repository;
        }
        public void Add(ImobilizadoModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _repository.Add(entity);
        }

        public void Delete(string id)
        {
            _repository.Delete(i => i.Id, id);
        }

        public List<T> Get<T>(Expression<Func<ImobilizadoModel, bool>> filter = null)
        {
            return _repository.Get<T>(filter);
        }

        public void Update(ImobilizadoModel entity)
        {
            _repository.Update(i => i.Id, entity, entity.Id);
        }
    }
}
