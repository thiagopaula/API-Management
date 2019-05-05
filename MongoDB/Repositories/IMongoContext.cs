using MongoDB.Driver;
using System;

namespace MongoDB.Repositories
{
    public interface IMongoContext : IDisposable
    {
        IMongoCollection<TDocument> GetCollection<TDocument>();
        string GetCollectionName<TDocument>();
        string Pluralize<TDocument>();
        string GetAttributeCollectionName<TDocument>();       
    }
}
