using Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected IMongoCollection<T> Collection;
        protected IMongoCollection<T> CollectionSearch;
        protected IMongoDatabase Database;

        public AbstractRepository(IMongoDatabase database, string collection)
        {
            Database = database;
            Collection = database.GetCollection<T>(collection);
        }

        public async Task<T> GetAsync(string id)
        {

            if (!ObjectId.TryParse(id, out ObjectId internalId))
                return null;

            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));

            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await Collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task Delete(string id)
        {
            if (ObjectId.TryParse(id, out ObjectId internalId))
            {
                var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                await Collection.DeleteOneAsync(filter);
            }
        }
    }
}
