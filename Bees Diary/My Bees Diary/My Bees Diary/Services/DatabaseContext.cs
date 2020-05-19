using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using My_Bees_Diary.Models.Entities;
using System;

namespace My_Bees_Diary.Services
{
    public class DatabaseContext : DbContext
    {
        private readonly string _databasePath;

        public DatabaseContext()
        {
            this._databasePath = System.IO.Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal),
                "productDB.db"
                ); 
        }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apiary>()
                .HasMany(apiary => apiary.Beehives)
                .WithOne(beehive => beehive.Apiary)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
