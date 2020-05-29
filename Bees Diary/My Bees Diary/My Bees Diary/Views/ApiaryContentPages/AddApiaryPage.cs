using My_Bees_Diary.Models.Entities;
//using Resources.Controls;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    public class AddApiaryPage : ContentPage
    {
        private SQLiteConnection db;
        private string _dbPath;
        private Entry apiaryName;
        private Entry apiaryNumber;
        private Picker apiaryType;
        private Entry apiaryLocation;
        private Button add;
        private Button exit;

        public AddApiaryPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;
            StackLayout stackLayout = new StackLayout();
            apiaryName = new Entry
            {
                Placeholder = "Въведете име на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryName);

            apiaryNumber = new Entry
            {
                Placeholder = "Въведете номер на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryNumber);

            apiaryType = new Picker();
            apiaryType.Title = "Изберете вида на пчелина";
            apiaryType.ItemsSource = new List<string>
                (
                new string[]
                {
                    "основен",
                    "мобилен",
                    "стационарен",
                    "помощен",
                    "за майко производство",
                    "за отводки"
                }
                );
            stackLayout.Children.Add(apiaryType);

            apiaryLocation = new Entry
            {
                Placeholder = "Въведете местоположението на пчелина",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(apiaryLocation);

            add = new Button();
            add.Text = "Добави пчелин";
            add.Clicked += AddApiary;
            stackLayout.Children.Add(add);

            exit = new Button();
            exit.Text = "Назад";
            exit.Clicked += ExitPage;
            stackLayout.Children.Add(exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void ExitPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiariesListView(_dbPath));
        }

        private async void AddApiary(object sender, EventArgs e)
        {
            db.CreateTable<Apiary>();

            Apiary lastApiary = db.Table<Apiary>().OrderByDescending(a => a.Date).FirstOrDefault();
            int id;

            if (lastApiary == null)
            {
                id = 1;
            }
            else
            {
                id = lastApiary.ID++;

            }

            Apiary apiary = new Apiary()
            {
                ID = id,
                Name = apiaryName.Text,
                Number = apiaryNumber.Text,
                Type = apiaryType.SelectedItem.ToString(),
                Location = apiaryLocation.Text,
                Date = DateTime.Now,
                Honey = 0,
                Wax = 0,
                Propolis = 0,
                Pollen = 0,
                RoyalJelly = 0,
                Poison = 0
            };

            db.Insert(apiary);
            await DisplayAlert(null, "Пчелин " + apiaryNumber.Text + " е успешно добавен.", "ОК");
            await Navigation.PopAsync();
        }
    }
}