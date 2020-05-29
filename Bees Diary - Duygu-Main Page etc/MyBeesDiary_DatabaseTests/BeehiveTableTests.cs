using My_Bees_Diary.Models.Entities;
using NUnit.Framework;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBeesDiary_DatabaseTests
{
    [TestFixture]
    public class BeehiveTableTests
    {
        private SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(System.Environment.GetFolderPath(
        System.Environment.SpecialFolder.Personal),
        "testDB.db"
        ));
        [Test]
        public void IsBeehiveCorrectlyAdded()
        {
            try
            {
                db.DeleteAll<Beehive>();
            }
            catch (SQLiteException)
            {
                db.CreateTable<Beehive>();
            }
            Beehive beehive = CreateTestBeehive();
            db.Insert(beehive);
            Assert.AreEqual(beehive, db.Table<Beehive>().ElementAt(0), "Beehive should be the same when added to the database.");
        }


        private Beehive CreateTestBeehive()
        {
            Beehive beehive = new Beehive()
            {
                Name = "Beehive1",
                Number = "80043",
                Power = 4,
                Feedings = 4,
                Production = 456,
                TypeBeehive = "Mobile",
                Treatments = 6,
                TypeBees = "Yellow",
                Reviews = 4,
                Stores = 5
            };
            return beehive;
        }
    }
}
