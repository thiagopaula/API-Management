using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task Create(City city);
        Task UpdateAsync(City city);
    }
}
