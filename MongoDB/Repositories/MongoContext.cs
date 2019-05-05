using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDbGenericRepository.Attributes;
using MongoDbGenericRepository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MongoDB.Repositories
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }

        public MongoContext(IConfiguration configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            RegisterConventions();

            // Configure mongo
            var mongoClient = new MongoClient(configuration.GetSection("MongoConnection:ConnectionString").Value);
            Database = mongoClient.GetDatabase(configuration.GetSection("MongoConnection:Database").Value);

        }


        public IMongoCollection<TDocument> GetCollection<TDocument>()
        {
            return Database.GetCollection<TDocument>(GetCollectionName<TDocument>());
        }

        public string GetCollectionName<TDocument>()
        {
            return GetAttributeCollectionName<TDocument>() ?? Pluralize<TDocument>();
        }

        public string Pluralize<TDocument>()
        {
            return (typeof(TDocument).Name.Pluralize()).Camelize();
        }

        public string GetAttributeCollectionName<TDocument>()
        {
            return (typeof(TDocument).GetTypeInfo()
                                     .GetCustomAttributes(typeof(CollectionNameAttribute))
                                     .FirstOrDefault() as CollectionNameAttribute)?.Name;
        }

        public IMongoCollection<City> City
        {
            get
            {
                return Database.GetCollection<City>("cities");
            }
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true)
        };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }   

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
