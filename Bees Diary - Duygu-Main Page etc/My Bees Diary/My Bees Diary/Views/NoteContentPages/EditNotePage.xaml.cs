using Microsoft.EntityFrameworkCore.Storage;
using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Bees_Diary.Views.NoteContentPages
{
	/// <summary>
	/// This is the page, from which the user edits a note.
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditNotePage : ContentPage
	{
		private SQLiteConnection db;
		private string _dbPath;
		private Note _note;
		private int databaseNoteID;
		/// <summary>
		/// Class constructor.
		/// </summary>
		/// <remarks>
		/// When the page is initiated, it connects to the database through the database path.
		/// The note that the user has clicked on in the NotePage is passed here, in order to be updated.
		/// </remarks>
		/// <param name="dbPath">Path of the database.</param>
		/// <param name="note">The note that needs to be edited.</param>
		public EditNotePage(string dbPath, Note note)
		{
			db = new SQLiteConnection(dbPath);
			_dbPath = dbPath;
			_note = note;
			databaseNoteID = note.ID;
			InitializeComponent();
		}

		protected async override void OnAppearing()
        {
			base.OnAppearing();
			SummaryEntry.Text = _note.Summary;
			DescriptionEditor.Text = _note.Description;
			DateEntry.Placeholder = _note.Date.ToString("dd/MM/yyyy HH:mm:ss");
        }
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
			_note.Summary = SummaryEntry.Text;
			if (!String.IsNullOrEmpty(_note.Summary) || !String.IsNullOrWhiteSpace(_note.Summary))
            {
				_note.Date = DateTime.Now;
				_note.Description = DescriptionEditor.Text;
				_note.ID = databaseNoteID;
				db.Update(_note);
				await Navigation.PopAsync();
			}
			else
            {
				await DisplayAlert("Грешка", "Резюмето не може да бъде празно.", "OK");
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
			bool answer = await DisplayAlert("Сигурни ли сте?", "Сигурни ли сте, че искате да изтриете тази записка?",
				"Да", "Не");
			switch(answer)
            {
				case true:
					db.Delete(_note);
					await Navigation.PopAsync();
					break;
			}				
        }
    }
}