using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcApplication1.Models
{
    public class Cancion
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime UltimaVez { get; set; }
    }

    //public class Cancion
    //{
    //    public string Nombre          { get; set; }
    //    public string Tipo            { get; set; }
    //    public DateTime UltimoDomingo { get; set; }
    //}

    public class ViewModel {

        public List<Cancion> Canciones { get; set; }
     

        public ViewModel()
        {
            
        }

        public ViewModel(bool sw)
        {
            Canciones = new List<Cancion>();
            Cancion c1 = new Cancion();
            c1.Nombre = "";
            c1.Tipo = "";
            c1.UltimaVez = DateTime.Now;
            Cancion c2 = new Cancion();
            c2.Nombre = "";
            c2.Tipo = "";
            c2.UltimaVez = DateTime.Now;
            Cancion c3 = new Cancion();
            c3.Nombre = "";
            c3.Tipo = "";
            c3.UltimaVez = DateTime.Now;
            Cancion c4 = new Cancion();
            c4.Nombre = "";
            c4.Tipo = "";
            c4.UltimaVez = DateTime.Now;
            Canciones.Add(c1);
            Canciones.Add(c2);
            Canciones.Add(c3);
            Canciones.Add(c4);
        }

     

    }


   
}