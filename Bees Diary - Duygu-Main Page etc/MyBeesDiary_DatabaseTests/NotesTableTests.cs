
using My_Bees_Diary.Models.Entities;
using NUnit.Framework;
using SQLite;
using System;
using System.Linq;
using System.Transactions;
using Xamarin.Forms;

namespace MyBeesDiary_DatabaseTests
{
    [TestFixture]
    public class NotesTableTests
    {
        private SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal),
                "testDB.db"
                ));
        [Test]
        public void IsNoteCorrectlyAdded()
        {
            try
            {
                db.DeleteAll<Note>();
            }
            catch (SQLiteException)
            {
                db.CreateTable<Note>();
            }
            Note note = new Note
            {
                ID = 1,
                Summary = "Nikolai",
                Description = "Nikolaevich",
                Date = DateTime.Now
            };
            db.CreateTable<Note>();
            db.Table<Note>().OrderByDescending(n => n.Date);
            db.Insert(note);
            Note dbNote = db.Table<Note>().FirstOrDefault();
            Assert.AreEqual(note, dbNote, "The created note should be the same when added to the database");
        }

        [Test]
        public void IsNoteCorrectlyRemoved()
        {
            db.DeleteAll<Note>();
            Note note = new Note
            {
                ID = 1,
                Summary = "Nikolai",
                Description = "Nikolaevich",
                Date = DateTime.Now
            };
            db.CreateTable<Note>();
            db.Insert(note);
            Note note2 = new Note
            {
                ID = 2,
                Summary = "Nikolai",
                Description = "Nikolaevich",
                Date = DateTime.Now
            };
            db.Insert(note2);
            db.Delete(note);
            Assert.AreEqual(false, db.Table<Note>().Contains(note), "Note shouldn't be in the database");
        }

        [Test]
        public void IsNoteCorrectlyUpdated()
        {
            Note note = CreateTestNote();
            Note oldNote = CreateTestNote();
            db.Insert(note);
            note.Summary = "Mustafa";
            db.Update(note);
            Assert.AreNotEqual(db.Table<Note>().ElementAt(0), oldNote, "Note shouldn't be the same after an update.");
        }

        private Note CreateTestNote()
        {
            Note note = new Note
            {
                ID = 1,
                Summary = "Nikolai",
                Description = "Nikolaevich",
                Date = DateTime.Now
            };
            return note;
        }
    }
}