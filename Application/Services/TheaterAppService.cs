using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TheaterAppService : ITheaterAppService
    {
        [Inject]
        public ITheaterService TheaterService { get; set; }
        

        public async Task Create(Theater theater)
        {
            await TheaterService.Create(theater);
        }

        public async Task<Theater> GetAsync(string id)
        {
            return await TheaterService.GetAsync(id);
        }

        public async Task<List<Theater>> FindAllAsync()
        {
            return await TheaterService.FindAllAsync();     
        }

        public async Task Delete(string id)
        {
            await TheaterService.Delete(id);
        }

        public async Task UpdateAsync(Theater theater)
        {
            await TheaterService.UpdateAsync(theater);
        }
    }
}
