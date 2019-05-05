using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services;
using LightInject;
using Service.Interfaces.Services;
using System;

namespace Service.Services
{
    public class CityService : BaseService<City>, ICityService
    {
        //[Inject]
        //public ICityRepository CityRepository { get; set; }

        //public IServiceProvider ServiceProvider { get; set; }


        //public CityService(ICityRepository cityRepository)
        //{
        //    CityRepository = cityRepository;
        //}

        //[Inject]
        //public ICityRepository CityRepository { get; set; }

        //public async Task Create(City city)
        //{
        //    await CityRepository.Create(city);
        //}

        //public async Task<City> GetAsync(string id)
        //{
        //    return await CityRepository.GetAsync(id);
        //}

        //public async Task<List<City>> FindAllAsync()
        //{
        //    return await CityRepository.FindAllAsync();
        //}

        //public async Task Delete(string id)
        //{
        //    await CityRepository.Delete(id);
        //}

        //public async Task UpdateAsync(City city)
        //{
        //    await CityRepository.UpdateAsync(city);
        //}
    }
}
