using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcApplication2.Models
{
    public class Lista
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string        Id        { get; set; }
        public string        IdUsuario { get; set; }
        public List<Cancion> Canciones { get; set; }
        public DateTime      Fecha     { get; set; }
    }
}