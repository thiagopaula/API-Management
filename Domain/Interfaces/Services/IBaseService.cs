using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<List<T>> FindAllAsync();
        Task Delete(string id);
    }
}
