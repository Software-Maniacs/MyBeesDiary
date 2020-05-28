using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    public class StartPage : ContentPage
    {
        private Button _addApiary;
        private Button _getApiary;
        private Button _addBeehive;
        private Button _getBeehive;
        private Button _statistic;
        private string dbPath;
        public StartPage(string databasePath)
        {
            dbPath = databasePath;

            StackLayout stackLayout = new StackLayout();

            _addApiary = new Button()
            {
                Text = "Add Apiary"
            };
            _addApiary.Clicked += AddApiary;
            stackLayout.Children.Add(_addApiary);

            _getApiary = new Button()
            {
                Text = "Get Apiary"
            };
            _getApiary.Clicked += GetApiary;
            stackLayout.Children.Add(_getApiary);

            _addBeehive = new Button()
            {
                Text = "Add Beehive"
            };
            _addBeehive.Clicked += AddBeehive;
            stackLayout.Children.Add(_addBeehive);

            _getBeehive = new Button()
            {
                Text = "Get Beehive"
            };
            _getBeehive.Clicked += GetBeehive;
            stackLayout.Children.Add(_getBeehive);

            _statistic = new Button()
            {
                Text = "Statistic"
            };
            _statistic.Clicked += Statistic;
            stackLayout.Children.Add(_statistic);

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

        private async void Statistic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetBeehivesFromComparing(dbPath));
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