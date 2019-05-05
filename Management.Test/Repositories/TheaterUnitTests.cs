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
    public class TheaterUnitTests
    {
        private Theater theater;
        private readonly IMongoDatabase _database;
        private TheaterRepository TheaterRepository;

        public TheaterUnitTests()
        {
            _database = new MongoClient("mongodb://thiago:82585632A@ds213513.mlab.com:13513/db-projeto").GetDatabase("db-projeto");
            //TheaterRepository = new TheaterRepository(_database);
        }

        [TestInitialize]
        public void Initialize()
        {
            theater = new Theater
            {
               // Id = ObjectId.GenerateNewId(),
                Name = "Teste 1",
                CNPJ = "454212457676577",
                Street = "Rua A",
                Number = "245",
                Complement = "Casa",
                PostalCode = 4,
                Priority = 5,
                CityId = "5c45bc64097bce7a8c7e589b",
                Enabled = true,
            };
        }


        [TestMethod]
        public async Task TheaterCrud()
        {
            await Create();
            await GetByIdAsync();
            await GetAllAsync();
            await UpdateAsync();
        }


        public async Task Create()
        {
            if (TheaterRepository != null)
            {
                try
                {
                    await TheaterRepository.Create(theater);
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
            if (TheaterRepository != null)
            {
                try
                {
                    var result = await TheaterRepository.GetAsync(theater.Id.ToString());

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
            if (TheaterRepository != null)
            {
                try
                {
                    var result = await TheaterRepository.FindAllAsync();

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
            if (TheaterRepository != null)
            {

                try
                {
                    theater.Enabled = false;
                    await TheaterRepository.UpdateAsync(theater);

                    var result = await TheaterRepository.GetAsync(theater.Id.ToString());

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
