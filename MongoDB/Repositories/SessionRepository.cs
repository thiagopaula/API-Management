using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public class SessionRepository : AbstractRepository<Session>, ISessionRepository
    {
        public SessionRepository([Inject()]IMongoDatabase _database) : base(_database, "sessions") { }

        public async Task Create(Session session)
        {
            if (session.Id == null)
            {
                session.Id = ObjectId.GenerateNewId();
            }
            await Collection.InsertOneAsync(session);
        }
    }
}
