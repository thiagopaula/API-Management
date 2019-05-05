using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public class LocationRepository : AbstractRepository<Location>, ILocationRepository
    {
        public LocationRepository([Inject()]IMongoContext _database) : base(_database/*, "location"*/) { }

        //public LocationRepository()
        //{

        //}

        //public async Task Create(Location location)
        //{
        //    if (location.Id == null)
        //    {
        //        location.Id = ObjectId.GenerateNewId();
        //    }
        //    await Collection.InsertOneAsync(location);
        //}

        public async Task<List<Location>> GetByTheaterId(string id)
        {
           return await Collection.Find(x => x.TheaterId == id).ToListAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            var filter = Builders<Location>.Filter.Eq(x => x.Id, location.Id);
            await Collection.ReplaceOneAsync(filter, location);
        }
    }
}
