using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
    {
        public MovieRepository([Inject()]IMongoContext _database) : base(_database/*, "movie"*/) { }

        //public MovieRepository()
        //{

        //}


        //public async Task Create(Movie movie)
        //{
        //    if (movie.Id == null)
        //    {
        //        movie.Id = ObjectId.GenerateNewId();
        //    }
        //    await Collection.InsertOneAsync(movie);
        //}

        public async Task UpdateAsync(Movie movie)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.Id, movie.Id);
            await Collection.ReplaceOneAsync(filter, movie);
        }
    }
}
