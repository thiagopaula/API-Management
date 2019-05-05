using Domain.Entities;
using Domain.Interfaces.Repositories;
using LightInject;
using Service.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MovieService : IMovieService
    {
        [Inject]
        public IMovieRepository MovieRepository { get; set; }

        public async Task Create(Movie movie)
        {
            await MovieRepository.Create(movie);
        }
        public async Task<Movie> GetAsync(string id)
        {
            return await MovieRepository.GetAsync(id);
        }

        public async Task<List<Movie>> FindAllAsync()
        {
            return await MovieRepository.FindAllAsync();
        }

        public async Task Delete(string id)
        {
            await MovieRepository.Delete(id);
        }

        public async Task UpdateAsync(Movie movie)
        {
            await MovieRepository.UpdateAsync(movie);
        }
    }
}
