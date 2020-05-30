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
    /// <summary>
    /// In this page the user can add apiaries to the data base.
    /// </summary>
    public class AddApiaryPage : ContentPage
    {
        private SQLiteConnection db;
        private Label label;
        private Label label2;
        private string _dbPath;
        private Entry apiaryName;
        private Entry apiaryNumber;
        private Picker apiaryType;
        private Entry apiaryLocation;
        private Button add;
        private Button exit;

        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>

        public AddApiaryPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;
            label = new Label()
            {
                Text = Title = "Дoбавете нов пчелин",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            Label label2 = new Label()
            {
                Text = "Име на пчелин",
                FontSize = 15,
                TextColor=Color.DarkBlue

            };
            stackLayout.Children.Add(label2);

            apiaryName = new Entry
            {
                Placeholder = "Въведете име на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryName);

            Label label3 = new Label()
            {
                Text = "Номер на пчелин",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label3);

            apiaryNumber = new Entry
            {
                Placeholder = "Въведете номер на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryNumber);

            Label label4 = new Label()
            {
                Text = "Вид на пчелин",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label4);

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

            Label label5 = new Label()
            {
                Text = "Местоположение на пчелин",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label5);

            apiaryLocation = new Entry
            {
                Placeholder = "Въведете местоположението на пчелина",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(apiaryLocation);

            add = new Button();
            add.Text = "Добави пчелин";
            add.BackgroundColor = Color.CornflowerBlue;
            add.TextColor = Color.White;
            add.Clicked += AddApiary;
            stackLayout.Children.Add(add);

            exit = new Button();
            exit.Text = "Назад";
            exit.BackgroundColor = Color.CornflowerBlue;
            exit.TextColor = Color.White;
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