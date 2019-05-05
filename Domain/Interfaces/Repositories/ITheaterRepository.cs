using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ITheaterRepository : IRepository<Theater>
    {
        Task Create(Theater theater);
        Task UpdateAsync(Theater theater);
    }
}
