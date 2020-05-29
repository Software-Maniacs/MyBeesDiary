using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Views;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBeesDiary_DatabaseTests
{
    [TestFixture]
    public class ApiaryTableTests
    {
        private SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(System.Environment.GetFolderPath(
        System.Environment.SpecialFolder.Personal),
        "testDB.db"
        ));
        
        [Test]
        public void IsApiaryAddedCorrectly()
        {
            try
            {
                db.DeleteAll<Apiary>();
            }
            catch (SQLiteException)
            {
                db.CreateTable<Apiary>();
            }
            //Apiary apiary = CreateTestApiary();
            //db.Insert(apiary);
            //Assert.AreEqual(apiary, db.Table<Apiary>().ElementAt(0), "The created apiary should be the same when added to the database");
        }

       /* [Test]
        public void IsApiaryUpdatedCorrectly()
        {
            db.DeleteAll<Apiary>();
            Apiary apiary = CreateTestApiary();
            Apiary oldApiary = CreateTestApiary();
            db.Insert(apiary);
            apiary.Location = "Burgas";
            apiary.Production = 228;
            db.Update(apiary);
            Assert.AreNotEqual(oldApiary, db.Table<Apiary>().ElementAt(0), "Apiary shouldn't have the same value after it is updated.");

        }

        [Test]
        public void IsApiaryRemovedCorrectly()
        {
            db.DeleteAll<Apiary>();
            Apiary apiary = CreateTestApiary();
            Apiary apiary2 = CreateTestApiary2();
            db.Insert(apiary);
            db.Insert(apiary2);
            db.Delete(apiary);
            Assert.AreNotEqual(apiary, db.Table<Apiary>().ElementAt(0), "Apiary shouldn't be in the table after being removed.");
        }
        /*private Apiary CreateTestApiary()
        {
            List<Plant> plants = new List<Plant>
            {
                new Plant {PlantName = "Роза"},
                new Plant {PlantName= "Кокиче"}
            };
            ;
            Apiary apiary = new Apiary
            {
                Name = "Apiary1",
                Number = "800512",
                Type = "Mobile",
                Production = 225,
                Location = "Aytos",
                Date = DateTime.Now,
            };
            apiary.PlantsInArea = new AreaPlants
            {
              Apiary = apiary,
              ApiaryID = apiary.ID,
                PlantsID = 1,
               PlantsList = plants
            };
            return apiary;
        }
        Apiary CreateTestApiary2()
        {
            List<Plant> plants = new List<Plant>
            {
                new Plant{PlantName="Магарешки бодил" },
                new Plant{PlantName="Лале"}
            };
            Apiary apiary = new Apiary
            {
                Name = "Apiary2",
                Number = "800517",
                Type = "Stationary",
                Production = 227,
                Location = "Burgas",
                Date = DateTime.Now
            };
            apiary.PlantsInArea = new AreaPlants
            {
                Apiary = apiary,
                ApiaryID = apiary.ID,
                PlantsID = 2,
                PlantsList = plants
            };
            return apiary;
        }*/
    }
}
