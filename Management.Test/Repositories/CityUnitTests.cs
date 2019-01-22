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
    public class CityUnitTests
    {

        private City city;
        private readonly IMongoDatabase _database;
        private CityRepository CityRepository;

        public CityUnitTests()
        {
            _database = new MongoClient("mongodb://thiago:82585632A@ds213513.mlab.com:13513/db-projeto").GetDatabase("db-projeto");
            CityRepository = new CityRepository(_database);
        }

        [TestInitialize]
        public void Initialize()
        {
            city = new City
            {
                Id = ObjectId.GenerateNewId(),
                Name = "hahahaha",
                TimeZone = "America/Sao_Paulo",                
                State = "Rio de Janeiro",
                UF = "RJ",
                Enabled = true,
            };
        }


        [TestMethod]
        public async Task CityCrud()
        {
            await Create();
            await GetByIdAsync();
            await GetAllAsync();
            await UpdateAsync();
        }


        public async Task Create()
        {
            if (CityRepository != null)
            {
                try
                {
                    await CityRepository.Create(city);
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
            if (CityRepository != null)
            {
                try
                {
                    var result = await CityRepository.GetAsync(city.Id.ToString());

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
            if (CityRepository != null)
            {
                try
                {
                    var result = await CityRepository.FindAllAsync();

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
            if (CityRepository != null)
            {

                try
                {
                    city.Enabled = false;
                    await CityRepository.UpdateAsync(city);

                    var result = await CityRepository.GetAsync(city.Id.ToString());

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
