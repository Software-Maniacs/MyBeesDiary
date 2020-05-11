using Microsoft.EntityFrameworkCore;
using MyBeesDiary.Models.Entities;
using System;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            this._databasePath = databasePath;
        }

        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Beehive> Beehives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
