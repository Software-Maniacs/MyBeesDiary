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
        private string _dbPath;
        private ListView apiaryListView;
        public Page1(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;

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
            apiaryListView.IsPullToRefreshEnabled = true;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        
        
    }
}