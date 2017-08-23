using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Stone.Imobilizado.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);        
        void Delete(Expression<Func<T, string>> queryExpression, string id);
        void Update(Expression<Func<T, string>> queryExpression, T entity);
        List<_T> Get<_T>(Expression<Func<T, bool>> filter = null);
    }
}
