using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AlabanzaPage.Models
{
    public class Cancion
    {
        public Cancion()
        {
            // TODO: Complete member initialization
            Letra = "";
            //Acordes = "";
            Nombre = "";
        }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id            { get; set; }
        public string Nombre        { get; set; }
        public string Tipo          { get; set; }
        public string Letra         { get; set; }
        public string Observaciones { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UltimaVez   { get; set; }
    }   
}
