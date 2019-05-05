using Application.Interfaces;
using Domain.Interfaces.Services;
using LightInject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BaseAppService<T> : IBaseAppService<T> where T : class
    {
        [Inject]
        public IBaseService<T> BaseService { get; set; }

        public async Task Delete(string id)
        {
            await BaseService.Delete(id);
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await BaseService.FindAllAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await BaseService.GetAsync(id);
        }
    }
}
