using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface ICityService
    {
        Task Create(City city);
        Task<City> GetAsync(string id);
        Task<List<City>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(City city);
    }
}
