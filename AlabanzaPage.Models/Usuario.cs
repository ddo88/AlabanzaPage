using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabanzaPage.Models
{
    public class Usuario
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        //public List<string> Roles { get; set; }
        public string Role { get; set; }

        //string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey
    }
}
