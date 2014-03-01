using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcApplication2.Models
{
    public class Cancion
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public Object Id     { get; set; }
        public string Nombre { get; set; }
        public string Tipo   { get; set; }
        public DateTime UltimaVez { get; set; }
    }
}