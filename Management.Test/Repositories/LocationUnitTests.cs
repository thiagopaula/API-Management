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
    public class LocationUnitTests
    {
        private Location location;
        private readonly IMongoDatabase _database;
        private LocationRepository LocationRepository;

        public LocationUnitTests()
        {
            _database = new MongoClient("mongodb://thiago:82585632A@ds213513.mlab.com:13513/db-projeto").GetDatabase("db-projeto");
           // LocationRepository = new LocationRepository(_database);
        }

        [TestInitialize]
        public void Initialize()
        {
            location = new Location
            {
                //Id = ObjectId.GenerateNewId(),
                Name = "Cinemark Botafogo",
                ResumeName = "Sala 10",
                TheaterId = "5c46631b733f4719b4d4a1bb",
                Enabled = true
            };
        }

        [TestMethod]
        public async Task LocationCrud()
        {
            await Create();
            await GetByIdAsync();
            await GetAllAsync();
            await UpdateAsync();
        }


        public async Task Create()
        {
            if (LocationRepository != null)
            {
                try
                {
                    await LocationRepository.Create(location);
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
            if (LocationRepository != null)
            {
                try
                {
                    var result = await LocationRepository.GetAsync(location.Id.ToString());

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
            if (LocationRepository != null)
            {
                try
                {
                    var result = await LocationRepository.FindAllAsync();

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
            if (LocationRepository != null)
            {

                try
                {
                    location.Enabled = false;
                    await LocationRepository.UpdateAsync(location);

                    var result = await LocationRepository.GetAsync(location.Id.ToString());

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
