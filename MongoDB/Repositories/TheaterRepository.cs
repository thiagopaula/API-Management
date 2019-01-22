using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public class TheaterRepository : AbstractRepository<Theater>, ITheaterRepository
    {
        public TheaterRepository([Inject()]IMongoDatabase _database) : base(_database, "theaters") { }

        public async Task Create(Theater theater)
        {
            if (theater.Id == null)
            {
                theater.Id = ObjectId.GenerateNewId();
            }
            await Collection.InsertOneAsync(theater);
        }

        public async Task UpdateAsync(Theater theater)
        {
            var filter = Builders<Theater>.Filter.Eq(x => x.Id, theater.Id);
            await Collection.ReplaceOneAsync(filter,theater);
        }        
    }
}
