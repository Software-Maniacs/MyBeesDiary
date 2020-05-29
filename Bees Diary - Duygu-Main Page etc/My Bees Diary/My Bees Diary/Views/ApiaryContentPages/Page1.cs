using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class Page1 : ContentPage
    {
        private SQLiteConnection db;
        //private string _dbPath;
        //private ListView apiaryListView;
        public Page1(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            /*_dbPath = dbPath;

            apiaryListView = new ListView()
            {
                ItemsSource = db.Table<Apiary>(),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = new Grid
            {
                RowDefinitions = {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
            },
                Children = {
                apiaryListView
            }
            };
            apiaryListView.ItemSelected += OnItemSelected;
            apiaryListView.IsPullToRefreshEnabled = true;*/

            db.CreateTable<Apiary>();

            StackLayout stackLayout = new StackLayout();

            Button add = new Button()
            {
                Text = "Add"
            };
            add.Clicked += Add;
            stackLayout.Children.Add(add);

            Button get = new Button()
            {
                Text = "Get"
            };
            get.Clicked += Get;
            stackLayout.Children.Add(get);

            Content = stackLayout;
        }

        private async void Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddApiaryPage(db.DatabasePath));
        }

        private async void Get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }

        /*private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }*/


    }
}