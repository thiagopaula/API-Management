using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CityAppService : ICityAppService
    {
        [Inject]
        public ICityService CityService { get; set; }

        public async Task Create(City city)
        {
            await CityService.Create(city);
        }

        public async Task Delete(string id)
        {
            await CityService.Delete(id);
        }

        public async Task<List<City>> FindAllAsync()
        {
            return await CityService.FindAllAsync();
        }

        public async Task<City> GetAsync(string id)
        {
            return await CityService.GetAsync(id);
        }

        public async Task UpdateAsync(City city)
        {
            await CityService.UpdateAsync(city);
        }
    }
}
