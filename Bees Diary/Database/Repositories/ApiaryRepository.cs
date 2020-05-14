using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ApiaryRepository : IApiaryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ApiaryRepository(string databasePath)
        {
            this._databaseContext = new DatabaseContext(databasePath);
        }

        public async Task<bool> AddApiaryAsync(Apiary apiary)
        {
            try
            {
                var tracking = await _databaseContext.AddAsync(apiary);

                await _databaseContext.SaveChangesAsync();

                bool isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ContainApiaryWithTheSameName(string apiaryName)
        {
            IEnumerable<Apiary> apiaries = await GetAllApiariesAsync();
            bool isHaveApiaryWithTheSameName = false;

            foreach (var apiary in apiaries)
            {
                if (apiary.Name.Equals(apiaryName))
                {
                    isHaveApiaryWithTheSameName = true;
                    break;
                }
            }

            return isHaveApiaryWithTheSameName;
        }

        public async Task<IEnumerable<Apiary>> GetAllApiariesAsync()
        {
            try
            {
                var apiaries = await _databaseContext.Apiaries.ToListAsync();

                return apiaries;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Apiary> GetApiaryByIdAsync(int id)
        {
            try
            {
                var apiary = await _databaseContext.Apiaries.FindAsync(id);

                return apiary;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Apiary>> QueryApiaryAsync(Func<Apiary, bool> predicate)
        {
            try
            {
                var apiaries = _databaseContext.Apiaries.Where(predicate);

                return apiaries.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveApiaryAsync(Apiary apiary)
        {
            try
            {
                var tracking = _databaseContext.Apiaries.Remove(apiary);

                await _databaseContext.SaveChangesAsync();

                bool isRemoved = tracking.State == EntityState.Deleted;

                return isRemoved;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveApiaryByIdAsync(int id)
        {
            try
            {
                var apiary = await _databaseContext.Apiaries.FindAsync(id);

                bool isRemoved = await RemoveApiaryAsync(apiary);

                return isRemoved;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateApiaryAsync(Apiary apiary)
        {
            try
            {
                var tracking = _databaseContext.Update(apiary);

                await _databaseContext.SaveChangesAsync();

                bool isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
