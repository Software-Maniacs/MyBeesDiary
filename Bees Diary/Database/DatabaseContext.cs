using Database.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            this._databasePath = databasePath;
            SqliteConnection = new SqliteConnection(_databasePath);
            SqliteCommand = new SqliteCommand();
        }

        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Beehive> Beehives { get; set; }

        public SqliteConnection SqliteConnection { get; set; }

        public SqliteCommand SqliteCommand { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
