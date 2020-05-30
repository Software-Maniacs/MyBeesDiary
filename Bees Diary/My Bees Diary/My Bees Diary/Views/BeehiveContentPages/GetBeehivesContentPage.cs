using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    /// <summary>
    /// In this page we have list view of the all added beehives. The user can make changes to each beehive by clicking on it.
    /// </summary>
	public class GetBeehivesContentPage : ContentPage
    {
        private SQLiteConnection db;
        private ListView _list;
        
        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>
        public GetBeehivesContentPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;

            Label label = new Label()
            {
                Text = Title = "Моите кошери"
            };

            _list = new ListView()
            {
                ItemsSource = db.Table<Beehive>().OrderBy(b => b.ID).ToList()
            };
            _list.ItemSelected += GetInfo;
            stackLayout.Children.Add(_list);

            Content = stackLayout;
        }

        private async void GetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            int id = int.Parse(_list.SelectedItem.ToString().Split().ToArray()[0]);
            Beehive beehive = db.Query<Beehive>("select * from Beehive where ID = " + id).First();
            await Navigation.PushAsync(new BeehiveInfoPage(beehive, db.DatabasePath));
        }
    }
}