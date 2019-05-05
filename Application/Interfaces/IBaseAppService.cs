
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseAppService<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<List<T>> FindAllAsync();
        Task Delete(string id);
    }
}
