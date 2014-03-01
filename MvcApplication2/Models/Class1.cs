using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MvcApplication2.Helpers;

namespace MvcApplication2.Models
{
    public class Db
    {
        private MongoDatabase db;

        public Db()
        {
            string      s      = "mongodb://127.0.0.1:27017";
            MongoClient mc     = new MongoClient(s);
            MongoServer server = mc.GetServer();
            db                 = server.GetDatabase("alabanza");
        }

        public bool SaveListado(List<Cancion> canciones, string usuario)
        {
            try
            {
                //Guardar el listado
                //SaveLista(new Lista
                //    {
                //        Canciones = canciones,
                //        Fecha     = DateTime.Now.Next(DayOfWeek.Sunday),
                //        IdUsuario = usuario
                //    });
                //Actualizar las canciones
                ActualizarFechaCanciones(canciones);
                //enviar Correo a todos los usuarios

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private bool SendEmail(Lista l)
        {

            return true;
        }

        private bool SaveLista(Lista l)
        {
            if (!db.CollectionExists("Lista"))
                db.CreateCollection("Lista");
            MongoCollection<Lista> lista = db.GetCollection<Lista>("Lista");
            lista.Save(l);
            return false;
        }

        private bool ActualizarFechaCanciones(List<Cancion> canciones)
        {
            try
            {
                foreach (var c in canciones)
                {
                    var col = db.GetCollection<Cancion>("Canciones");
                    col.Update(Query<Cancion>.EQ(x => x.Nombre, c.Nombre), Update<Cancion>.Set(x => x.UltimaVez, DateTime.Now));

                    //MongoUpdateOptions muo= new MongoUpdateOptions();
                    //muo.Flags= UpdateFlags.None;
                    //var update = Update<Cancion>.Set(x => x.UltimaVez, DateTime.Now);
                    //db.GetCollection<Cancion>("Canciones").Update(Query<Cancion>.EQ(x => x.Id, c.Id), update, muo);
                    //_caseCollection.Update(Query<Case>.EQ(x => x.Id, caseItem.Id), Update.Replace(existingDocument.Merge(caseItem.ToBsonDocument(), true)));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}