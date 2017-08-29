using MongoDB.Driver;
using Stone.Imobilizado.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Imobilizado.Repository.Base
{
    public class RepositoryBase<T> :  IRepositoryBase<T> where T : ModelBase
    {
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        public RepositoryBase(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("Imobilizados");            
            this._collection = _database.GetCollection<T>(collectionName);
        }

        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(Expression<Func<T, string>> queryExpression, string id)
        {
            var filter = Builders<T>.Filter.Eq(queryExpression, id);
            _collection.FindOneAndDelete<T>(filter);
        }

        public void Update(Expression<Func<T, string>> queryExpression, T entity,string id)
        {
            var filter = Builders<T>.Filter.Eq(queryExpression, id);
            _collection.FindOneAndReplace<T>(filter, entity);

        }

        public List<U> Get<U>(Expression<Func<T, bool>> filter = null)
        {
            var lista = _collection.AsQueryable<T>().Where(filter).OfType<U>();

            return lista.ToList<U>();
        }

        public U GetById<U>(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var resultado = _collection.Find<T>(filter).As<U>().SingleOrDefault();

            return resultado;
        }

    }
}
