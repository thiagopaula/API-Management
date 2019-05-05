using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task Create(T model);
        Task<T> GetAsync(string id);
        Task<List<T>> FindAllAsync();
        Task Update(string id, T obj);
        Task Delete(string id);
    }
}
