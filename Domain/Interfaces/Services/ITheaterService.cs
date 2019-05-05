using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces.Services
{
    public interface ITheaterService
    {
        Task Create(Theater theater);
        Task<Theater> GetAsync(string id);
        Task<List<Theater>> FindAllAsync();
        Task Delete(string id);
        Task UpdateAsync(Theater theater);
    }
}
