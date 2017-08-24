using System;
using MongoDB.Bson.Serialization.Attributes;
using Stone.Imobilizado.Repository.Model.Enum;

namespace Stone.Imobilizado.Repository.Model
{
    [BsonKnownTypes(typeof(ComputadorModel))]
    public abstract class ImobilizadoModel: ModelBase
    {
      

        public string Nome { get; set; }

        public AndarModel Andar { get; set; }

       
    }
}
