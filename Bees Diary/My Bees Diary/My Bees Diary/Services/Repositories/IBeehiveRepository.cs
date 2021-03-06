﻿using My_Bees_Diary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My_Bees_Diary.Services.Repositories
{
    public interface IBeehiveRepository
    {
        Task<IEnumerable<Beehive>> GetAllBeehivesAsync();
        Task<Beehive> GetBeehiveByIdAsync(int id);
        Task<bool> AddBeehiveAsync(Beehive beehive);
        Task<bool> UpdateBeehiveAsync(Beehive beehive);
        Task<bool> RemoveBeehiveAsync(Beehive beehive);
        Task<bool> RemoveBeehiveByIdAsync(int id);
        Task<IEnumerable<Beehive>> QueryBeehivesAsync(Func<Beehive, bool> predicate);
    }
}
