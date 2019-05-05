using API_Management.GraphQL.Types;
using AutoMapper;
using Domain.Interfaces.Repositories;
using LightInject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Management.GraphQL
{
    public class GraphQLData
    {
        [Inject]
        public ICityRepository CityRepository { get; set; }

        public Task<City> GetByIdAsync(string id)
        {
            var city = CityRepository.GetAsync(id);

            if (city == null) return null;

            var cityNew = Mapper.Map<City>(city);

            return Task.FromResult(cityNew);
        }

        public async Task<List<City>> GetAllAsync()
        {
            var cities = await CityRepository.FindAllAsync();

            if (cities == null) return null;

             var citiesNew = Mapper.Map<List<City>>(cities);    

            return await Task.FromResult(citiesNew);
        }
    }
}
