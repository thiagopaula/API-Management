using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;

namespace Application.Services
{
    public class SessionAppService : ISessionAppService
    {
        [Inject]
        public ISessionService SessionService { get; set; }

        public async Task Create(Session session)
        {
            await SessionService.Create(session);
        }

        public async Task Delete(string id)
        {
            await SessionService.Delete(id);
        }

        public async Task<List<Session>> FindAllAsync()
        {
            return await SessionService.FindAllAsync();
        }

        public async Task<Session> GetAsync(string id)
        {
            return await SessionService.GetAsync(id);
        }
    }
}
