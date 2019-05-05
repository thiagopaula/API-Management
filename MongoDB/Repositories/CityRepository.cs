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
        public CityRepository([Inject]IMongoContext context) : base(context)
        {
        }

   

        //[Inject]
        //public static IConfigurationCollection ConfigurationCollection { get; set; }
        ////[Inject]
        ////public static IMongoDatabase Database { get; set; }



        //public CityRepository(IMongoDatabase _database, IConfigurationCollection configurationCollection)
        //    : base(_database, ConfigurationCollection)
        //{
        //    ConfigurationCollection = configurationCollection;
        //}

        //public async Task Create(City city)
        //{
        //    city.Id = ObjectId.GenerateNewId();

        //    await Collection.InsertOneAsync(city);
        //}

        public async Task UpdateAsync(City city)
        {
            var filter = Builders<City>.Filter.Eq(x => x.Id, city.Id);
            await Collection.ReplaceOneAsync(filter, city);
        }
    }
}
