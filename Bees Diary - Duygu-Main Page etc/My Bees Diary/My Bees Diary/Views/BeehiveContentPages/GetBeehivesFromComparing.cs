using Microsoft.Data.Sqlite;
using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class GetBeehivesFromComparing : ContentPage
{
        private SQLiteConnection db;
        private Picker _beehive1;
        private Picker _beehive2;
        private Button _compare;
    public GetBeehivesFromComparing(string dbPath)
    {
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();

            _beehive1 = new Picker()
            {
                ItemsSource = db.Table<Beehive>().ToList(),
                Title = "Избери кошер"
            };
            stackLayout.Children.Add(_beehive1);

            _beehive2 = new Picker()
            {
                Title = "Избери кошер",
                ItemsSource = db.Table<Beehive>().OrderBy(b => b.ApiaryID).ThenBy(b => b.ID).ToList()
            };
            stackLayout.Children.Add(_beehive2);

            _compare = new Button()
            {
                Text = "Сравни"
            };
            _compare.Clicked += Compare;
            stackLayout.Children.Add(_compare);

            Content = stackLayout;
    }

        private async void Compare(object sender, EventArgs e)
        {
            Beehive beehive1 = db.Query<Beehive>("select * from Beehive where id = " + _beehive1.SelectedItem.ToString().Split().ToArray()[0]).First();
            Beehive beehive2 = db.Query<Beehive>("select * from Beehive where id = " + _beehive2.SelectedItem.ToString().Split().ToArray()[0]).First();
            await Navigation.PushAsync(new TableCompareBeehives(db.DatabasePath, beehive1, beehive2));
        }
    }
}