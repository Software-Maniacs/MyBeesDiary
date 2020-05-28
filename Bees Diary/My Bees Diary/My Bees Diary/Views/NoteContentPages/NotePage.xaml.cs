using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Services;
using My_Bees_Diary.Services.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace My_Bees_Diary.Views.NoteContentPages
{
    /// <summary>
    /// Main page for entity Note.
    /// </summary>
    public partial class NotePage : ContentPage
    {
        private SQLiteConnection db;
        private string _dbPath;
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// The page gets the notes from there and displays them in a ListView format. Each note
        /// is represented by its summary in the ListView.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>
        public NotePage(string dbPath)
        {
            NavigationPage.SetTitleIconImageSource(this, "notes.png");
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;
            InitializeComponent();

        }
  
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                NoteListView.ItemsSource = db.Table<Note>();
            }
            catch (SQLite.SQLiteException)
            {
                db.CreateTable<Note>();
                NoteListView.ItemsSource = db.Table<Note>();
            }
        }
        private async void Create_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new AddNotePage(_dbPath));
        }

        private void NoteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Note note = e.SelectedItem as Note;
            Navigation.PushAsync(new EditNotePage(_dbPath, note));
        }
    }
}
