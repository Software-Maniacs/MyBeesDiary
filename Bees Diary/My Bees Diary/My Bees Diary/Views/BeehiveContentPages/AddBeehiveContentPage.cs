using Microsoft.Data.Sqlite;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Services;
using My_Bees_Diary.Services.Repositories;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace My_Bees_Diary.Views
{/// <summary>
/// In this page the user can add beehives to the data base.
/// </summary>
    public class AddBeehiveContentPage : ContentPage
    {
        private SQLiteConnection db;
        private Entry _name;
        private Entry _number;
        private Entry _stores;
        private Picker _apiary;
        private Picker _typeOfBeehive;
        private Picker _typeOfBee;
        private Button _add;
        private Button _exit;
        private Apiary apiary;
     
        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>
        public AddBeehiveContentPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            apiary = null;
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;

            Label label1 = new Label()
            {
                Text = "Име на кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label1);

            _name = new Entry
            {
                Placeholder = "Добавете име на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_name);

            Label label2 = new Label()
            {
                Text = "Номер на кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label2);

            _number = new Entry()
            {
                Placeholder = "Добавете номер на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_number);

            Label label3 = new Label()
            {
                Text = "Брой магазини",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label3);

            _stores = new Entry()
            {
                Placeholder = "Добавете броя на магазините",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_stores);

            Label label4 = new Label()
            {
                Text = "Пчелин",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label4);

            _apiary = new Picker();
            _apiary.Title = "Избере пчелин";
            _apiary.ItemsSource = db.Table<Apiary>().OrderBy(a => a.ID).ToList();
            stackLayout.Children.Add(_apiary);

            Label label5 = new Label()
            {
                Text = "Тип кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label5);

            _typeOfBeehive = new Picker();
            _typeOfBeehive.Title = "Изберете тип кошер";
            _typeOfBeehive.ItemsSource = new List<string>
                (
                new string[]
                {
                    "Лангстрот-Рут",
                    "Лангстрот-Рут(8-рамков)",
                    "Тръвна",
                    "Алпийски кошер Роже Делон",
                    "Лежак",
                    "Фарар",
                    "Многокорпусен кошер",
                    "Дадан-Блат",
                    "За отглеждане на майка"
                    }
                );
            stackLayout.Children.Add(_typeOfBeehive);

            Label label6 = new Label()
            {
                Text = "Тип пчели",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label6);

            _typeOfBee = new Picker();
            _typeOfBee.Title = "Изберете тип пчели";
            _typeOfBee.ItemsSource = new List<string>
                (
                new string[]
                {
                    "Пчелно семейство",
                    "Рояк",
                    "Кошер",
                    "Отводка"
                }
                );
            stackLayout.Children.Add(_typeOfBee);
                        
            _add = new Button();
            _add.Text = "Добави кошер";
            _add.BackgroundColor = Color.CornflowerBlue;
            _add.TextColor = Color.White;
            _add.Clicked += Add;
            stackLayout.Children.Add(_add);

            _exit = new Button()
            {
                Text = "Назад",
                BackgroundColor= Color.CornflowerBlue,
                TextColor=Color.White,
        };
            _exit.Clicked += Exit;
            stackLayout.Children.Add(_exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        public AddBeehiveContentPage(string dbPath, Apiary apiary)
        {
            db = new SQLiteConnection(dbPath);
            this.apiary = apiary;
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;

            Label label1 = new Label()
            {
                Text = "Име на кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label1);

            _name = new Entry
            {
                Placeholder = "Добавете име на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_name);

            Label label2 = new Label()
            {
                Text = "Номер на кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label2);

            _number = new Entry()
            {
                Placeholder = "Добавете номер на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_number);

            Label label3 = new Label()
            {
                Text = "Брой магазини",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label3);

            _stores = new Entry()
            {
                Placeholder = "Добавете броя на магазините",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_stores);

            Label label4 = new Label()
            {
                Text = "Пчелин",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label4);

            _apiary = new Picker();
            _apiary.Title = "Избере пчелин";
            _apiary.ItemsSource = db.Table<Apiary>().OrderBy(a => a.ID).ToList();
            stackLayout.Children.Add(_apiary);

            Label label5 = new Label()
            {
                Text = "Тип кошер",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label5);

            _typeOfBeehive = new Picker();
            _typeOfBeehive.Title = "Изберете тип кошер";
            _typeOfBeehive.ItemsSource = new List<string>
                (
                new string[]
                {
                    "Лангстрот-Рут",
                    "Лангстрот-Рут(8-рамков)",
                    "Тръвна",
                    "Алпийски кошер Роже Делон",
                    "Лежак",
                    "Фарар",
                    "Многокорпусен кошер",
                    "Дадан-Блат",
                    "За отглеждане на майка"
                    }
                );
            stackLayout.Children.Add(_typeOfBeehive);

            Label label6 = new Label()
            {
                Text = "Тип пчели",
                FontSize = 15,
                TextColor = Color.DarkBlue

            };
            stackLayout.Children.Add(label6);

            _typeOfBee = new Picker();
            _typeOfBee.Title = "Изберете тип пчели";
            _typeOfBee.ItemsSource = new List<string>
                (
                new string[]
                {
                    "Пчелно семейство",
                    "Рояк",
                    "Кошер",
                    "Отводка"
                }
                );
            stackLayout.Children.Add(_typeOfBee);

            _add = new Button();
            _add.Text = "Добави кошер";
            _add.Clicked += Add;
            _add.BackgroundColor = Color.CornflowerBlue;
            _add.TextColor = Color.White;
            stackLayout.Children.Add(_add);

            _exit = new Button()
            {
                Text = "Назад",
                BackgroundColor = Color.CornflowerBlue,
                TextColor = Color.White,
            };
            _exit.Clicked += Exit;
            stackLayout.Children.Add(_exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Add(object sender, EventArgs e)
        {
            db.CreateTable<Beehive>();

            Beehive lastBeehive = db.Table<Beehive>().OrderByDescending(b => b.ID).FirstOrDefault();
            int id;

            if(lastBeehive == null)
            {
                id = 1;
            }
            else
            {
                id = lastBeehive.ID++;
            }

            Beehive beehive = new Beehive()
            {
                ID = id,
                Number = _number.Text,
                Stores = int.Parse(_stores.Text),
                Name = _name.Text,
                TypeBeehive = _typeOfBeehive.SelectedItem.ToString(),
                TypeBees = _typeOfBee.SelectedItem.ToString(),
                Feedings = 0,
                Reviews = 0,
                Treatments = 0,
                Honey = 0,
                Wax = 0,
                Propolis = 0,
                Pollen = 0,
                RoyalJelly = 0,
                Poison = 0
            };

            if (apiary == null)
            {
                 apiary = db.Query<Apiary>("select * from Apiary where id = " +
                               int.Parse(_apiary.SelectedItem.ToString().Split().ToArray()[0])).First();
            }
            beehive.ApiaryID = apiary.ID;

            db.Insert(beehive);
            await DisplayAlert(null, "Кошер " + _name.Text + " се добави в пчелинa.", "OK");
            await Navigation.PushAsync(new MainPage(db.DatabasePath));
        }
    }
}