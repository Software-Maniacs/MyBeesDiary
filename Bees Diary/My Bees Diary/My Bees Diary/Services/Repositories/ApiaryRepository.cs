﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Services;
using My_Bees_Diary.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Bees_Diary.Services.Repositories
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

        internal Task<bool> ContainApiaryWithTheSameName(string name)
        {
            throw new NotImplementedException();
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
