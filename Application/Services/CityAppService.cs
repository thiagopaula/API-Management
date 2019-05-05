using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;

namespace Application.Services
{
    public class CityAppService : BaseAppService<City>, ICityAppService
    {
        //[Inject]
        //public ICityService CityService { get; set; }
          

        //public CityAppService(ICityService cityService)
        //{
        //    CityService = cityService;
        //}

        //[Inject]
        //public ICityService CityService { get; set; }

        //public async Task Create(City city)
        //{
        //    await CityService.Create(city);
        //}

        //public async Task Delete(string id)
        //{
        //    await CityService.Delete(id);
        //}

        //public async Task<List<City>> FindAllAsync()
        //{
        //    return await CityService.FindAllAsync();
        //}

        //public async Task<City> GetAsync(string id)
        //{
        //    return await CityService.GetAsync(id);
        //}

        //public async Task UpdateAsync(City city)
        //{
        //    await CityService.UpdateAsync(city);
        //}
    }
}
