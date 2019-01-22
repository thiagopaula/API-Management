using Domain.Entities;
using Domain.Interfaces.Repositories;
using MongoDB.Driver;
using LightInject;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDB.Repositories
{
    public class CityRepository : AbstractRepository<City>, ICityRepository
    {
        public CityRepository([Inject()]IMongoDatabase _database) : base(_database, "cities") { }

        public async Task Create(City city)
        {
            city.Id = ObjectId.GenerateNewId();

            await Collection.InsertOneAsync(city);
        }

        public async Task UpdateAsync(City city)
        {
            var filter = Builders<City>.Filter.Eq(x => x.Id, city.Id);
            await Collection.ReplaceOneAsync(filter, city);
        }
    }
}
