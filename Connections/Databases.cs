using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using MongoDB.Driver;
using RecipeApp.Models;

namespace RecipeApp.Connections
{
    internal class Databases
    {
        public static MongoClient MongoConnection()
        {
            string connString = "mongodb+srv://hannafriborg:bKV1I02qOyEuMfkJ@myappdatabase.dbcslvg.mongodb.net/?retryWrites=true&w=majority";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connString));
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };
            var mongoClient = new MongoClient(settings);
            return mongoClient;
        }

        public static IMongoCollection<Customer> CustomerCollection()
        {
            var client = MongoConnection();
            var database = client.GetDatabase("MyApp");
            var collection = database.GetCollection<Customer>("MyAppDatabase");
            return collection; 
        }

        public static IMongoCollection<DbRelation> RelationsCollection()
        {
            var client = MongoConnection();
            var database = client.GetDatabase("MyAppDbRelations");
            var collection = database.GetCollection<DbRelation>("MyApp");
            return collection;
        }
    }
}
