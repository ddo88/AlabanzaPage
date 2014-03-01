using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MvcApplication2.Models
{
    public class ViewModel
    {

        public List<Cancion> Canciones { get; set; }


        public ViewModel()
        {

        }

        public ViewModel(bool sw)
        {
            try{
                Canciones= new List<Cancion>();
                //string s = @"mongodb://pagiel:a1b2c3d4@ds030817.mongolab.com:30817/alabanza";
                string s = "mongodb://127.0.0.1:27017";
                MongoClient mc = new MongoClient(s);
                MongoServer server = mc.GetServer();
                MongoDatabase db = server.GetDatabase("alabanza");

                MongoCollection<Cancion> _evento = db.GetCollection<Cancion>("Canciones");

                foreach (var a in _evento.FindAll())
                {
                    Canciones.Add(a);    
                }
            }
            catch (Exception ex) { }
            
        }



    }
}