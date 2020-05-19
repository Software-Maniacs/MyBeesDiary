using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class BeehiveRepository : IBeehiveRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BeehiveRepository(string databasePath)
        {
            this._databaseContext = new DatabaseContext(databasePath);
        }

        public async Task<bool> AddBeehiveAsync(Beehive beehive)
        {
            try
            {
                var tracking = await _databaseContext.Beehives.AddAsync(beehive);

                await _databaseContext.SaveChangesAsync();

                bool isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> ContainBeehiveWithTheSameName(string beehiveName)
        {
            IEnumerable<Beehive> beehives = await GetAllBeehivesAsync();
            bool isHaveBeehiveWithTheSameName = false;

            foreach (var beehive in beehives)
            {
                if (beehive.Name.Equals(beehiveName))
                {
                    isHaveBeehiveWithTheSameName = true;
                    break;
                }
            }

            return isHaveBeehiveWithTheSameName;
        }

        public async Task<Beehive> GetBeehiveByIdAsync(int id)
        {
            try
            {
                Beehive beehive = await _databaseContext.Beehives.FindAsync(id);

                return beehive;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Beehive>> GetAllBeehivesAsync()
        {
            try
            {
                var tracking = await _databaseContext.Beehives.ToListAsync();

                return tracking.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Beehive>> QueryBeehivesAsync(Func<Beehive, bool> predicate)
        {
            try
            {
                var beehives = _databaseContext.Beehives.Where(predicate);

                return beehives.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveBeehiveAsync(Beehive beehive)
        {
            try
            {
                var tracking = _databaseContext.Beehives.Remove(beehive);

                await _databaseContext.SaveChangesAsync();

                bool isRemoved = tracking.State == EntityState.Deleted;

                return isRemoved;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveBeehiveByIdAsync(int id)
        {
            try
            {
                var beehive = await _databaseContext.Beehives.FindAsync(id);

                bool isRemoved = await RemoveBeehiveAsync(beehive);

                return isRemoved;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBeehiveAsync(Beehive beehive)
        {
            try
            {
                var tracking = _databaseContext.Update(beehive);

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
