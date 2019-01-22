using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task Create(Location location);
        Task<List<Location>> GetByTheaterId(string id);
        Task UpdateAsync(Location location);
    }
}
