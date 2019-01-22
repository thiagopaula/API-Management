using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using Service.Interfaces.Services;

namespace Service.Services
{
    public class LocationService : ILocationService
    {
        [Inject]
        public ILocationRepository LocationRepository { get; set; }

        public async Task Create(Location location)
        {
            await LocationRepository.Create(location);
        }
        public async Task<Location> GetAsync(string id)
        {
            return await LocationRepository.GetAsync(id);
        }

        public async Task<List<Location>> FindAllAsync()
        {
            return await LocationRepository.FindAllAsync();
        }

        public async Task Delete(string id)
        {
            await LocationRepository.Delete(id);
        }

        public async Task<List<Location>> GetByTheaterId(string id)
        {
            return await LocationRepository.GetByTheaterId(id);
        }

        public async Task UpdateAsync(Location location)
        {
            await LocationRepository.UpdateAsync(location);
        }
    }
}
