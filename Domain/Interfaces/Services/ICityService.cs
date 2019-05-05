using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface ICityService : IBaseService<City> 
    {
        //Task Create(City city);
        //Task<City> GetAsync(string id);
        //Task<List<City>> FindAllAsync();
        //Task Delete(string id);
        //Task UpdateAsync(City city);
    }
}
