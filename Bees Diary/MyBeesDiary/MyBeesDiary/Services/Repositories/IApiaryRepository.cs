using MyBeesDiary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBeesDiary.Services.Repositories
{
    public interface IApiaryRepository
    {
        Task<IEnumerable<Apiary>> GetAllApiariesAsync();
        Task<Apiary> GetApiaryByIdAsync(int id);
        Task<bool> AddApiaryAsync(Apiary apiary);
        Task<bool> UpdateApiaryAsync(Apiary apiary);
        Task<bool> RemoveApiaryAsync(Apiary apiary);
        Task<bool> RemoveApiaryByIdAsync(int id);
        Task<IEnumerable<Apiary>> QueryApiaryAsync(Func<Apiary, bool> predicate);
    }
}
