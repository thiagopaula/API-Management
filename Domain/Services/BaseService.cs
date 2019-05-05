using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using LightInject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        [Inject]
        public IRepository<T> Repository { get; set; }

        public async Task Delete(string id)
        {
           await Repository.Delete(id);
        }

        public async Task<List<T>> FindAllAsync()
        {
           return await Repository.FindAllAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await Repository.GetAsync(id);
        }
    }
}
