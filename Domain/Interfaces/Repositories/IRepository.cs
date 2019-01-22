using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<List<T>> FindAllAsync();
        Task Delete(string id);
    }
}
