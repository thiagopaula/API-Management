
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
    public class SessionUnitTests
    {
        private Session session;
        private readonly IMongoDatabase _database;
        private SessionRepository SessionRepository;

        public SessionUnitTests()
        {
            _database = new MongoClient("mongodb://thiago:82585632A@ds213513.mlab.com:13513/db-projeto").GetDatabase("db-projeto");
            //SessionRepository = new SessionRepository(_database);
        }

        [TestInitialize]
        public void Initialize()
        {
            session = new Session
            {
                //Id = ObjectId.GenerateNewId(),
                Date = DateTime.Now,
                Type = "3D",
                CopyType = "Dublado",
                MovieId = "5c45c3c4259e3cc6a280e956",
                LocationId = "5c471ae9426f1551e4c246f3",
                Enabled = true
            };
        }      


        [TestMethod]
        public async Task SessionCrud()
        {
            await Create();
            await GetByIdAsync();
            await GetAllAsync();
        }


        public async Task Create()
        {
            if (SessionRepository != null)
            {
                try
                {
                    await SessionRepository.Create(session);
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
            if (SessionRepository != null)
            {
                try
                {
                    var result = await SessionRepository.GetAsync(session.Id.ToString());

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
            if (SessionRepository != null)
            {
                try
                {
                    var result = await SessionRepository.FindAllAsync();

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
    }
}
