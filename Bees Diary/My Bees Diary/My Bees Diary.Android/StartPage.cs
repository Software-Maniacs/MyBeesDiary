using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    public class StartPage : ContentPage
    {
        private Button _add;
        private Button _get;
        private Button _statistic;
        private string dbPath;
        public StartPage(string databasePath)
        {
            dbPath = databasePath;

            StackLayout stackLayout = new StackLayout();

            _add = new Button()
            {
                Text = "Add"
            };
            _add.Clicked += Add;
            stackLayout.Children.Add(_add);

            _get = new Button()
            {
                Text = "Get"
            };
            _get.Clicked += Get;
            stackLayout.Children.Add(_get);

            _statistic = new Button()
            {
                Text = "Statistic"
            };
            _statistic.Clicked += Statistic;
            stackLayout.Children.Add(_statistic);

            Content = stackLayout;
        }

        private async void Statistic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetBeehivesFromComparing(dbPath));
        }

        private async void Get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetBeehivesContentPage(dbPath));
        }

        private async void Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBeehiveContentPage(dbPath));
        }
    }
}