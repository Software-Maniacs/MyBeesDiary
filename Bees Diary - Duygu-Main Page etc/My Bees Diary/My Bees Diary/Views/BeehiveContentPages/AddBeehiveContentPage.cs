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
{
    public class AddBeehiveContentPage : ContentPage
    {
        private SQLiteConnection db;
        private Entry _name;
        private Entry _number;
        private Entry _stores;
        private Picker _apiary;
        private Picker _typeOfBeehive;
        private Picker _typeOfBee;
        private Entry _production;
        private Entry _feedings;
        private Entry _reviews;
        private Entry _treatments;
        private Button _add;
        private Button _exit;
        private Apiary apiary;
        public AddBeehiveContentPage(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            apiary = null;
            StackLayout stackLayout = new StackLayout();

            _name = new Entry
            {
                Placeholder = "Име на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_name);

            _number = new Entry()
            {
                Placeholder = "Номер на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_number);

            _stores = new Entry()
            {
                Placeholder = "Магазини",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_stores);

            _apiary = new Picker();
            _apiary.Title = "Пчелин";
            _apiary.ItemsSource = db.Table<Apiary>().OrderBy(a => a.ID).ToList();
            stackLayout.Children.Add(_apiary);

            _typeOfBeehive = new Picker();
            _typeOfBeehive.Title = "Тип кошер";
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

            _typeOfBee = new Picker();
            _typeOfBee.Title = "Тип пчели";
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

            _production = new Entry();
            _production.Placeholder = "Продукция";
            _production.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_production);

            _feedings = new Entry()
            {
                Placeholder = "Хранения",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_feedings);

            _reviews = new Entry()
            {
                Placeholder = "Прегледи",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_reviews);

            _treatments = new Entry()
            {
                Placeholder = "Третирания",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_treatments);

            _add = new Button();
            _add.Text = "Добави кошер";
            _add.Clicked += Add;
            stackLayout.Children.Add(_add);

            _exit = new Button()
            {
                Text = "Назад",
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

            _name = new Entry
            {
                Placeholder = "Име на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_name);

            _number = new Entry()
            {
                Placeholder = "Номер на кошер",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_number);

            _stores = new Entry()
            {
                Placeholder = "Магазини",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_stores);

            _typeOfBeehive = new Picker();
            _typeOfBeehive.Title = "Тип кошер";
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

            _typeOfBee = new Picker();
            _typeOfBee.Title = "Тип пчели";
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

            _production = new Entry();
            _production.Placeholder = "Продукция";
            _production.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_production);

            _feedings = new Entry()
            {
                Placeholder = "Хранения",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_feedings);

            _reviews = new Entry()
            {
                Placeholder = "Прегледи",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_reviews);

            _treatments = new Entry()
            {
                Placeholder = "Третирания",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_treatments);

            _add = new Button();
            _add.Text = "Добави кошер";
            _add.Clicked += Add;
            stackLayout.Children.Add(_add);

            _exit = new Button()
            {
                Text = "Назад",
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
                Feedings = int.Parse(_feedings.Text),
                Reviews = int.Parse(_reviews.Text),
                Treatments = int.Parse(_treatments.Text)
            };

            if (apiary == null)
            {
                 apiary = db.Query<Apiary>("select * from Apiary where id = " +
                               int.Parse(_apiary.SelectedItem.ToString().Split().ToArray()[0])).First();
            }
            beehive.ApiaryID = apiary.ID;

            db.Insert(beehive);
            await DisplayAlert(null, "Кошер " + _name.Text + " се добави в пчелинa.", "OK");
            await Navigation.PopAsync();
        }
    }
}