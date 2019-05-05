using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILocationAppService
    {
        Task Create(Location location);
        Task<Location> GetAsync(string id);
        Task<List<Location>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(Location location);
    }
}
