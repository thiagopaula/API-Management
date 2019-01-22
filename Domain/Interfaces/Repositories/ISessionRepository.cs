using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task Create(Session session);
    }
}
