using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Views.BeehiveContentPages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class BeehiveInfoPage : ContentPage
    {
        private SQLiteConnection db;
        private Beehive beehive;
        private Entry _name;
        private Entry _number;
        private Picker _typeOfBeehive;
        private Picker _typeOfBee;
        private Button _save;
        private Button _exit;
        private Button _delete;
        private Button _activities;
        private Button _production;
        public BeehiveInfoPage(Beehive beehive, string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            this.beehive = beehive;

            StackLayout stackLayout = new StackLayout();

            _name = new Entry()
            {
                Text = beehive.Name
            };
            stackLayout.Children.Add(_name);

            _number = new Entry()
            {
                Text = beehive.Number
            };
            stackLayout.Children.Add(_number);

            _typeOfBeehive = new Picker()
            {
                Title = beehive.TypeBeehive
            };
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

            _typeOfBee = new Picker()
            {
                Title = beehive.TypeBees
            };
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

            _save = new Button()
            {
                Text = "Запази промените"
            };
            _save.Clicked += Save;
            stackLayout.Children.Add(_save);

            _production = new Button()
            {
                Text = "Продукция"
            };
            _production.Clicked += Production;
            stackLayout.Children.Add(_production);

            _activities = new Button()
            {
                Text = "Дейности"
            };
            _activities.Clicked += Activities;
            stackLayout.Children.Add(_activities);

            _delete = new Button()
            {
                Text = "Изтрий кошера"
            };
            _delete.Clicked += Delete;
            stackLayout.Children.Add(_delete);

            _exit = new Button()
            {
                Text = "Назад"
            };
            _exit.Clicked += Exit;
            stackLayout.Children.Add(_exit);

            Content = stackLayout;
        }

        private async void Production(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductionsPage(db.DatabasePath, beehive));
        }

        private async void Activities(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivitiesPage(db.DatabasePath, beehive));
        }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Delete(object sender, EventArgs e)
        {
            db.Delete(beehive);
            await DisplayAlert(null, "Вие изтрихте " + beehive.Name + ".", "OK");
            await Navigation.PushAsync(new GetBeehivesContentPage(db.DatabasePath));
        }

        private async void Save(object sender, EventArgs e)
        {
            beehive.Name = _name.Text;
            beehive.Number = _number.Text;

            if(_typeOfBeehive.SelectedItem != null)
            {
                beehive.TypeBeehive = _typeOfBeehive.SelectedItem.ToString();
            }

            if(_typeOfBee.SelectedItem != null)
            {
                beehive.TypeBees = _typeOfBee.SelectedItem.ToString();
            }

            db.Update(beehive);

            await DisplayAlert(null, "Вие направихте промени в кошер " + beehive + ".", "OK");
            await Navigation.PopAsync();
        }
    }
}