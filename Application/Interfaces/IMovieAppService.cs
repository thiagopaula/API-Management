using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieAppService
    {
        Task Create(Movie movie);
        Task<Movie> GetAsync(string id);
        Task<List<Movie>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(Movie movie);
    }
}
