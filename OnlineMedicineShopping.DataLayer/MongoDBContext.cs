using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMedicineShopping.DataLayer
{
    public class MongoDBContext : IMongoDBContext
    {
        /// <summary>
        /// Cearting IMongoDatabase, MongoClient setter or getter property and injecting 
        /// in ContextConstructor and using two Setting setter getter bring him databse and connection
        /// </summary>
        private IMongoDatabase _mongoDatabase { get; set; }
        private MongoClient _mongoClient { get; set; }
        private IClientSessionHandle SessionHandle { get; set; }
        public MongoDBContext(IOptions<Mongosettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);
            _mongoDatabase = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _mongoDatabase.GetCollection<TEntity>(name);
        }
    }
}
