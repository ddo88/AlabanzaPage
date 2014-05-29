using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfTest.Properties;

namespace WpfTest
{
    public class Context
    {
        public MongoDatabase Database;

        public Context()
        {
            var client = new MongoClient(Settings.Default.ConnectionMongo);
            var server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.Db);
        }

        public MongoCollection<T> GetCollection<T>(string collection)
        {
            return Database.GetCollection<T>(collection);            
        }
                
    }
}
