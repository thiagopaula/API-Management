using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using Service.Interfaces.Services;


namespace Service.Services
{
    public class TheaterService : ITheaterService
    {
        [Inject]
        public ITheaterRepository TheaterRepository { get; set; }
        [Inject]
        public ILocationRepository LocationRepository { get; set; }

        public async Task Create(Theater theater)
        {
            await TheaterRepository.Create(theater);
        }
        public async Task<Theater> GetAsync(string id)
        {
            var theater = await TheaterRepository.GetAsync(id);

            if (theater != null)
            {
                var locations = await LocationRepository.GetByTheaterId(theater.Id.ToString());

                if (locations.Any())
                {
                    theater.Locations = locations;
                }
            }

            return theater;           
        }

        public async Task<List<Theater>> FindAllAsync()
        {
            var theates = await TheaterRepository.FindAllAsync();

            if (theates.Any())
            {
                foreach (var theater in theates)
                {
                    var locations = await LocationRepository.GetByTheaterId(theater.Id.ToString());

                    if (locations.Any())
                    {
                        theater.Locations = locations;
                    }
                }
            }

            return theates;
        }

        public async Task Delete(string id)
        {
            await TheaterRepository.Delete(id);
        }

        public async Task UpdateAsync(Theater theater)
        {
            await TheaterRepository.UpdateAsync(theater);
        }
    }
}
