using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    /// <summary>
    /// This is our Home/Start page. 
    /// </summary>
    /// <remarks>
    /// In this page we added buttons to navigate the user. Each button navigates to its page.
    /// </remarks>
    /// 
    public class StartPage : ContentPage
    {
        private Button _addApiary;
        private Label label;
        private Button _getApiary;
        private Button _addBeehive;
        private Button _getBeehive;
        private Button _statistic;
        private string dbPath;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="databasePath">Path of the database.</param>
        /// 

        public StartPage(string databasePath)
        {
            dbPath = databasePath;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Spacing = 20;
            stackLayout.BackgroundColor = Color.AliceBlue;
            stackLayout.HorizontalOptions = LayoutOptions.Center;
            stackLayout.HorizontalOptions = LayoutOptions.Center;

            label = new Label()
            {
                Text = Title = "Добре Дошли!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            _addApiary = new Button()
            {
                Text = "Добави пчелин",
                TextColor = Color.White,
                BackgroundColor = Color.CornflowerBlue
            };
            _addApiary.Clicked += AddApiary;
            stackLayout.Children.Add(_addApiary);

            _getApiary = new Button()
            {
                Text = "Към моите пчелини",
                TextColor = Color.White,
                BackgroundColor = Color.CornflowerBlue
            };
            _getApiary.Clicked += GetApiary;
            stackLayout.Children.Add(_getApiary);

            _addBeehive = new Button()
            {
                Text = "Добави кошер",
                TextColor = Color.White,
                BackgroundColor = Color.CornflowerBlue
            };
            _addBeehive.Clicked += AddBeehive;
            stackLayout.Children.Add(_addBeehive);

            _getBeehive = new Button()
            {
                Text = "Към моите кошери",
                TextColor = Color.White,
                BackgroundColor = Color.CornflowerBlue
            };
            _getBeehive.Clicked += GetBeehive;
            stackLayout.Children.Add(_getBeehive);

            Content = stackLayout;
        }

        private async void GetApiary(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiariesListView(dbPath));
        }

        private async void AddApiary(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddApiaryPage(dbPath));
        }

        private async void GetBeehive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetBeehivesContentPage(dbPath));
        }

        private async void AddBeehive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBeehiveContentPage(dbPath));
        }
    }
}