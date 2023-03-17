using System.Security.Authentication;
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
        public static IMongoDatabase GetDatabase(string databaseName) // DRY, då jag har två olika anrop på två olika databaser, men på samma MongoDB-konto, så kan de dela anropet 
        {
            var client = MongoConnection();
            var database = client.GetDatabase(databaseName);
            return database;
        }
        public static IMongoCollection<Customer> CustomerCollection()
        {
            var database = GetDatabase("MyApp");
            var collection = database.GetCollection<Customer>("MyAppDatabase");
            return collection; 
        }
        public static IMongoCollection<DbRelation> RelationsCollection()
        {
            var database = GetDatabase("MyAppDbRelations");
            var collection = database.GetCollection<DbRelation>("MyApp");
            return collection;
        }
    }
}
