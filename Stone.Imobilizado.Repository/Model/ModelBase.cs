using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Imobilizado.Repository.Model
{
    public class ModelBase
    {
        [BsonElement("_id")]
        public string Id { get; set; }
    }
}
