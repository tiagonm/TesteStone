using Stone.Imobilizado.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Imobilizado.Service.Base
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        void Delete(string id);
        void Update(T entity);
        List<_T> Get<_T>(Expression<Func<T, bool>> filter = null);
        _T GetById<_T>(string id);
        List<_T> GetAll<_T>();
    }
}
