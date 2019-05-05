using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;

namespace Application.Services
{
    public class LocationAppService : ILocationAppService
    {
        [Inject]
        public ILocationService LocationService { get; set; }

        public async Task Create(Location location)
        {
            await LocationService.Create(location);
        }

        public async Task Delete(string id)
        {
            await LocationService.Delete(id);
        }

        public async Task<List<Location>> FindAllAsync()
        {
            return await LocationService.FindAllAsync();
        }

        public async Task<Location> GetAsync(string id)
        {
            return await LocationService.GetAsync(id);
        }

        public async Task UpdateAsync(Location location)
        {
            await LocationService.UpdateAsync(location.Id, location);
        }
    }
}
