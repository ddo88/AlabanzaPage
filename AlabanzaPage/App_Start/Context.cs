using AlabanzaPage.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace AlabanzaPage.App_Start
{
    public class Context
    {
        public MongoDatabase Database;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Context));

        public Context()
        {
            var client = new MongoClient(Settings.Default.ConnectionMongo);
            var server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.Db);
            log.Info("load context");
        }

        public void RemoveCache(string key)
        {
            if (HttpRuntime.Cache[key]!=null)
                HttpRuntime.Cache.Remove(key);
        }

        public MongoCollection<T> GetCollection<T>(string collection)
        {

            if (HttpRuntime.Cache[collection] == null)
            {
                var a = Database.GetCollection<T>(collection);
                insert(collection, a);
                return a;
            }
            else
            {
                return HttpRuntime.Cache[collection] as MongoCollection<T>;
            }
        }

        private void insert(string key,object obj)
        {
            HttpRuntime.Cache.Insert( 
                /* key */ key, 
                /* value */ obj, 
                /* dependencies */ null, 
                /* absoluteExpiration */ Cache.NoAbsoluteExpiration, 
                /* slidingExpiration */ Cache.NoSlidingExpiration, 
                /* priority */ CacheItemPriority.NotRemovable, 
                /* onRemoveCallback */ null);
        }
    }
}