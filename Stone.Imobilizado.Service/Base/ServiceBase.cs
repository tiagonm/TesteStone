using Stone.Imobilizado.Repository;
using Stone.Imobilizado.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Imobilizado.Service.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
    {
        private readonly IRepositoryBase<T> _repository;
        
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public virtual void Add(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _repository.Add(entity);
        }

        public virtual void Delete(string id)
        {
            _repository.Delete(i => i.Id, id);
        }

        public virtual List<_T> Get<_T>(Expression<Func<T, bool>> filter = null)
        {
            return _repository.Get<_T>(filter);
        }

        public List<_T> GetAll<_T>()
        {
            return _repository.Get<_T>(o => true);
        }

        public _T GetById<_T>(string id)
        {
            return _repository.GetById<_T>(id);
            // return _repository.Get<_T>(o => o.Id == id).FirstOrDefault();            
        }

        public virtual void Update(T entity)
        {
            _repository.Update(i => i.Id, entity, entity.Id);
        }
    }
}
