using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface ISessionService
    {
        Task Create(Session session);
        Task<Session> GetAsync(string id);
        Task<List<Session>> FindAllAsync();
        Task Delete(string id);
    }
}
