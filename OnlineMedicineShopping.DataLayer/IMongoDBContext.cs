using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMedicineShopping.DataLayer
{
    public interface IMongoDBContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
