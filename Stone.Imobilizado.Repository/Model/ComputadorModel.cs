using MongoDB.Bson.Serialization.Attributes;

namespace Stone.Imobilizado.Repository.Model
{
    
    [BsonDiscriminator]
    public class ComputadorModel: ImobilizadoModel
    {

    }
}
