using Domain.Entities;
using Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoContext Context;
        protected readonly IMongoCollection<T> Collection;

        public AbstractRepository(IMongoContext context)
        {
            Context = context;
            Collection = Context.GetCollection<T>();
        }

        public async Task Create(T model)
        {
            await Collection.InsertOneAsync(model);
        }

        public async Task<T> GetAsync(string id)
        {

            //if (!ObjectId.TryParse(id, out ObjectId internalId))
            //    return null;

            var filter = Builders<T>.Filter.Eq("_id", id);

            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await Collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task Update(string id, T obj)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await Collection.ReplaceOneAsync(filter, obj);
        }

        public async Task Delete(string id)
        {
            //if (ObjectId.TryParse(id, out ObjectId internalId))
            //{
                var filter = Builders<T>.Filter.Eq("_id", id);
                await Collection.DeleteOneAsync(filter);
           // }
        }
    }
}
