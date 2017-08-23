using MongoDB.Bson.Serialization.Attributes;
using Stone.Imobilizado.Repository.Model.Enum;

namespace Stone.Imobilizado.Repository.Model
{
    [BsonKnownTypes(typeof(Computador))]
    public abstract class ImobilizadoModel
    {
        [BsonElement("_id")]
        public string Id { get; set; }

        public string Nome { get; set; }

        public AndarEnum Andar { get; set; }
    }
}
