using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class Page3 : ContentPage
{
        private string databasePath;
        private Picker _options;
        private Button _button;
    public Page3(string dbPath)
    {
            databasePath = dbPath;
            StackLayout stackLayout = new StackLayout();

            _options = new Picker()
            {
                ItemsSource = new List<string>
                (
                    new string[]
                    {
                    "Сравни пчелини",
                    "Сравни кошери"
                    }
                ),
                Title = "Избери опция"
            };
            stackLayout.Children.Add(_options);

            _button = new Button()
            {
                Text = "Сравни"
            };
            _button.Clicked += Compare;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
    }

        private async void Compare(object sender, EventArgs e)
        {
            //await Navigation.PushAsync();
        }
    }
}