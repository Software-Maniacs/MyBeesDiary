using Database;
using Database.Entities;
using Database.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Bees_Diary.ViewModels.Base
{
    class BaseMethodsApiary
{
        private DatabaseContext _databaseContext;
        private ApiaryRepository apiaryRepository;

        public BaseMethodsApiary(string databasePath)
        {
            this._databaseContext = new DatabaseContext(databasePath);
        }

        public void CompareTwoApiaries(Apiary apiary, Apiary apiary2)
        {
            //apiary = new Apiary(apiary.Name, apiary.Type, apiary.Location, apiary.Power, apiary.Production);
            string json = JsonConvert.SerializeObject(apiary);
            //apiary2 = new Apiary(apiary2.Name, apiary2.Type, apiary2.Location, apiary2.Power, apiary2.Production);
            string json2 = JsonConvert.SerializeObject(apiary2);
            Console.WriteLine(json);
            Console.WriteLine(json2);
        }
    }
}
