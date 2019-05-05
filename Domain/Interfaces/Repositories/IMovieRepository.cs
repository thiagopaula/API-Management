using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task Create(Movie movie);
        Task UpdateAsync(Movie movie);
    }
}
