using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface IMovieService
    {
        Task Create(Movie movie);
        Task<Movie> GetAsync(string id);
        Task<List<Movie>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(Movie movie);
    }
}
