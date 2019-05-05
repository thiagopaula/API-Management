using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICityRepository : IRepository<City> 
    {      
        Task UpdateAsync(City city);
    }
}
