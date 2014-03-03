using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MvcApplication2.Controllers;
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


        public static bool ValidateUser(string user, string password,ref Persona p)
        {
            string s = "mongodb://127.0.0.1:27017";
            MongoClient mc = new MongoClient(s);
            MongoServer server = mc.GetServer();
            MongoDatabase dbase = server.GetDatabase("alabanza");
            
            //Query<Persona>.EQ<bool>(x => x.User == user)
            //p = dbase.GetCollection<Persona>("Personas").FindOne(Query<Persona>.EQ<bool>(x => x.User.Equals(user)));
            p = dbase.GetCollection<Persona>("Personas").FindOne(Query.EQ("User", user));

            if (p.Pass == password.GetMD5())
                return true;

            return false;
        }
   

        public bool SaveListado(List<Cancion> canciones, string usuario,string url)
        {
            try
            {
                //Guardar el listado
                Lista l = new Lista
                    {
                        Canciones = canciones,
                        Fecha = DateTime.Now.Next(DayOfWeek.Sunday),
                        IdUsuario = usuario
                    };
                SaveLista(l);
                //Actualizar las canciones
                ActualizarFechaCanciones(canciones);
                //enviar Correo a todos los usuarios
                url = url + "List/";
                SendEmail(l,url);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private bool SendEmail(Lista l,string url)
        {
            
            MailCls mc= new MailCls("ddo88@hotmail.com","@@hellsing01");
            url = url + l.Id;
            mc.Send("ddo88@hotmail.com", l,url);
            return true;
        }

        private bool SaveLista(Lista l)
        {
            try
            {
                if (!db.CollectionExists("Lista"))
                    db.CreateCollection("Lista");
                MongoCollection<Lista> lista = db.GetCollection<Lista>("Lista");
                var a = lista.Save(l);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
            
        }

        private bool ActualizarFechaCanciones(List<Cancion> canciones)
        {
            try
            {
                foreach (var c in canciones)
                {
                    var col = db.GetCollection<Cancion>("Canciones");
                    col.Update(Query<Cancion>.EQ(x => x.Nombre, c.Nombre), Update<Cancion>.Set(x => x.UltimaVez, DateTime.Now));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Lista GetListado(string id)
        {
            try
            {
                ObjectId obj= new ObjectId(id);
                var lista = db.GetCollection<Lista>("Lista").FindOne(Query.EQ("Id", id));
                int i = 0;
                return lista;
            }
            catch (Exception ex)
            {return new Lista();
            }
            
        }
    }
}