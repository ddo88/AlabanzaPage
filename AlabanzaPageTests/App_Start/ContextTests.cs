using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace AlabanzaPage.App_Start.Tests
{
    [TestClass()]
    public class ContextTests
    {
        [TestMethod()]
        public void GetCollectionTest()
        {
            try
            {
                Context c = Context.GetInstance();
                var r = c.GetCollection<BsonDocument>("canciones").FindAll();
                foreach (var a in r)
                {
                    try
                    {
                        Cancion c2 = BsonSerializer.Deserialize<Cancion>(a);    
                    }
                    catch (Exception ex)
                    {
                    }
                    
                }
                
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
