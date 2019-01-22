using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Repositories;
using System;
using System.Threading.Tasks;

namespace Management.Test.Repositories
{
    [TestClass]
    public class MovieUnitTests
    {
        private Movie movie;
        private readonly IMongoDatabase _database;
        private MovieRepository MovieRepository;

        public MovieUnitTests()
        {
            _database = new MongoClient("mongodb://thiago:82585632A@ds213513.mlab.com:13513/db-projeto").GetDatabase("db-projeto");
            MovieRepository = new MovieRepository(_database);
        }

        [TestInitialize]
        public void Initialize()
        {
            movie = new Movie
            {
                Id = ObjectId.GenerateNewId(),
                Title = "hahahaha",
                Duration = 120,
                Sinopsis = "juhjkhjkhjkha",
                Directors = "jkhjkkjkj",
                Year = 2018,
                Priority = 4,
                Enabled = true,
            };
        }


        [TestMethod]
        public async Task MovieCrud()
        {
            await Create();
            await GetByIdAsync();
            await GetAllAsync();
            await UpdateAsync();
        }


        public async Task Create()
        {
            if (MovieRepository != null)
            {
                try
                {
                    await MovieRepository.Create(movie);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        public async Task GetByIdAsync()
        {
            if (MovieRepository != null)
            {
                try
                {
                    var result = await MovieRepository.GetAsync(movie.Id.ToString());

                    Assert.IsNotNull(result);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        public async Task GetAllAsync()
        {
            if (MovieRepository != null)
            {
                try
                {
                    var result = await MovieRepository.FindAllAsync();

                    Assert.IsNotNull(result);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        public async Task UpdateAsync()
        {
            if (MovieRepository != null)
            {

                try
                {
                    movie.Enabled = false;
                    await MovieRepository.UpdateAsync(movie);

                    var result = await MovieRepository.GetAsync(movie.Id.ToString());

                    Assert.IsNotNull(result);
                    Assert.IsFalse(result.Enabled);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
