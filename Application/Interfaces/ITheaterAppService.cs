using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITheaterAppService
    {
        Task Create(Theater theater);
        Task<Theater> GetAsync(string id);
        Task<List<Theater>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(Theater theater);
    }
}
