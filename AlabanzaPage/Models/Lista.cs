using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlabanzaPage.Models
{
    public class Lista
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string IdUsuario { get; set; }
        public List<Cancion> Canciones { get; set; }
        public List<Cancion> Sugerencias { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Fecha { get; set; }
        public bool Final { get; set; }
    }
}