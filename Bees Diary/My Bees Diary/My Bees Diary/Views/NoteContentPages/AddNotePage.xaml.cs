using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using My_Bees_Diary.Models.Entities;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Bees_Diary.Views.NoteContentPages
{

    ///<summary>
    ///This is the page, from which the user adds a note.
    ///</summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AddNotePage : ContentPage
	{
        private SQLiteConnection db;
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>
        public AddNotePage(string dbPath)
		{
            db = new SQLiteConnection(dbPath);
			InitializeComponent();
		}

        internal async void AddButton_Clicked(object sender, EventArgs e)
        {
            string summary = SummaryEntry.Text;
            string description = DescriptionEditor.Text;
            int id = 0;
            Note lastNote = null;
            try
            {
                lastNote = db.Table<Note>().OrderByDescending(n => n.Date).FirstOrDefault();
            }
            catch(NullReferenceException)
            {
                id = 1;
            }
            if(lastNote != null)
            {
                id = lastNote.ID++;
            }
            if (summary == null)
            {
                await DisplayAlert("Грешка", "Резюмето не може да бъде празно.", "OK");
            }
            else
            {
                Note note = new Note()
            {
                ID = id,
                Summary = summary,
                Description = description,
                Date = DateTime.Now
            };
            db.Insert(note);
                await DisplayAlert(null, "Вие добавихте записка.", "ОК");
            await Navigation.PopAsync();
            }
            
        }
    }
}