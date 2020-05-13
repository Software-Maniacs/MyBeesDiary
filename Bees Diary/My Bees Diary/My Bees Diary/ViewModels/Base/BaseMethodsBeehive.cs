using Database;
using Database.Entities;
using Database.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms.Internals;

namespace My_Bees_Diary.ViewModels.Base
{
    public class BaseMethodsBeehive
    {
        private DatabaseContext _dbContext;
        private BeehiveRepository _beehiveRepository;

        public BaseMethodsBeehive(string databasePath)
        {
            this._dbContext = new DatabaseContext(databasePath);
            this._beehiveRepository = new BeehiveRepository(databasePath);
        }

        public async void Add(params Beehive[] beehives)
        {
            foreach (var beehive in beehives)
            {
                await _beehiveRepository.AddBeehiveAsync(beehive);
            }
        }

        public async void Remove(params Beehive[] beehives)
        {
            foreach (var beehive in beehives)
            {
                await _beehiveRepository.RemoveBeehiveAsync(beehive);
            }
        }

        public async void Compare(Beehive beehive1, Beehive beehive2, string  criterion)
        {

        }

        public async void Filter(string property, string criterion, string ordered)
        {
            /*//Func<Beehive, bool> func = beehive => typeof(Beehive).GetProperty(property).GetValue(beehive) 
            */
            PropertyInfo myProperty = typeof(Beehive).GetProperty(property);
            Type typeOfPropertyVariable = myProperty.PropertyType;
            var compareValue = Convert.ChangeType(criterion, typeOfPropertyVariable);

            /*Func<Beehive, bool> func;
            List<Beehive> beehives = _beehiveRepository.GetAllBeehivesAsync();

            switch (sign)
            {
                case "equals":
                    func = beehive => myProperty.GetValue(beehive) == compareValue;
                    break;

                case "smaller":
                    func = beehive => 
                    break;

                case "bigger":

                    break;
            }*/


            using(SqliteConnection connection = _dbContext.SqliteConnection)
            {
                IEnumerable<Beehive> beehives = await _beehiveRepository.GetAllBeehivesAsync(); 
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(
                    "select * from '" + beehives + "%' where '" + property + "%' = '" + compareValue + "%' order by'" + ordered + "%'"))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            
        }
    }
}
