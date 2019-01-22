using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface ILocationService
    {
        Task Create(Location location);
        Task<Location> GetAsync(string id);
        Task<List<Location>> FindAllAsync();
        Task Delete(string id);
        Task<List<Location>> GetByTheaterId(string id);
        Task UpdateAsync(Location location);

    }
}
