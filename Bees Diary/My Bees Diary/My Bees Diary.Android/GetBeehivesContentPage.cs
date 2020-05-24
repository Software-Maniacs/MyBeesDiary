using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class GetBeehivesContentPage : ContentPage
    {
        StackLayout stackLayout;
        private SQLiteConnection db;
        private ListView _list;
        public GetBeehivesContentPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            stackLayout = new StackLayout();

            _list = new ListView()
            {
                ItemsSource = db.Table<Beehive>().OrderBy(b => b.ApiaryID).ThenBy(b => b.ID).ToList()
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