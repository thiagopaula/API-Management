using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using Service.Interfaces.Services;

namespace Service.Services
{
    public class SessionService : ISessionService
    {
        [Inject]
        public ISessionRepository SessionRepository { get; set; }

        public async Task Create(Session session)
        {
            await SessionRepository.Create(session);
        }

        public async Task Delete(string id)
        {
            await SessionRepository.Delete(id);
        }

        public async Task<List<Session>> FindAllAsync()
        {
            return await SessionRepository.FindAllAsync();
        }

        public async Task<Session> GetAsync(string id)
        {
            return await SessionRepository.GetAsync(id);
        }
    }
}
