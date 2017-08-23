using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Stone.Imobilizado.Repository.Model;
using MongoDB.Driver;

namespace Stone.Imobilizado.Repository
{
    public class ImobilizadoRepository : IImobilizadoRepository
    {
        private IMongoDatabase _database;
        private IMongoCollection<Model.ImobilizadoModel> _collection;

        public ImobilizadoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            _database = client.GetDatabase("Imobilizados");
            this._collection = _database.GetCollection<ImobilizadoModel>("Imobilizados");
        }


        public void Add(ImobilizadoModel entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(Expression<Func<ImobilizadoModel, string>> queryExpression, string id)
        {
            var filter = Builders<ImobilizadoModel>.Filter.Eq(queryExpression, id);
            _collection.FindOneAndDelete<ImobilizadoModel>(filter);
        }

        public void Update(Expression<Func<ImobilizadoModel, string>> queryExpression, ImobilizadoModel entity)
        {
            var filter = Builders<ImobilizadoModel>.Filter.Eq(queryExpression, entity.Id);
            _collection.FindOneAndReplace<ImobilizadoModel>(filter, entity);

        }

        public List<T> Get<T>(Expression<Func<ImobilizadoModel, bool>> filter = null)
        {
            var lista = _collection.AsQueryable<ImobilizadoModel>().Where(filter).OfType<T>();

            return lista.ToList<T>();
        }
    }
}
