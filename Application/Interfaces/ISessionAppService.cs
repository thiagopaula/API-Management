using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISessionAppService
    {
        Task Create(Session session);
        Task<Session> GetAsync(string id);
        Task<List<Session>> FindAllAsync();
        Task Delete(string id);
    }
}
