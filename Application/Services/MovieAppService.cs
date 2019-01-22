using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using LightInject;
using Service.Interfaces.Services;

namespace Application.Services
{
    public class MovieAppService : IMovieAppService
    {
        [Inject]
        public IMovieService MovieService { get; set; }

        public async Task Create(Movie movie)
        {
            await MovieService.Create(movie);
        }

        public async Task Delete(string id)
        {
            await MovieService.Delete(id);
        }

        public async Task<List<Movie>> FindAllAsync()
        {
            return await MovieService.FindAllAsync();
        }

        public async Task<Movie> GetAsync(string id)
        {
            return await MovieService.GetAsync(id);
        }

        public async Task UpdateAsync(Movie movie)
        {
            await MovieService.UpdateAsync(movie);
        }
    }
}
