using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcApplication2.Models
{
    public class Persona
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string       Id      { get; set; }
        public string       User    { get; set; }
        public string       Pass    { get; set; }
        public List<string> Roles   { get; set; }
    }
}